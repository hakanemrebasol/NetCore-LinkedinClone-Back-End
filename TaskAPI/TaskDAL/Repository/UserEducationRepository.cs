using System.Linq;
using TaskDAL.IRepository;
using TaskDAL.Context;
using System.Collections.Generic;
using Shared.Entity.Skill;
using Shared.Entity.Education;
using Microsoft.EntityFrameworkCore;

namespace TaskDAL.Repository
{
    public class UserEducationRepository : GenericRepository<UserEducation>, IUserEducationRepository {
        private readonly DatabaseContext _db;
        public UserEducationRepository(DatabaseContext db):base(db) {
        }

        public void AddUserEducation(UserEducation userEducation)
        {
            Insert(userEducation);
            Save();
        }

        public List<UserEducation> GetUserEducations(string userId)
        {
            return GetTable().Include(a=>a.Education).Where(a => a.userId.Equals(userId)).OrderByDescending(a=>a.endDate).ToList();
        }

        public void DeleteUserEducation(int userEducationId)
        {
            Delete(userEducationId);
            Save();
        }

        public void UpdateUserEducation(UserEducation userEducation)
        {
            Update(userEducation);
            Save();
        }
    }
}