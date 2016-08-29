using System;
using System.Collections.Generic;
using Xamarin.Forms;



namespace RecruiterApp
{
	public partial class CandidateDetailsPage : ContentPage
	{

		int countclickADP = 0;
		int countclickOnlineApp = 0;

		public CandidateDetailsPage()
		{
			InitializeComponent();
		}

        public CandidateDetailsPage(Candidate cand) {
            BindingContext = cand;
            InitializeComponent();
            
        }

        public void ChangedPosition(object sender, EventArgs e)
		{
			SaveCandidateToPosition.IsVisible = true;
		}

		public async void SaveCandidateToAnotherPosition(object sender, EventArgs e)
		{
			var candidate = lblName.Text;
			var position = AddCandidateToPositionPicker.Items[AddCandidateToPositionPicker.SelectedIndex];
			var answer = await DisplayAlert("Warning", "Are you sure you want to add " + candidate + " to " + position , "Yes", "No");


			if (answer)
			{
				SaveCandidateToPosition.IsVisible = false;
				AddCandidateToPositionPicker.IsVisible = false;
				DisplayAlert("Alert", "Added! Check the candidates page!", "Ok");
			}
		}

		public void AddToAnotherPosition(object sender, EventArgs e)
		{
			AddCandidateToPositionPicker.IsVisible = true;
			//DisplayAlert("Alert", "Added this person to a position", "ok");
		}

		public void switcherFace2Face(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				interviewerNameFace.IsVisible = true;
				AddInterviewerFace2Face.IsVisible = true;
				moreInterviewerFace.IsVisible = true;
				SaveFaceButton.IsVisible = true;
			}
			else {
				interviewerNameFace.IsVisible = false;
				AddInterviewerFace2Face.IsVisible = false;
				moreInterviewerFace.IsVisible = false;
				DeleteInterviewerFace.IsVisible = false;
				SaveFaceButton.IsVisible = false;

			}
		}

		public void DeleteInterviewerTextBoxFace(object sender, EventArgs e)
		{
			var countInterviewers = moreInterviewerFace.Children.Count;

			if (countInterviewers > 0)
			{
				moreInterviewerFace.Children.RemoveAt(moreInterviewerFace.Children.Count - 1);

				if (countInterviewers == 1)
				{
					DeleteInterviewerFace.IsVisible = false;

				}
			}
		}


