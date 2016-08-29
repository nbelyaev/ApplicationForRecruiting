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
            //var mi = ((MenuItem)sender);
            //var cand = mi.CommandParameter as Candidate;


            var cand = e.Item as Candidate;



            //here you would pass candidate who's info you want to display
            Navigation.PushAsync(new CandidateDetailsPage(cand));

            //Navigation.PushAsync(new CandidateDetailsPage());



            // item = e.Item as Candidate;
            //var selectedPosition = new PositionResultsPage();
            //selectedPosition.BindingContext = item;
            ////DisplayAlert("Alert", "Item Selected: " + item.positionId, "OK");
            //Navigation.PushAsync(new InformationAboutCandidatePage());
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
            //positionName.Text = 

			// Set syncItems to true in order to synchronize the data on startup when running in offline mode
			//await RefreshItems(true, syncItems: false);
		}
		//async Task CompleteCandidate(Candidate candidate)
		//{
		//	await manager.SaveNewPositionAsync(position);
		//	positionList.ItemsSource = await manager.GetTodoItemsAsync();
		//}

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

        //public async void OnComplete(object sender, EventArgs e)
        //{
        //	var mi = ((MenuItem)sender);
        //	var pos = mi.CommandParameter as Position;
        //	await CompleteItem(pos);
        //}



        //it appears that this one is never called, instead onItemTapped is being tapped.
        //public void OnCandidateClick(object sender, EventArgs e) {
        //    var mi = ((MenuItem)sender);
        //    var cand = mi.CommandParameter as Candidate;

        //    //here you would pass candidate who's info you want to display
        //    //Navigation.PushAsync(new CandidateDetailsPage(cand));

        //    Navigation.PushAsync(new CandidateDetailsPage());
        //}

        public void editPosition(object sender, EventArgs e) {
            //PositionResultsPageModel n = ((PositionResultsPageModel)BindingContext);
            var mi = ((ToolbarItem)sender);
            var pos = mi.CommandParameter as Position;

            Navigation.PushAsync(new CreateNewPositionPage(pos));

        }

  //      async Task CompleteItem(Position position)
		//{
		//	//await manager.GetPositionItemsAsync(true);
		//	//positionList.ItemsSource = await manager.GetPositionItemsAsync();
		//}

		
	}
}

