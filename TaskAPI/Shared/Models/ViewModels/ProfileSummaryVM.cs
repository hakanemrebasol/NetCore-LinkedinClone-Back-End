using Shared.Entity.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.ViewModels
{
    public class ProfileSummaryVM
    {
        public string id { get; set; }
        public string fullName { get; set; }
        public string headline { get; set; }
        public string about { get; set; }
        public string website { get; set; }
        public Province Province {get;set;}
        public District District {get;set;}

    }
}
