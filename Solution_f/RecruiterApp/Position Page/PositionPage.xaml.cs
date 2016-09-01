using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class PositionPage : ContentPage
	{
		ItemManager manager;
		PositionPageModel positionVM;
		public PositionPage()
		{
			InitializeComponent();
			manager = ItemManager.DefaultManager;
			loadTable();

		}
		public void loadTable()
		{

			positionVM = new PositionPageModel();
			BindingContext = positionVM;

		}
		public async void onItemTapped(object sender, ItemTappedEventArgs e)
		{
            
			Position item = (Position)e.Item;

			var positionSelected = new PositionResultsPageModel();
			positionSelected.position = item;

            await positionSelected.GetCandidates();


			var selectedPosition = new PositionResultsPage();
			selectedPosition.BindingContext = positionSelected;
			//DisplayAlert("Alert", "Item Selected: " + item.positionId, "OK");
			await Navigation.PushAsync(selectedPosition);

		}
		public void createNewPosition(object sender, EventArgs e)
		{
			Navigation.PushAsync(new CreateNewPositionPage());

			//add new position to the database.
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
            

			// Set syncItems to true in order to synchronize the data on startup when running in offline mode
			await RefreshItems(true, syncItems: false);
		}
		

		public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var position = e.SelectedItem as Position;
			if (Device.OS != TargetPlatform.iOS && position != null)
			{
				// Not iOS - the swipe-to-delete is discoverable there
				if (Device.OS == TargetPlatform.Android)
				{
					await DisplayAlert(position.Name, "Press-and-hold to complete task " + position.Name, "Got it!");
				}
				//else
				//{
				//	// Windows, not all platforms support the Context Actions yet
				//	if (await DisplayAlert("Mark completed?", "Do you wish to complete " + position.positionName + "?", "Complete", "Cancel"))
				//	{
				//		await CompleteItem(position);
				//	}
				//}
			}

			// prevents background getting highlighted
			listOfPositions.SelectedItem = null;
		}

		public async void OnRefresh(object sender, EventArgs e)
		{
			var list = (ListView)sender;
            
            Exception error = null;
            try {
                await RefreshItems(false, true);
            }
            catch (Exception ex) {
                error = ex;
            }
            finally {
                list.EndRefresh();
            }

            if (error != null) {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }

		private async Task RefreshItems(bool showActivityIndicator, bool syncItems)
		{
			using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
			{
				listOfPositions.ItemsSource = await manager.GetPositionItemsAsync(syncItems);
			}
		}
        
	}
}

