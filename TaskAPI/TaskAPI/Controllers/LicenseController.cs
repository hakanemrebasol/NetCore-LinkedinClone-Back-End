using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity;
using Shared.Entity.Accomplishments;
using Shared.Entity.License;
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
    public class LicenseController : ControllerBase
    {
        private IUserLicenseRepository _uLicenseRepo;
        public LicenseController(IUserLicenseRepository uLicenseRepo)
        {
            _uLicenseRepo = uLicenseRepo;
        }

        [HttpPost("AddUserLicense")]
        public IActionResult AddUserLicense(UserLicense userLicense)
        {
            userLicense.userId = this.User.GetUserId();
            _uLicenseRepo.AddUserLicense(userLicense);
            return Ok();
        }

        [HttpPut("UpdateUserLicense")]
        public IActionResult UpdateUserLicense(UserLicense userLicense)
        {
            userLicense.userId = this.User.GetUserId();
            _uLicenseRepo.UpdateUserLicense(userLicense);
            return Ok();
        }

        [HttpDelete("DeleteUserLicense")]
        public IActionResult DeleteUserLicense(int userLicenseId)
        {
            _uLicenseRepo.RemoveUserLicense(this.User.GetUserId(), userLicenseId);
            return Ok();
        }

        [HttpGet("GetUserLicenses")]
        public IActionResult GetUserLicenses()
        {
            return Ok(_uLicenseRepo.GetUserLicenses(this.User.GetUserId()));
        }

    }
}
