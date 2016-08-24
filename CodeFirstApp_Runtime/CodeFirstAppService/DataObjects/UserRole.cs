using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CodeFirstAppService.DataObjects {
	public class UserRole : EntityData {
		//int id;
		//int roleId;

		//[JsonProperty(PropertyName = "UserId")]
		//public int UserId { get; set; } //{ get { return this.id; } set { this.id = value; } }
        //[Key]
        public virtual User User { get; set; } 
        //[JsonProperty(PropertyName = "UserRoleId")]
        //public int RoleId { get; set; } //{ get { return this.roleId; } set { this.roleId = value; } }
        public virtual Role Role { get; set; }
    }
}

