using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class PositionSkill : EntityData {
		//int positionId;
		//int skillId;

		//[JsonProperty(PropertyName = "PositionId")]
		//public int PositionId { get; set; } //{ get { return this.positionId; } set { this.positionId = value; } }
        public virtual Position Position { get; set; }
        //[JsonProperty(PropertyName = "SkillId")]
        //public int SkillId { get; set; }//{ get { return this.skillId; } set { this.skillId = value; } }
        public virtual Skill Skill { get; set; }
    }
}

