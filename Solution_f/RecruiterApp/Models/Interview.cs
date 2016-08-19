using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class Interview
	{
		int id;
		int candidateId;
		int interviewTypeId;
		string comments;
		double rating;
		DateTime dateOfInterview;

		[JsonProperty(PropertyName = "InterviewId")]
		public int InterviewId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "InterviewCandidateId")]
		public int InterviewCandidateId { get { return this.candidateId; } set { this.candidateId = value; } }

		[JsonProperty(PropertyName = "InterviewTypeId")]
		public int InterviewTypeId { get { return this.interviewTypeId; } set { this.interviewTypeId = value; } }

		[JsonProperty(PropertyName = "InterviewComments")]
		public string InterviewComments { get { return this.comments; } set { this.comments = value; } }

		[JsonProperty(PropertyName = "InterviewRating")]
		public double InterviewRating { get { return this.rating; } set { this.rating = value; } }

		[JsonProperty(PropertyName = "InterviewDateOfInterview")]
		public DateTime InterviewDateOfInterview { get { return this.dateOfInterview; } set { this.dateOfInterview = value; } }
	}
}

