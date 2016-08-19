using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class CandidateResults : ContentPage
	{



		public CandidateResults()
		{
			InitializeComponent();
			ViewCandidates();
			//NavigationPage.SetBackButtonTitle(HistoryPage," ");
			//NavigationPage.SetHasNavigationBar(HomePage,true);

		}

		public void ViewCandidates()
		{
			var candidates = new List<string>()
			{
				"Pintado, Cristian",
				"Ruelas, Eric",
				"Belyzev, Nikita"
			};

			var list = candidateHistoryListView;
			list.ItemsSource = candidates;
			Content = list;
		}

		public void SelectionMade(object sender, ItemTappedEventArgs e)
		{
			var item = e.Item.ToString();
			//DisplayAlert("Alert", "You have selected" + item, "OK");

			Navigation.PushAsync(new InformationAboutCandidatePage());
		}

	}
}

