using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class Role : EntityData {
		//int id;
		//string name;

		//[JsonProperty(PropertyName = "RoleId")]
		//public int RoleId { get; set; }//{ get { return this.id; } set { this.id = value; } }

		//[JsonProperty(PropertyName = "RoleName")]
		public string RoleName { get; set; } //{ get { return this.name; } set { this.name = value; } }
	}
}

