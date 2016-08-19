using Microsoft.Azure.Mobile.Server;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace CodeFirstAppService.DataObjects {
	public class Candidate : EntityData {
		public Candidate()
		{
		}

		//public int CandidateId { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string email { get; set; }
		public string street { get; set; }
		public string street2 { get; set; }
		public string city { get; set; }
		public string zip { get; set; }

		//public int StateId { get; set; }
        public virtual State State { get; set; }

        //public int RecruiterId { get; set; }
        public virtual User Recruiter { get; set; }

		//public int SourceId { get; set; }
        public virtual Source Source { get; set; }

        
        //public DateTime creationTime { get; set; }
		public bool hasResume { get; set; }
		public string candidateInfoNotes { get; set; }

		//public string RecommenderId { get; set; }
        public virtual User Recommender { get; set; }

        public bool hasCompletedApplication { get; set; }
		public bool hasDetailsAndReferences { get; set; }
		public bool hasCompletedAdp { get; set; }
		public string completedApplicationComments { get; set; }
		public string detailsAndReferencesComments { get; set; }
		public string verbalOfferComments { get; set; }
		public string formalOfferComments { get; set; }
		public string clearedBackgroundComments { get; set; }
		public string sogetiResumeComments { get; set; }
	}
}

