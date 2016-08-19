using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class Skill
	{
		int id;
		string name;

		[JsonProperty(PropertyName = "SkillId")]
		public int SkillId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "SkillName")]
		public string SkillName { get { return this.name; } set { this.name = value; } }
	}
}

