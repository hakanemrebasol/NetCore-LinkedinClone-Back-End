using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity.License
{
    public class License
    {
        public int licenseId { get; set; }
        public string licenseName { get; set; }
        public int companyId { get; set; }
        [ForeignKey("companyId")]
        public virtual Company Company { get; set; }
    }
}
