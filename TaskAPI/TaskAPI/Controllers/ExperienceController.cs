using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity;
using Shared.Entity.Accomplishments;
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
    public class ExperienceController : ControllerBase
    {
        private IUserExperienceRepository _experienceRepo;
        private DatabaseContext _db;
        public ExperienceController(DatabaseContext db, IUserExperienceRepository experienceRepo)
        {
            _db = db;
            _experienceRepo = experienceRepo;
        }

        [HttpPost("AddUserExperience")]
        public IActionResult AddUserExperience(UserExperience userExperience)
        {
            userExperience.userId = this.User.GetUserId();
            _experienceRepo.AddUserExperience(userExperience);
            return Ok();
        }

        [HttpPut("UpdateUserExperience")]
        public IActionResult UpdateUserExperience(UserExperience userExperience)
        {
            userExperience.userId = this.User.GetUserId();
            _experienceRepo.UpdateUserExperience(userExperience);
            return Ok();
        }

        [HttpDelete("DeleteUserExperience/{userExperienceId}")]
        public IActionResult DeleteUserExperience(int userExperienceId)
        {
            _experienceRepo.DeleteUserExperience(userExperienceId);
            return Ok();
        }

        [HttpGet("UserExperiences")]
        public IActionResult UserExperiences()
        {
            return Ok(_experienceRepo.GetUserExperiences(this.User.GetUserId()));
        }
    }
}
