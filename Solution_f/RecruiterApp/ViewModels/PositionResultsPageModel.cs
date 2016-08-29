using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruiterApp
{
	public class PositionResultsPageModel
	{
        public PositionResultsPageModel() { }//used to test creation of the model


        private ItemManager manager = ItemManager.DefaultManager;
        public Position position { get; set; }
       
		public List<Candidate> Candidates { get; set; }

        //fills out list of candidates based on position selected
        public async Task GetCandidates() {
            var candidates = await manager.GetCandidatesForPositionAsync(position);
            Candidates = new List<Candidate>(candidates);
        }




        //private Candidate _selectedItem;
        //public Candidate SelectedItem {
        //    get { return _selectedItem; }
        //    set {
        //        if (_selectedItem != value) {
        //            _selectedItem = value;
        //            //OnPropertyChanged();

        //            //this can be placed before or after propertychanged notification raised, 
        //            //depending on the situation
        //            DoSomeDataOperation();

        //            Navigation.PushAsync(new CandidateDetailsPage());
        //        }
        //    }
        //}


    }
}

