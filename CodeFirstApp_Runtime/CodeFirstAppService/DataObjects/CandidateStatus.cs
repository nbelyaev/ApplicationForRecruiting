using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class CandidateStatus : EntityData {
		//int candidateId;
		//int statusId;
		//int userId;
		//string notes;

		//[JsonProperty(PropertyName = "CandidateId")]
		//public int CandidateId { get; set; } //{ get { return this.candidateId; } set { this.candidateId = value; } }
        public virtual Candidate Candidate { get; set; }
        //[JsonProperty(PropertyName = "StatusId")]
        //public int StatusId { get; set; }  //{ get { return this.statusId; } set { this.statusId = value; } }
        public virtual Status Status { get; set; }
        //[JsonProperty(PropertyName = "UserId")]
        //public int SetById { get; set; } //{ get { return this.userId; } set { this.userId = value; } }
        public virtual User SetBy { get; set; }
        //[JsonProperty(PropertyName = "CandidateStatusNotes")]
        public string CandidateStatusNotes { get; set; } //{ get { return this.notes; } set { this.notes = value; } }

    }
}

