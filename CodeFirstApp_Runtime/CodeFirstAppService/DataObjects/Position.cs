using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace CodeFirstAppService.DataObjects {
    public class Position : EntityData {
        //public int PositionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}