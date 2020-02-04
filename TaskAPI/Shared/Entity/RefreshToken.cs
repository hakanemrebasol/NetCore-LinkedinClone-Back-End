using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Entity;
namespace SharedFiles.Entities
{
    public class RefreshToken
    {
        public RefreshToken()
        {
            issueDate = DateTime.Now;
        }

        [Key]
        public int id { get; set; }
        public string userId { get; set; }
        public string refreshToken { get; set; }
        public bool revoked { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser ApplicationUser {get;set;}
        public DateTime issueDate { get; set; }
    }
}