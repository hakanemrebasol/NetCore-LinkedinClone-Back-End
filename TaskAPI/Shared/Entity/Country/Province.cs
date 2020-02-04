using System.ComponentModel.DataAnnotations;

namespace Shared.Entity.Country
{
    public class Province
    {
        [Key]
        public int provinceId { get; set; }
        public string provinceName { get; set; }

    }
}
