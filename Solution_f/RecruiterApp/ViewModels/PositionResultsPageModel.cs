using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruiterApp
{
	public class PositionResultsPageModel
	{
        public PositionResultsPageModel() { }//used to test creation of the model


        private ItemManager manager = ItemManager.DefaultManager;
        public Position positions { get; set; }
        //    { get {
        //        return positions;
        //    }
        //    set {
        //        positions = value;
        //        //GetCandidates();
        //    }
        //}

		public List<Candidate> Candidates { get; set; }
        //{
        //    //Testing for monica
        //    get {
        //        //return await manager.GetCandidatesForPositionAsync();
        //        return Candidates;
        //        }
        //    set {
        //        Candidates = value;
        //    }
            
        //  }

            //public PositionResultsPageModel() {
            //    GetCandidates();
            //}

        public async Task GetCandidates() {
            var candidates = await manager.GetCandidatesForPositionAsync(positions);
            Candidates = new List<Candidate>(candidates);
        }
    }
}

