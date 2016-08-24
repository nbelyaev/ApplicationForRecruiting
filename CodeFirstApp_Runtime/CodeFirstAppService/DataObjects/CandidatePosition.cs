using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class CandidatePosition : EntityData {
		//int id;
		//int positionId;

		//[JsonProperty(PropertyName = "CandidatePositionId")]
		public string CandidateId { get; set; } //{ get { return this.id; } set { this.id = value; } }
        public virtual Candidate Candidate { get; set; }
        //[JsonProperty(PropertyName = "PositionId")]
        public string PositionId { get; set; }//{ get { return this.positionId; } set { this.positionId = value; } }
        public virtual Position Position { get; set; }
    }
}

