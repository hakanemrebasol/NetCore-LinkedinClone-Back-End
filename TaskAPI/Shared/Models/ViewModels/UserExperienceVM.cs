using Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.ViewModels
{
    public class UserExperienceVM
    {
        public Company Company { get; set; }

        public List<UserExperience> UserExperience { get; set; }
    }
}
