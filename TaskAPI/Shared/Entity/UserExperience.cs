using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity
{
    public class UserExperience
    {
        [Key]
        public int experienceId { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public DateTime startDate { get; set; }
        public DateTime? endDate { get; set; }
        public string description { get; set; }
        public int companyId { get; set; }
        [ForeignKey("companyId")]
        public virtual Company Company { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
