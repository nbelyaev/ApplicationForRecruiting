using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class Skill : EntityData {
		//int id;
		//string name;

		//[JsonProperty(PropertyName = "SkillId")]
		//public int SkillId { get; set; } //{ get { return this.id; } set { this.id = value; } }

		//[JsonProperty(PropertyName = "SkillName")]
		public string SkillName { get; set; } //{ get { return this.name; } set { this.name = value; } }
    }
}

