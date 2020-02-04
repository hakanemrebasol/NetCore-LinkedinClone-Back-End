using Shared.Entity.License;
using System.Collections.Generic;
using TaskDAL.IRepository;

namespace TaskDAL.IRepository
{
    public interface IUserLicenseRepository: IGenericRepository<UserLicense>
    {
        void AddUserLicense(UserLicense userLicense);
        void RemoveUserLicense(string userId, int userLicenseId);
        void UpdateUserLicense(UserLicense userLicense);
        List<UserLicense> GetUserLicenses(string userId);
    }
}