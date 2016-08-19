using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class CreateNewPositionPage : ContentPage
	{
		public CreateNewPositionPage()
		{
			InitializeComponent();
		}

		public async void createNewPosition(object sender, EventArgs e)
		{
			string newPositionName = positionNameTxt.Text;
			var answer = await DisplayAlert("Alert", "Are you sure you want to add " + newPositionName + "?", "Yes", "No");
			if (answer)
			{
				await DisplayAlert("Alert", "Successfully added " + newPositionName, "OK");
				await Navigation.PopAsync(true);
				Navigation.RemovePage(this);
			}
		}
		public async void cancelBttn(object sender, EventArgs e)
		{
			var answer = await DisplayAlert("Alert", "Are you sure you want to cancel?", "Yes", "No");

			if (answer)
			{
				await Navigation.PopAsync(true);
				Navigation.RemovePage(this);
			}
		}
	}
}

