using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class CandidateStatus
	{
		int candidateId;
		int statusId;
		int userId;
		string notes;

		[JsonProperty(PropertyName = "CandidateId")]
		public int CandidateId { get { return this.candidateId; } set { this.candidateId = value; } }

		[JsonProperty(PropertyName = "StatusId")]
		public int StatusId { get { return this.statusId; } set { this.statusId = value; } }

		[JsonProperty(PropertyName = "UserId")]
		public int UserId { get { return this.userId; } set { this.userId = value; } }

		[JsonProperty(PropertyName = "CandidateStatusNotes")]
		public string CandidateStatusNotes { get { return this.notes; } set { this.notes = value; } }

	}
}

