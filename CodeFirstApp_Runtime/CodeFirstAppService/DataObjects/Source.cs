using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class Source : EntityData {
		//int id;
		//string name;

		//[JsonProperty(PropertyName = "SourceId")]
		//public int SourceId { get; set; } //{ get { return this.id; } set { this.id = value; } }

        //[JsonProperty(PropertyName = "SourceName")]
        public string SourceName { get; set; } //{ get { return this.name; } set { this.name = value; } }
    }
}

