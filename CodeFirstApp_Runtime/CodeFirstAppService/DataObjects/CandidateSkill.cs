using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class CandidateSkill : EntityData {
		//int candidateId;
		//int skillId;

		//[JsonProperty(PropertyName = "CandidateId")]
		//public int CandidateId { get { return this.candidateId; } set { this.candidateId = value; } }
        public virtual Candidate Candidate { get; set; }
        //[JsonProperty(PropertyName = "SkillId")]
        //public int SkillId { get { return this.skillId; } set { this.skillId = value; } }
        public virtual Skill Skill { get; set; }
    }
}

