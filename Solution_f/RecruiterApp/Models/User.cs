using System;
using Newtonsoft.Json;
namespace RecruiterApp
{
	public class User
	{
		int id;
		string firstname;
		string lastname;

		[JsonProperty(PropertyName = "UserId")]
		public int UserId { get { return this.id; } set { this.id = value; } }

		[JsonProperty(PropertyName = "UserFirstName")]
		public string UserFirstName { get { return this.firstname; } set { this.firstname = value; } }

		[JsonProperty(PropertyName = "UserLastName")]
		public string UserLastName { get { return this.lastname; } set { this.lastname = value; } }
	}
}

