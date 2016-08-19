using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class SearchPageResults : ContentPage
	{
		SearchPageResultsPageModel positionVM;
		public SearchPageResults()
		{
			InitializeComponent();
			loadTable();
		}

		public void loadTable()
		{

			positionVM = new SearchPageResultsPageModel();
			BindingContext = positionVM;

		}

		public void onItemTapped(object sender, ItemTappedEventArgs e)
		{

			// item = e.Item as Candidate;
			//var selectedPosition = new PositionResultsPage();
			//selectedPosition.BindingContext = item;
			var item = e.Item as Position;
			var selectedPosition = new PositionResultsPageModel();
			selectedPosition.positions = item;
			var selectedPositionPage = new PositionResultsPage();
			selectedPositionPage.BindingContext = selectedPosition;
			////DisplayAlert("Alert", "Item Selected: " + item.positionId, "OK");
			Navigation.PushAsync(selectedPositionPage);
		}
	}
}

