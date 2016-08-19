using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class InterviewType : EntityData {
		//int id;
		//string name;

		//[JsonProperty(PropertyName = "Typed")]
		//public int TypeId { get; set; } //{ get { return this.id; } set { this.id = value; } }

        //[JsonProperty(PropertyName = "TypeName")]
        public string TypeName { get; set; } //{ get { return this.name; } set { this.name = value; } }
    }
}

