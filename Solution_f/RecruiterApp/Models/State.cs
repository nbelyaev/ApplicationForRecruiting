using System;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace RecruiterApp
{
	public class State
	{
		int id;
		string name;

		[JsonProperty(PropertyName = "StateId")]
		public int StateId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "StateName")]
		public string StateName { get { return this.name; } set { this.name = value; } }

        public virtual ICollection<Candidate> Candidate { get; set; }
    }
}

