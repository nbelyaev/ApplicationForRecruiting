using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class Interview : EntityData {
		//int id;
		//int candidateId;
		//int interviewTypeId;
		//string comments;
		//double rating;
		//DateTime dateOfInterview;

		//[JsonProperty(PropertyName = "InterviewId")]
		//public int InterviewId //{ get { return this.id; } set { this.id = value; } }

		//[JsonProperty(PropertyName = "InterviewCandidateId")]
		//public int InterviewCandidateId { get; set; }//{ get { return this.candidateId; } set { this.candidateId = value; } }
        public virtual Candidate InterviewCandidate { get; set; }
        //[JsonProperty(PropertyName = "InterviewTypeId")]
        //public int InterviewTypeId { get; set; }//{ get { return this.interviewTypeId; } set { this.interviewTypeId = value; } }
        public virtual InterviewType InterviewType { get; set; }
        //[JsonProperty(PropertyName = "InterviewComments")]
        public string InterviewComments { get; set; }//{ get { return this.comments; } set { this.comments = value; } }

        //[JsonProperty(PropertyName = "InterviewRating")]
        public double InterviewRating { get; set; }//{ get { return this.rating; } set { this.rating = value; } }

        //[JsonProperty(PropertyName = "InterviewDateOfInterview")]
        public DateTime InterviewDateOfInterview { get; set; }//{ get { return this.dateOfInterview; } set { this.dateOfInterview = value; } }
    }
}

