using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity
{
    public class Publication
    {
        [Key]
        public int publicationId { get; set; }
        public string publisherName { get; set; }
        public DateTime publishDate { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
