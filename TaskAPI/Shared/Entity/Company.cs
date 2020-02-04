using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Entity
{
    public class Company
    {
        [Key]
        public int companyId { get; set; }
        public string companyName { get; set; }
    }
}
