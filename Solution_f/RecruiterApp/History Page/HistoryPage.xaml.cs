using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class HistoryPage : ContentPage
	{
		public HistoryPage()
		{
			InitializeComponent();
			HistoryListViewPage();
		}

		public void HistoryListViewPage()
		{
			var categories = new List<string>()
			{
				"View Accepted",
				"View Rejected",
				"Pipeline"
			};

			var list = historyListView;
			list.ItemsSource = categories;
			Content = list;
		}

		public void SelectionMade(object sender, ItemTappedEventArgs e)
		{
			var item = e.Item.ToString();
			//DisplayAlert("Alert", "You have selected" + item, "OK");

			Navigation.PushAsync(new CandidateResults());
		}

	}
}

