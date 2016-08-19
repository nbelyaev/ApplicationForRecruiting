using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class CandidateSkill
	{
		int candidateId;
		int skillId;

		[JsonProperty(PropertyName = "CandidateId")]
		public int CandidateId { get { return this.candidateId; } set { this.candidateId = value; } }

		[JsonProperty(PropertyName = "SkillId")]
		public int SkillId { get { return this.skillId; } set { this.skillId = value; } }
	}
}

