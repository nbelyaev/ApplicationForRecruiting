using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class PositionResultsPage : ContentPage
	{
		PositionResultsPageModel positionResultsVM;

		public PositionResultsPage()
		{
			InitializeComponent();
		}


        //opens the informationAboutCanidatePage
        //ItemTapped="onItemTapped"
        public void onItemTapped(object sender, ItemTappedEventArgs e) {
            


            var cand = e.Item as Candidate;
            
            //here you pass candidate who's info you want to display
            Navigation.PushAsync(new CandidateDetailsPage(cand));

            //Navigation.PushAsync(new CandidateDetailsPage());
            
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
            //positionName.Text = 

			// Set syncItems to true in order to synchronize the data on startup when running in offline mode
			//await RefreshItems(true, syncItems: false);
		}
		

		public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var candidate = e.SelectedItem as Candidate;
			if (Device.OS != TargetPlatform.iOS && candidate != null)
			{
				// Not iOS - the swipe-to-delete is discoverable there
				if (Device.OS == TargetPlatform.Android)
				{
					//await DisplayAlert(position.positionName, "Press-and-hold to complete task " + position.positionName, "Got it!");
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
			positionCandidateList.SelectedItem = null;
		}

		public async void OnRefresh(object sender, EventArgs e)
		{
			var list = (ListView)sender;
            
			Exception error = null;
			try
			{
				await RefreshItems(false, true);
			}
			catch (Exception ex)
			{
				error = ex;
			}
			finally
			{
				list.EndRefresh();
			}

			if (error != null)
			{
				await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
			}
		}

		private async Task RefreshItems(bool showActivityIndicator, bool syncItems)
		{
			using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator))
			{

                positionCandidateList.ItemsSource = positionCandidateList.ItemsSource;
			}
		}
        

        public void editPosition(object sender, EventArgs e) {
            //PositionResultsPageModel n = ((PositionResultsPageModel)BindingContext);
            var mi = ((ToolbarItem)sender);
            var pos = mi.CommandParameter as Position;

            Navigation.PushAsync(new CreateNewPositionPage(pos));

        }
        

		
	}
}

