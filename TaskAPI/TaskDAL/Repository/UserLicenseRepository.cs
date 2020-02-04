using System.Linq;
using TaskDAL.IRepository;
using TaskDAL.Context;
using Shared.Entity.License;
using System.Collections.Generic;
namespace TaskDAL.Repository
{
    public class UserLicenseRepository : GenericRepository<UserLicense>, IUserLicenseRepository {
        private readonly DatabaseContext _db;
        public UserLicenseRepository(DatabaseContext db):base(db) {
        }

        public void AddUserLicense(UserLicense userLicense)
        {
            Insert(userLicense);
            Save();
        }

        public List<UserLicense> GetUserLicenses(string userId)
        {
            return GetAll().Where(a => a.userId.Equals(userId)).ToList();
        }

        public void RemoveUserLicense(string userId, int userLicenseId)
        {
            Delete(userLicenseId);
            Save();
        }

        public void UpdateUserLicense(UserLicense userLicense)
        {
            Update(userLicense);
            Save();
        }
    }
}