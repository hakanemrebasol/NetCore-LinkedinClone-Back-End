using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Shared.Models.ViewModels;

namespace TaskDAL.IRepository {
    public interface IAccountRepository {
        Task<UserModel> GetProfile (string userId);
        bool saveProfilePicture(IFormFile image, string userId);
        FileStream getProfilePicture(string userId);
    }
}