using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class Status : EntityData {
		//int id;
		//string name;
		//string description;

		//[JsonProperty(PropertyName = "StatusId")]
		//public int StatusId { get; set; } //{ get { return this.id; } set { this.id = value; } }

        //[JsonProperty(PropertyName = "StatusName")]
        public string StatusName { get; set; } //{ get { return this.name; } set { this.name = value; } }

        //[JsonProperty(PropertyName = "StatusDescription")]
        public string StatusDescription { get; set; } //{ get { return this.description; } set { this.description = value; } }
    }
}

