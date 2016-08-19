using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class Status
	{
		int id;
		string name;
		string description;

		[JsonProperty(PropertyName = "StatusId")]
		public int StatusId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "StatusName")]
		public string StatusName { get { return this.name; } set { this.name = value; } }

		[JsonProperty(PropertyName = "StatusDescription")]
		public string StatusDescription { get { return this.description; } set { this.description = value; } }
	}
}

