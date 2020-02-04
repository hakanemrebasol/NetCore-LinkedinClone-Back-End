using Microsoft.AspNetCore.Identity;
using Shared.Entity.Country;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity {
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string headline { get; set; }
        public string about { get; set; }
        public string CountryCode { get; set; }
        public string webSite { get; set; }
        public DateTime birthDate { get; set; }
        public string address { get; set; }
        public string ZIPCode { get; set; }

        public int? provinceId { get; set; }
        [ForeignKey("provinceId")]
        public virtual Province Province { get; set; }

        public int? districtId { get; set; }
        [ForeignKey("districtId")]
        public virtual District District { get; set; }

        public int? industryId { get; set; }
        [ForeignKey("industryId")]
        public virtual Industry Industry { get; set; }
    }
}