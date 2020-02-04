using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskDAL.IRepository;
using Shared.Models.ViewModels;

namespace TaskAPI.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class AuthenticationController : ControllerBase {
        private ITokenRepository _tokenRepo;
        private IUserRepository _userRepo;

        public AuthenticationController (ITokenRepository tokenRepo,
            IUserRepository userRepo
        ) {
            _tokenRepo = tokenRepo;
            _userRepo = userRepo;
        }

        [AllowAnonymous]
        [HttpPost ("register")]
        [Consumes ("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Register ([FromForm]UserModel user) {
            /*var UserExists = _userRepo.UserExists (user.Email);
            if (UserExists) {
                return BadRequest (new ResponseModel {
                    status = 0,
                        message = "emailExists"
                });
            }

            var ifPhoneExists = _userRepo.PhoneExists (user.PhoneNumber);
            if (ifPhoneExists) {
                return BadRequest (new ResponseModel {
                    status = 0,
                        message = "phoneExists"
                });
            }*/

            var a = await _userRepo.RegisterUser (user);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost ("authenticate")]
        [Consumes ("application/x-www-form-urlencoded")]
        public async Task<IActionResult> Token ([FromForm] LoginModel loginModel) {

            Console.Write(loginModel.Username);
            Console.Write(loginModel.Password);
            var user = await _tokenRepo.Authenticate (loginModel.Username, loginModel.Password);
            if (user == null) {
                return BadRequest();
            }
            return Ok (user);
        }

       /* [AllowAnonymous]
        [HttpPost ("refreshToken")]
        [Consumes ("application/x-www-form-urlencoded")]
        public IActionResult RefreshToken ([FromForm] string refreshToken) {
            var user = _tokenRepo.AuthenticateWithRefreshToken (refreshToken);
            if (user == null) {
                return Unauthorized (new ResponseModel {
                    status = 0,
                    message = "tokenExpired"
                });
            }
            return Ok (user);
        }*/
    }
}