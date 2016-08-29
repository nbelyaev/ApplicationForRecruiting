using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class CreateNewPositionPage : ContentPage
	{
        ItemManager manager;
        Position position;
        string currentAction {
            get {
                if (position == null) {
                    return "add";
                }
                else {
                    return "edit";
                }
            }
        }

        public CreateNewPositionPage()
		{
			InitializeComponent();
            manager = ItemManager.DefaultManager;
        }
        public CreateNewPositionPage(Position position) {
            InitializeComponent();
            manager = ItemManager.DefaultManager;
            positionName.Text = position.Name;
            positionDescription.Text = position.Description;
            this.position = position;
        }

        public async void createNewPosition(object sender, EventArgs e)
		{
			string newPositionName = positionName.Text;
            string newPositionDescription = positionDescription.Text;
			var answer = await DisplayAlert("Alert", "Are you sure you want to "+currentAction+ " "+ newPositionName + "?", "Yes", "No");
            
            if (answer)
			{
                try {
                    if( position == null)
                    {
                        position = new Position {
                            Name = newPositionName,
                            Description = newPositionDescription
                        };
                    }
                    else {
                        position.Name = newPositionName;
                        position.Description = newPositionDescription;
                    }

                    await AddPosition(position);
                    //await DisplayAlert("Alert", "Successfully "+currentAction+"ed " + newPositionName, "OK");
                    //await Navigation.PopAsync(true);

                    await Navigation.PopToRootAsync(true);
                    Navigation.RemovePage(this);
                }
                catch {
                    await DisplayAlert("Alert", "Failed to " + currentAction + " " + newPositionName, "OK");
                    
                }

                
				
			}
		}

        async Task AddPosition(Position item) {
            await manager.SaveNewPositionAsync(item);
            //await Navigation.PushAsync(new PositionPage());
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

