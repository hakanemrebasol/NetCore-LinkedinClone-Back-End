using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity;
using Shared.Entity.Accomplishments;
using Shared.Entity.Skill;
using Shared.Models.ViewModels;
using SharedFiles.Entities;
using System.Linq;
using TaskDAL.Context;
using TaskDAL.Helpers;
using TaskDAL.IRepository;

namespace TaskAPI.Controllers
{
    [Authorize(Roles = Roles.User)]
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : ControllerBase
    {
        private IUserSkillRepository _skillRepo;
        public SkillController(IUserSkillRepository skillRepo)
        {
            _skillRepo = skillRepo;
        }

        [HttpPost("AddUserSkill/{skillId}")]
        public IActionResult AddUserSkill(int skillId)
        {
            UserSkill userSkill = new UserSkill
            {
                userId = this.User.GetUserId(),
                skillId = skillId,             
            };

            _skillRepo.AddUserSkill(userSkill);
            return Ok();
        }

        [HttpDelete("DeleteUserSkill/{skillId}")]
        public IActionResult RemoveUserSkill(int skillId)
        {
            _skillRepo.RemoveUserSkill(this.User.GetUserId(), skillId);
            return Ok();
        }

        [HttpGet("GetAllUserSkills")]
        public IActionResult GetAllUserSkills()
        {
            return Ok(_skillRepo.GetAllUserSkills(this.User.GetUserId()));
        }


        [HttpGet("GetUserSkills")]
        public IActionResult GetUserSkills()
        {
            return Ok(_skillRepo.GetUserSkills(this.User.GetUserId()));
        }
    }
}
