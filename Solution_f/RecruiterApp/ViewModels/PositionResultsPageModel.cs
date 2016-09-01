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

        
    }
}

