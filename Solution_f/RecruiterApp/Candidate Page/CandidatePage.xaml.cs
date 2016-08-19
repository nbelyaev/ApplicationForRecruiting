using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class CandidatePage : ContentPage
	{
		public CandidatePage()
		{
			InitializeComponent();
			CandidateListViewPage();

		}

		public void CandidateListViewPage()
		{
			var candidates = new List<string>()
			{
				"Pintado Cristian",
				"Kenar Monica",
				"Belyaev Nikita"
			};

			var list = candidateListView;
			list.ItemsSource = candidates;
			Content = list;
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
	}
}

