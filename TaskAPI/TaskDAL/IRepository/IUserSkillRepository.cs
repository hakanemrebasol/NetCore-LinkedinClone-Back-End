using Shared.Entity.License;
using Shared.Entity.Skill;
using Shared.Models.ViewModels;
using System.Collections.Generic;

namespace TaskDAL.IRepository
{
    public interface IUserSkillRepository: IGenericRepository<UserSkill>
    {
        void AddUserSkill(UserSkill userSkill);
        void RemoveUserSkill(string userId, int skillId);
        List<UserSkillVM> GetAllUserSkills(string userId);
        List<UserSkillVM> GetUserSkills(string userId);
    }
}