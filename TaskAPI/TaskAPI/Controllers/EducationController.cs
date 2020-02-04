using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.Education;
using SharedFiles.Entities;
using System;
using System.IO;
using TaskDAL.Helpers;
using TaskDAL.IRepository;

namespace TaskAPI.Controllers
{
    [Authorize(Roles = Roles.User)]
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private IUserEducationRepository _uEducationRepo;
        private IWebHostEnvironment _env;
        public EducationController(IUserEducationRepository uEducationRepo, IWebHostEnvironment env)
        {
            _uEducationRepo = uEducationRepo;
            _env = env;
        }

        [HttpPost("AddUserEducation")]
        public IActionResult AddUserEducation(UserEducation userEducation)
        {
            userEducation.userId = this.User.GetUserId();
            _uEducationRepo.AddUserEducation(userEducation);
            return Ok();
        }

        [HttpPut("UpdateUserEducation")]
        public IActionResult UpdateUserEducation(UserEducation userEducation)
        {
            userEducation.userId = this.User.GetUserId();
            _uEducationRepo.UpdateUserEducation(userEducation);
            return Ok();
        }

        [HttpDelete("DeleteUserEducation/{userEducationId}")]
        public IActionResult DeleteUserEducation(int userEducationId)
        {
            _uEducationRepo.DeleteUserEducation(userEducationId);
            return Ok();
        }

        [HttpGet("GetUserEducations")]
        public IActionResult GetUserEducations()
        {
            return Ok(_uEducationRepo.GetUserEducations(this.User.GetUserId()));
        }

        [HttpGet("GetEducationImage")]
        public IActionResult GetEducationImage(int educationId)
        {
            var educationPath = Path.Combine(_env.ContentRootPath, "img", "education");

            var filePath = Path.Combine(educationPath, educationId.ToString() + ".png");
            FileStream file;
            try
            {
                file = System.IO.File.OpenRead(filePath);
            }
            catch (Exception)
            {
                file = null;
            }

            if (file == null)
            {
                return NotFound();
            }
            return File(file, "image/png");
        }

    }
}
