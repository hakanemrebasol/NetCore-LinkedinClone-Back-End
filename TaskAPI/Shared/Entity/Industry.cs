using System.ComponentModel.DataAnnotations;

namespace Shared.Entity
{
    public class Industry
    {
        [Key]
        public int industryId { get; set; }
        public string industryName { get; set; }
    }
}
