using System.Linq;
using TaskDAL.IRepository;
using TaskDAL.Context;
using System.Collections.Generic;
using Shared.Entity.Skill;
using Shared.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TaskDAL.Repository
{
    public class UserSkillRepository : GenericRepository<UserSkill>, IUserSkillRepository {
        private readonly DatabaseContext _db;
        public UserSkillRepository(DatabaseContext db):base(db) {
            _db = db;
        }

        public void AddUserSkill(UserSkill userSkill)
        {
            Insert(userSkill);
            Save();
        }

        public void RemoveUserSkill(string userId, int skillId)
        {
            var userSkill = GetAll().Where(a => a.userId.Equals(userId) && a.skillId == skillId).FirstOrDefault();
            Delete(userSkill.userSkillId);
            Save();
        }

        public List<UserSkillVM> GetAllUserSkills(string userId)
        {
            return _db.Skills.Select(a => new UserSkillVM
            {
                skillId = a.skillId,
                skillName = a.skillName,
                isSelected = _db.UserSkills.Where(x=>x.userId.Equals(userId) && x.skillId == a.skillId).FirstOrDefault() == null? false:true
            }).ToList();
        }

        public List<UserSkillVM> GetUserSkills(string userId)
        {
            return _db.UserSkills.Include(x=>x.Skill).Where(item=>item.userId.Equals(userId)).Select(a => new UserSkillVM
            {
                skillId = a.skillId,
                skillName = a.Skill.skillName,
            }).ToList();
        }
    }
}