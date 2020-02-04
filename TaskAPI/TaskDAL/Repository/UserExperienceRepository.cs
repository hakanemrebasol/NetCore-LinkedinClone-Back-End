using System.Linq;
using TaskDAL.IRepository;
using TaskDAL.Context;
using System.Collections.Generic;
using Shared.Entity;
using Microsoft.EntityFrameworkCore;

namespace TaskDAL.Repository
{
    public class UserExperienceRepository : GenericRepository<UserExperience>, IUserExperienceRepository {
        private readonly DatabaseContext _db;
        public UserExperienceRepository(DatabaseContext db):base(db) {
            _db = db;
        }

        public void AddUserExperience(UserExperience userExperience)
        {
            Insert(userExperience);
            Save();
        }

        public void UpdateUserExperience(UserExperience userExperience)
        {
            Update(userExperience);
            Save();
        }
        public void DeleteUserExperience(int userExperienceId)
        {
            Delete(userExperienceId);
            Save();
        }


        public List<UserExperience> GetUserExperiences(string userId)
        {
            return GetTable().Include(a=>a.Company)
                .Where(b => b.userId.Equals(userId))
                .Select(a => new UserExperience
                {
                    Company = a.Company,
                    companyId = a.companyId,
                    description = a.description,
                    endDate = a.endDate,
                    startDate = a.startDate,
                    experienceId = a.experienceId,
                    location = a.location,
                    title = a.title,
                }).OrderByDescending(a => a.companyId).ToList();
        }

    }
}