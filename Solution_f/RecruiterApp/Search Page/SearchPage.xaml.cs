using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class SearchPage : ContentPage
	{
		public SearchPage()
		{
			InitializeComponent();

		}
		public void searchContent(object sender, EventArgs e)
		{
			var pickerItem = SearchFieldPicker.Items [SearchFieldPicker.SelectedIndex];
			Navigation.PushAsync(new SearchPageResults());
		}
	}
}