using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Entity;
using Shared.Models.ViewModels;

namespace TaskDAL.IRepository {
    public interface IUserRepository {
        Task<IdentityResult> RegisterUser (UserModel userModel);
        UserModel FindUserbyId (string id);
        Task<ApplicationUser> FindByEmailAsync (string mail);
        Task<UserModel> FindUserByUserName (string name);
        bool PhoneExists (string phone);
        Task<IdentityResult> ChangePassword (string userId, string oldPassword, string newPassword);
        Task<IdentityResult> UpdateUser (string userId, UpdateProfileModel updateProfileModel);
        Task UpdateUserAbout (string userId, UpdateAboutVM updateAbout);
        bool UserExists (string email);
        Task<bool> CheckPassword (ApplicationUser applicationUser, string password);
        ProfileSummaryVM GetProfileSummary (string userId);
        bool saveProfilePicture(IFormFile image, string userId);

        FileStream getProfilePicture(string userId);

    }
}