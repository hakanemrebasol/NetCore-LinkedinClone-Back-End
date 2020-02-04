using System.ComponentModel.DataAnnotations;

namespace Shared.Entity.Skill
{
    public class Skill
    {
        [Key]
        public int skillId { get; set; }
        public string skillName { get; set; }
    }
}
