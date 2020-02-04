using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.Accomplishments;
using Shared.Models.ViewModels;
using SharedFiles.Entities;
using TaskDAL.Helpers;
using TaskDAL.IRepository;

namespace TaskAPI.Controllers
{
    [Authorize(Roles = Roles.User)]
    [ApiController]
    [Route("api/[controller]")]
    public class AccomplishmentsController : ControllerBase
    {
        private IProjectRepository _projectRepo;
        private ICourseRepository _courseRepo;
        public AccomplishmentsController(IProjectRepository projectRepo,ICourseRepository courseRepo)
        {
            _projectRepo = projectRepo;
            _courseRepo = courseRepo;
        }

        [HttpPost("AddUserProject")]
        public IActionResult AddUserProject(UserProject userProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _projectRepo.AddUserProject(userProject);
            return Ok();
        }

        [HttpPost("AddUserCourse")]
        public IActionResult AddUserCourse(UserCourse userCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courseRepo.AddUserCourse(userCourse);
            return Ok();
        }

        [HttpPost("UserAccomplishments")]
        public IActionResult UserAccomplishments()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(new AccomplishmentVM
            {
                UserCourses = _courseRepo.GetUserCourses(this.User.GetUserId()),
                UserProjects = _projectRepo.GetUserProjects(this.User.GetUserId())
            });
        }

        [HttpPut("UpdateUserProject")]
        public IActionResult UpdateUserProject(UserProject userProject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _projectRepo.UpdateProject(userProject);
            return Ok();
        }

        [HttpPut("UpdateUserCourse")]
        public IActionResult UpdateUserCourse(UserCourse userCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courseRepo.UpdateCourse(userCourse);
            return Ok();
        }

        [HttpDelete("DeleteUserCourse/{id}")]
        public IActionResult DeleteUserCourse(int id)
        {
            _courseRepo.Delete(id);
            return Ok();
        }

        [HttpDelete("DeleteUserProject/{id}")]
        public IActionResult DeleteUserProject(int id)
        {
            _projectRepo.Delete(id);
            return Ok();
        }
    }
}
