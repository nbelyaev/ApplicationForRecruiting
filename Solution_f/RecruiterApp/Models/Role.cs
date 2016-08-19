using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class Role
	{
		int id;
		string name;

		[JsonProperty(PropertyName = "RoleId")]
		public int RoleId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "RoleName")]
		public string RoleName { get { return this.name; } set { this.name = value; } }
	}
}

