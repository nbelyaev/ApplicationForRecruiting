using System;
using Newtonsoft.Json;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
	public class User : EntityData {
		
        public string UserFirstName { get; set; } 
        public string UserLastName { get; set; }


        ////add username
        //public string Username { get; set; }

        ////add salted hash of the password
        //public string PasswordHash { get; set; }
        //public string Salt { get; set; }



    }
}

