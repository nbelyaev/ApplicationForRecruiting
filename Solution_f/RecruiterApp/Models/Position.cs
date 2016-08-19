using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RecruiterApp {
    public class Position {
        string id;
        string name;
        string description;
        //bool deleted;

        [JsonProperty(PropertyName = "id")]
        public string Id {
            get { return id; }
            set { id = value; }
        }

        //[JsonProperty(PropertyName = "positionname")]
        [JsonProperty(PropertyName = "name")]
        public string Name {
            get { return name; }
            set { name = value; }
        }

        //[JsonProperty(PropertyName = "positiondescription")]
        [JsonProperty(PropertyName = "description")]
        public string Description {
            get { return description; }
            set { description = value; }
        }

        //[JsonProperty(PropertyName = "deleted")]
        //public bool Deleted {
        //    get { return deleted; }
        //    set { deleted = value; }
        //}


        [Version]
        public string Version { get; set; }
    }
}
