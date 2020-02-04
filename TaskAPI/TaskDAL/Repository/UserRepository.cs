using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Shared.Entity;
using TaskDAL.IRepository;
using TaskDAL.Context;
using TaskDAL.Helpers;
using Shared.Models.ViewModels;
using SharedFiles.Entities;

namespace TaskDAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _env;
        private readonly string ppPath;

        public UserRepository(IOptions<AppSettings> appSettings,
            IConfiguration configuration,
            DatabaseContext db,
            IWebHostEnvironment env,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _configuration = configuration;
            _db = db;
            _env = env;
            ppPath = Path.Combine(_env.ContentRootPath, "img", "pp");
        }

        public async Task<ApplicationUser> FindByEmailAsync(string mail)
        {
            return await _userManager.FindByEmailAsync(mail);
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = userModel.Email,
                Email = userModel.Email,
                Name = userModel.Name,
                Surname = userModel.Surname,
                CountryCode = userModel.CountryCode,
                PhoneNumber = userModel.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<bool> CheckPassword(ApplicationUser applicationUser, string password)
        {
            return await _userManager.CheckPasswordAsync(applicationUser, password);
        }

        public UserModel FindUserbyId(string id)
        {
            return _db.ApplicationUsers.Where(a => a.Id.Equals(id)).Select(
            x=> new UserModel
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                Surname = x.Surname,
                PhoneNumber = x.PhoneNumber,
                CountryCode = x.CountryCode,
                about = x.about,
                headline = x.headline,
                Province = x.Province,
                District = x.District,
                Industry = x.Industry,
                ZIPCode = x.ZIPCode,
                address = x.address,
                website = x.webSite,
                birthDate = x.birthDate
        }).FirstOrDefault();         
        }
        public async Task<UserModel> FindUserByUserName(String name)
        {
            ApplicationUser currentUser = await _userManager.FindByNameAsync(name);
            UserModel userModel = new UserModel();

            userModel.UserName = currentUser.UserName;
            userModel.Name = currentUser.Name;
            userModel.Surname = currentUser.Surname;
            userModel.PhoneNumber = currentUser.PhoneNumber;
            userModel.CountryCode = currentUser.CountryCode;
            userModel.about = currentUser.about;
            userModel.headline = currentUser.headline;
            userModel.Province = currentUser.Province;
            userModel.District = currentUser.District;
            userModel.Industry = currentUser.Industry;
            userModel.ZIPCode = currentUser.ZIPCode;
            userModel.address = currentUser.address;
            userModel.website = currentUser.webSite;
            userModel.birthDate = currentUser.birthDate;


            return userModel;
        }

        public bool PhoneExists(string phone)
        {

            var number = _db.Users.Where(user => user.PhoneNumber == phone).FirstOrDefault();
            if (number == null)
                return false;
            return true;
        }

        public bool UserExists(string email)
        {
            var number = _db.Users.Where(user => user.Email == email).FirstOrDefault();
            if (number == null)
                return false;
            return true;
        }

        public async Task<IdentityResult> ChangePassword(string userId, string oldPassword, string newPassword)
        {

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID");
            }
            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            return result;
        }

        public async Task<IdentityResult> UpdateUser(string userId,UpdateProfileModel updateProfileModel)
        {
            var user = await _userManager.FindByIdAsync(userId);

            user.Name = updateProfileModel.name;
            user.Surname = updateProfileModel.surname;
            user.about = updateProfileModel.about;
            user.headline = updateProfileModel.headline;
            user.provinceId = updateProfileModel.provinceId;
            user.districtId = updateProfileModel.districtId;
            user.industryId = updateProfileModel.industryId;
            user.ZIPCode = updateProfileModel.zipCode;
            user.address = updateProfileModel.address;
            user.webSite = updateProfileModel.website;
            user.birthDate = updateProfileModel.birthDate;

            return await _userManager.UpdateAsync(user);
        }

        public bool saveProfilePicture(IFormFile image, string userId)
        {
            var userPath = Path.Combine(ppPath, userId);

            Directory.CreateDirectory(userPath);

            string filepath = Path.Combine(userPath, "pp.png");
            try
            {
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                {

                    image.CopyTo(fileStream);
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public FileStream getProfilePicture(string userId)
        {
            var userPath = Path.Combine(ppPath, userId);
            string filepath = Path.Combine(userPath, "pp.png");
            try
            {
                return File.OpenRead(filepath);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ProfileSummaryVM GetProfileSummary(string userId)
        {
            return _db.ApplicationUsers.Where(a => a.Id.Equals(userId)).Select(
                a => new ProfileSummaryVM
                {
                    id = a.Id,
                    fullName = a.Name +" "+a.Surname,
                    about = a.about,
                    headline = a.headline,
                    Province = a.Province,
                    District = a.District,
                    website = a.webSite
                }).FirstOrDefault();
        }
        public async Task UpdateUserAbout(string userId, UpdateAboutVM updateAbout)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.about = updateAbout.about;
            await _userManager.UpdateAsync(user);
        }

    }
}