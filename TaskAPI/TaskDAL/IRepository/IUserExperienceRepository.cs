using Shared.Entity;
using Shared.Entity.License;
using Shared.Entity.Skill;
using System.Collections.Generic;

namespace TaskDAL.IRepository
{
    public interface IUserExperienceRepository: IGenericRepository<UserExperience>
    {
        void AddUserExperience(UserExperience userExperience);
        void UpdateUserExperience(UserExperience userExperience);
        void DeleteUserExperience(int userExperienceId);
        List<UserExperience> GetUserExperiences(string userId);
    }
}