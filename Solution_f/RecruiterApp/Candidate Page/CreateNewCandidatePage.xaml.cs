using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class CreateNewCandidatePage : ContentPage
	{
		public CreateNewCandidatePage()
		{
			InitializeComponent();

		}

		public async void AddCandidate(object sender, EventArgs e)
		{
			string candidateFullName = candidateFirstName.Text + " " + candidateLastName.Text;
			var answer = await DisplayAlert("Alert", "Are you sure you want to add " + candidateFullName + "?", "Yes", "No");
			if (answer)
			{
				await DisplayAlert("Alert", "Successfully added " + candidateFullName, "OK");
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

		private bool _canClose = true;

		protected override bool OnBackButtonPressed()
		{

			ShowExitDialog();

			return base.OnBackButtonPressed();
		}

		public async void ShowExitDialog()
		{
			var answer = await DisplayAlert("Exit", "If you leave all of your changes will not be saved", "Ok", "Not Ok.");
			if (answer)
			{
				_canClose = false;
				base.OnBackButtonPressed();
			}
		}


	}
}

