using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class CandidatePage : ContentPage
	{
        ItemManager manager;
        public CandidatePage()
		{
			InitializeComponent();
			CandidateListViewPage();
            manager = ItemManager.DefaultManager;

        }

		public void CandidateListViewPage()
		{
			//var candidates = new List<string>()
			//{
			//	"Pintado Cristian",
			//	"Kenar Monica",
			//	"Belyaev Nikita"
			//};

			//var list = candidateListView;
			//list.ItemsSource = candidates;
			//Content = list;
		}


		public void SelectionMade(object sender, ItemTappedEventArgs e)
		{
			var item = e.Item.ToString();
			//DisplayAlert("Alert", "You have selected" + item, "OK");

			Navigation.PushAsync(new CandidateDetailsPage());
		}

		public void AddNewCandidate(object sender, EventArgs e)
		{
			//Add new candidate to the database.

			Navigation.PushAsync(new CreateNewCandidatePage());

		}




        /// /////////////////////////////////////////////////////////////////////////
        
        protected override async void OnAppearing() {
            base.OnAppearing();

            // Set syncItems to true in order to synchronize the data on startup when running in offline mode
            await RefreshItems(true, syncItems: false);
        }


        public async void OnRefresh(object sender, EventArgs e) {
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

        public async void OnSyncItems(object sender, EventArgs e) {
            await RefreshItems(true, true);
        }


        private async Task RefreshItems(bool showActivityIndicator, bool syncItems) {
            using (var scope = new ActivityIndicatorScope(syncIndicator, showActivityIndicator)) {
                candidateListView.ItemsSource = await manager.GetCandidatesAsync(syncItems);
            }
        }



        //private class ActivityIndicatorScope : IDisposable {
        //    private bool showIndicator;
        //    private ActivityIndicator indicator;
        //    private Task indicatorDelay;

        //    public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator) {
        //        this.indicator = indicator;
        //        this.showIndicator = showIndicator;

        //        if (showIndicator) {
        //            indicatorDelay = Task.Delay(2000);
        //            SetIndicatorActivity(true);
        //        }
        //        else {
        //            indicatorDelay = Task.FromResult(0);
        //        }
        //    }

        //    private void SetIndicatorActivity(bool isActive) {
        //        this.indicator.IsVisible = isActive;
        //        this.indicator.IsRunning = isActive;
        //    }

        //    public void Dispose() {
        //        if (showIndicator) {
        //            indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
        //        }
        //    }
        //}
    }
}

