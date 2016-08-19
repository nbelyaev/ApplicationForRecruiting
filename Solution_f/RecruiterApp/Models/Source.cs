using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class Source
	{
		int id;
		string name;

		[JsonProperty(PropertyName = "SourceId")]
		public int SourceId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "SourceName")]
		public string SourceName { get { return this.name; } set { this.name = value; } }
	}
}

