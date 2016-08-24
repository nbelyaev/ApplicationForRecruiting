using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RecruiterApp
{
	public partial class CreateNewPositionPage : ContentPage
	{
        ItemManager manager;

        public CreateNewPositionPage()
		{
			InitializeComponent();
            manager = ItemManager.DefaultManager;
        }

		public async void createNewPosition(object sender, EventArgs e)
		{
			string newPositionName = positionName.Text;
            string newPositionDescription = positionDescription.Text;
			var answer = await DisplayAlert("Alert", "Are you sure you want to add " + newPositionName + "?", "Yes", "No");
            
            if (answer)
			{
                try {
                    await AddPosition(new Position { Name = newPositionName,
                        Description = newPositionDescription });
                    await DisplayAlert("Alert", "Successfully added " + newPositionName, "OK");
                    await Navigation.PopAsync(true);
                    Navigation.RemovePage(this);
                }
                catch {
                    await DisplayAlert("Alert", "Failed to add " + newPositionName, "OK");
                    
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

