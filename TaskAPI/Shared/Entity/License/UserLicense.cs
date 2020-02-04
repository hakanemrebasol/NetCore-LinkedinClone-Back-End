using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity.License
{
    public class UserLicense
    {
        public int userLicenseId { get; set; }
        public bool canExpire { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime? expirationDate { get; set; }
        public int licenseId { get; set; }
        [ForeignKey("licenseId")]
        public virtual License License { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
}
