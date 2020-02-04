using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Entity.Skill
{
    public class UserSkill
    {
        public int userSkillId { get; set; }
        public int skillId { get; set; }
        [ForeignKey("skillId")]
        public virtual Skill Skill { get; set; }
        public string userId { get; set; }
        [ForeignKey("userId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
