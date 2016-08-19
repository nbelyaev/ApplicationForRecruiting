using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class UserRole
	{
		int id;
		int roleId;

		[JsonProperty(PropertyName = "UserId")]
		public int UserId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "UserRoleId")]
		public int UserRoleId { get { return this.roleId; } set { this.roleId = value; } }
	}
}

