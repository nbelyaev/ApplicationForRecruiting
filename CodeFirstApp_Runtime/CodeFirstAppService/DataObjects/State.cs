﻿using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class State : EntityData {
		//int id;
		//string name;

		//[JsonProperty(PropertyName = "StateId")]
		//public int StateId { get; set; } //{ get { return this.id; } set { this.id = value; } }

        //[JsonProperty(PropertyName = "StateName")]
        public string StateAbbreviation { get; set; } //{ get { return this.name; } set { this.name = value; } }
    }
}