		public void Face2FaceChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				SaveFaceButton.IsVisible = false;
			}
			else
			{
				SaveFaceButton.IsVisible = true;
			}
		}

		public void AddInterviewerTextBoxFace(object sender, EventArgs e)
		{
			Entry anotherInterviewer = new Entry();
			anotherInterviewer.Placeholder = "Name of Interviewer";
			moreInterviewerFace.Children.Add(anotherInterviewer);

			var countTextBoxes = moreInterviewerFace.Children.Count;

			if (countTextBoxes > 0)
			{
				DeleteInterviewerFace.IsVisible = true;
			}
		}

		public void SaveFaceInterview(object sender, EventArgs e)
		{
			//put values to the database.

		}

		// Phone Interview Portion

		public void switcherPhone(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				//DisplayAlert("Alert", "You have selected" + e.Value, "OK");
				interviewerNamePhone.IsVisible = true;
				AddInterviewer.IsVisible = true;
				moreInterviewerPhone.IsVisible = true;
				//DeleteInterviewer.IsVisible = true;
				SavePhoneButton.IsVisible = true;
			}
			else {
				interviewerNamePhone.IsVisible = false;
				AddInterviewer.IsVisible = false;
				DeleteInterviewer.IsVisible = false;
				moreInterviewerPhone.IsVisible = false;
				SavePhoneButton.IsVisible = false;
			}
		}

		public void PhoneChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				SavePhoneButton.IsVisible = false;
			}
			else
			{
				SavePhoneButton.IsVisible = true;
			}
		}

		public void AddInterviewerTextBoxPhone(object sender, EventArgs e)
		{
			Entry anotherInterviewerPhone = new Entry();
			anotherInterviewerPhone.Placeholder = "Name of Interviewer";
			moreInterviewerPhone.Children.Add(anotherInterviewerPhone);

			var countTextBoxes = moreInterviewerPhone.Children.Count;

			if (countTextBoxes > 0)
			{
				DeleteInterviewer.IsVisible = true;
			}
		}

		public void DeleteInterviewerTextBoxPhone(object sender, EventArgs e)
		{
			var countInterviewers = moreInterviewerPhone.Children.Count;

			if (countInterviewers > 0)
			{
				moreInterviewerPhone.Children.RemoveAt(moreInterviewerPhone.Children.Count - 1);

				if (countInterviewers == 1)
				{
					DeleteInterviewer.IsVisible = false;

				}

			}
		}

		public void SavePhoneInterview(object sender, EventArgs e)
		{
			//put values to the database.
		}


		//Online Application Portion

		public async void SendOnlineApplication(object sender, EventArgs e)
		{
			countclickOnlineApp++;

			if (countclickOnlineApp == 1)
			{
				var answer = await DisplayAlert("Alert", "Are you sure you want to send Cristian Pintado the Online Application?", "Yes", "No");

				//Store in the database that the email has been sent.


				//SendMail();




				if (answer)
				{
					OnlineApplicationButton.Text = "   Sent!   ";
					OnlineApplicationButton.BackgroundColor = Xamarin.Forms.Color.Gray;
				}
			}
			else if (countclickOnlineApp > 1)
			{
				await DisplayAlert("Alert", "You already sent this email to this individual.", "Ok");
			}
		}



		public void SendMail(List<string> to, List<string> cc, string subject, string body, Object controlToPresent)
		{
			

		}

		public void OnlineApplicationChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				SaveOnlineApplicationButton.IsVisible = false;
			}
			else
			{
				SaveOnlineApplicationButton.IsVisible = true;
			}
		}

		public void SaveOnlineApplication(object sender, EventArgs e)
		{
		}

		//Detail and References Content

		public void switcherDetailAndReferences(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				SaveDetailsAndReferencesButton.IsVisible = true;
			}
			else
			{
				SaveDetailsAndReferencesButton.IsVisible = false;
			}
		}

		public void DetailsAndReferencesChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				SaveDetailsAndReferencesButton.IsVisible = false;
			}
			else
			{
				SaveDetailsAndReferencesButton.IsVisible = true;
			}
		}

		public void SaveDetailsAndReferences(object sender, EventArgs e)
		{
			//send data to the database.
		}

		//Send email of ADP Content

		public void emailADPChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				SaveADPemailButton.IsVisible = false;
			}
			else
			{
				SaveADPemailButton.IsVisible = true;
			}
		}

		public void SaveADPemail(object sender, EventArgs e)
		{
			//send data to the database.
		}

		public async void SendADPForm(object sender, EventArgs e)
		{
			countclickADP++;

			if (countclickADP == 1)
			{
				var answer = await DisplayAlert("Alert", "Are you sure you want to send Cristian Pintado the ADP Form?", "Yes", "No");


				//Store in the database that the email has been sent.


				if (answer)
				{
					ADPSent.Text = "   Sent!   ";
					ADPSent.BackgroundColor = Xamarin.Forms.Color.Gray;
				}
			}
			else if(countclickADP > 1) {
				await DisplayAlert("Alert", "You already sent an email to this individual.", "Ok" );
			}

		}


		//Verbal Offer Portion
		public void switcherVerbalOffer(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				VerbalOfferButton.IsVisible = true;
			}
			else
			{
				VerbalOfferButton.IsVisible = false;
			}
		}

		public void SaveVerbalOffer(object sender, EventArgs e)
		{

			//send data to the database.
		}

		public void VerbalOfferChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				VerbalOfferButton.IsVisible = false;
			}
			else
			{
				VerbalOfferButton.IsVisible = true;
			}
		}

		//Formal Offer portion

		public void SaveFormalOffer(object sender, EventArgs e)
		{
			//send data to database.
		}


		public void switcherFormalOffer(object sender, ToggledEventArgs e) 
		{ 
			if (e.Value == true)
			{
				FormalOfferButton.IsVisible = true;
			}
			else
			{
				FormalOfferButton.IsVisible = false;
			}
		}

		public void FormalOfferChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				FormalOfferButton.IsVisible = false;
			}
			else
			{
				FormalOfferButton.IsVisible = true;
			}
		}

		//Sogeti Resume Portion

		public void switcherSogetiResume(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				SogetiResumeButton.IsVisible = true;
			}
			else
			{
				SogetiResumeButton.IsVisible = false;
			}
		}

		public void SaveSogetiResume(object sender, EventArgs e)
		{
			//Save things to database.
		}

		public void SogetiResumeChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				SogetiResumeButton.IsVisible = false;
			}
			else
			{
				SogetiResumeButton.IsVisible = true;
			}
		}

		//Background check portion

		public void SaveBackgroundCheck(object sender, EventArgs e)
		{
			//send data to the database.
		}

		public void BackgroundCheckChange(object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				BackgroundCheckButton.IsVisible = false;
			}
			else
			{
				BackgroundCheckButton.IsVisible = true;
			}
		}

		public void switcherBackground(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				BackgroundCheckButton.IsVisible = true;
			}
			else
			{
				BackgroundCheckButton.IsVisible = false;
			}
		}

		//Accepted Offer portion

		public void AcceptedOfferChange( object sender, TextChangedEventArgs e)
		{
			var value = sender as Editor;
			if (value.Text.Equals(""))
			{
				AcceptedOfferButton.IsVisible = false;
			}
			else
			{
				AcceptedOfferButton.IsVisible = true;
			}
		}

		public void SaveAcceptedOffer(object sender, EventArgs e)
		{
			//send data to the database.
		}

		public void switcherAcceptedOffer(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				AcceptedOfferButton.IsVisible = true;
			}
			else
			{
				AcceptedOfferButton.IsVisible = false;
			}
		}

	}
}

