using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class InterviewAssign
	{
		int interviewerId;
		int interviewId;

		[JsonProperty(PropertyName = "InterviewAssignInterviewerId")]
		public int InterviewAssignInterviewerId { get { return this.interviewerId; } set { this.interviewerId = value; } }

		[JsonProperty(PropertyName = "InterviewAssignInterviewId")]
		public int InterviewAssignInterviewId { get { return this.interviewId; } set { this.interviewId = value; } }
	}
}

