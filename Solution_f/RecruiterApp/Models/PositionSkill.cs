using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class PositionSkill
	{
		int positionId;
		int skillId;

		[JsonProperty(PropertyName = "PositionId")]
		public int PositionId { get { return this.positionId; } set { this.positionId = value; } }

		[JsonProperty(PropertyName = "SkillId")]
		public int SkillId { get { return this.skillId; } set { this.skillId = value; } }
	}
}

