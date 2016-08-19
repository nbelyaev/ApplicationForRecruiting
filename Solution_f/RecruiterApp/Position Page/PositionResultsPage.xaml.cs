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
			//loadCandidateTable();
		}

		//Binds the candidate table in the xaml file
		public void loadCandidateTable()
		{
			positionResultsVM = new PositionResultsPageModel();
			BindingContext = positionResultsVM;

		}
		//opens the informationAboutCanidatePage
		public void onItemTapped(object sender, ItemTappedEventArgs e)
		{
			// item = e.Item as Candidate;
			//var selectedPosition = new PositionResultsPage();
			//selectedPosition.BindingContext = item;
			////DisplayAlert("Alert", "Item Selected: " + item.positionId, "OK");
			Navigation.PushAsync(new InformationAboutCandidatePage());
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			// Set syncItems to true in order to synchronize the data on startup when running in offline mode
			await RefreshItems(true, syncItems: false);
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
				//positionList.ItemsSource = await manager.GetTodoItemsAsync(syncItems);
			}
		}

		public async void OnComplete(object sender, EventArgs e)
		{
			var mi = ((MenuItem)sender);
			var pos = mi.CommandParameter as Position;
			await CompleteItem(pos);
		}

		async Task CompleteItem(Position position)
		{
			//await manager.GetPositionItemsAsync(true);
			//positionList.ItemsSource = await manager.GetPositionItemsAsync();
		}

		private class ActivityIndicatorScope : IDisposable
		{
			private bool showIndicator;
			private ActivityIndicator indicator;
			private Task indicatorDelay;

			public ActivityIndicatorScope(ActivityIndicator indicator, bool showIndicator)
			{
				this.indicator = indicator;
				this.showIndicator = showIndicator;

				if (showIndicator)
				{
					indicatorDelay = Task.Delay(2000);
					SetIndicatorActivity(true);
				}
				else
				{
					indicatorDelay = Task.FromResult(0);
				}
			}

			private void SetIndicatorActivity(bool isActive)
			{
				this.indicator.IsVisible = isActive;
				this.indicator.IsRunning = isActive;
			}

			public void Dispose()
			{
				if (showIndicator)
				{
					indicatorDelay.ContinueWith(t => SetIndicatorActivity(false), TaskScheduler.FromCurrentSynchronizationContext());
				}
			}
		}
	}
}

