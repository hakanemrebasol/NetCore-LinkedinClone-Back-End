using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.ViewModels;
using SharedFiles.Entities;
using System.Threading.Tasks;
using TaskDAL.Context;
using TaskDAL.Helpers;
using TaskDAL.IRepository;

namespace TaskAPI.Controllers
{
    [Authorize(Roles = Roles.User)]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private IUserRepository _userRepo;
        private DatabaseContext _db;
        public ProfileController(DatabaseContext db, IUserRepository userRepo)
        {
            _db = db;
            _userRepo = userRepo;
        }

        [HttpGet("ProfileSummary")]
        public IActionResult ProfileSummary()
        {
           return Ok(_userRepo.GetProfileSummary(this.User.GetUserId()));
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(_userRepo.FindUserbyId(this.User.GetUserId()));
        }

        [AllowAnonymous]
        [HttpGet("GetProfilePicture/{userId}")]
        public IActionResult ProfilePicture(string userId)
        {
            var image = _userRepo.getProfilePicture(userId);
            if (image == null)
            {
                return NotFound();
            }
            return File(image, "image/png");
        }

        [AllowAnonymous]
        [HttpPost("UploadPP")]
        public IActionResult UploadPP()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var file = HttpContext.Request.Form.Files.Count > 0 ?
                HttpContext.Request.Form.Files[0] : null;

            var fileSize = file.Length;

            if (fileSize > 2100000)
            {
                return Forbid();
            }

            bool saveStatus = _userRepo.saveProfilePicture(file, this.User.GetUserId());

            if (!saveStatus)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileModel updateProfileModel)
        {
            await _userRepo.UpdateUser(this.User.GetUserId(), updateProfileModel);
            return Ok();
        }

        [HttpPut("UpdateAbout")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutVM updateAbout)
        {
            await _userRepo.UpdateUserAbout(this.User.GetUserId(), updateAbout);
            return Ok();
        }

    }


}
