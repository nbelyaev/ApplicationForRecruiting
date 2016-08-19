using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class InformationAboutCandidatePage : ContentPage
	{
		public InformationAboutCandidatePage()
		{
			InitializeComponent();
			PullFromDatabase();
		}


		public void PullFromDatabase()
		{
			//this method will pull from the database and fill all of the fields to be read only.

		}

	}
}

