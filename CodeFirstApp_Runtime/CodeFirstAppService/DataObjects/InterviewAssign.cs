using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class InterviewAssign : EntityData {
		//int interviewerId;
		//int interviewId;

		//[JsonProperty(PropertyName = "InterviewAssignInterviewerId")]
		//public int InterviewAssignInterviewerId { get; set; } //{ get { return this.interviewerId; } set { this.interviewerId = value; } }
        public virtual User InterviewAssignInterviewer { get; set; }
        //[JsonProperty(PropertyName = "InterviewAssignInterviewId")]
        //public int InterviewAssignInterviewId { get; set; }//{ get { return this.interviewId; } set { this.interviewId = value; } }
        public virtual Interview InterviewAssignInterview { get; set; }
    }
}

