using System;
using System.Collections.Generic;

namespace RecruiterApp
{
	public class PositionResultsPageModel
	{
		public Position positions { get; set; }
		public List<Candidate> Candidates 
		{ 
			//Testing for monica
			get 
			{
				return new List<Candidate>()
				{
					new Candidate {candidateId= 1, firstName="Monica", lastName="Kenar"},
					new Candidate {candidateId=2, firstName="Eric", lastName="Ruelas"},
					new Candidate {candidateId=3, firstName="Nikita", lastName="Belyaev"},
					new Candidate {candidateId=4, firstName="Cristian", lastName="Pintado"}
				};
			}
		}
	}
}

