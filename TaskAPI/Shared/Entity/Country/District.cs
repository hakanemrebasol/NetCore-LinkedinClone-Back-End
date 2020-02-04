using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Entity.Country
{
    public class District
    {
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int provinceId { get; set; }
        [ForeignKey("provinceId")]
        public virtual Province Province { get; set; }
    
    }
}
