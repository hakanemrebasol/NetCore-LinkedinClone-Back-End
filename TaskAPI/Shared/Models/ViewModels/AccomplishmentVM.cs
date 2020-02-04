using Shared.Entity.Accomplishments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.Models.ViewModels
{
    public class AccomplishmentVM
    {
        public List<UserCourse> UserCourses {get;set; }
        public List<UserProject> UserProjects {get;set; }
    }
}
