using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.ViewModels
{
    public class UpdateProfileModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string about { get; set; }
        public string headline { get; set; }
        public string website { get; set; }
        public DateTime birthDate { get; set; }
        public string address { get; set; }
        public string zipCode { get; set; }
        public int provinceId { get; set; }
        public int districtId { get; set; }
        public int industryId { get; set; }
    }
}
