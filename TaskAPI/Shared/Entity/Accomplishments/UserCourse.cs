using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity.Accomplishments
{
    public class UserCourse
    {
        [Key]
        public int projectId { get; set; }
        public string projectName { get; set; }
        public bool currentlyWorking { get; set; }
        public string description { get; set; }
        public DateTime projectStartDate { get; set; }
        public DateTime? projectEndDate { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
