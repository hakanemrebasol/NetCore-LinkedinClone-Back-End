using Shared.Entity.Education;
using System.Collections.Generic;

namespace TaskDAL.IRepository
{
    public interface IUserEducationRepository: IGenericRepository<UserEducation>
    {
        void AddUserEducation(UserEducation userEducation);
        void DeleteUserEducation(int userEducationId);
        void UpdateUserEducation(UserEducation userEducation);
        List<UserEducation> GetUserEducations(string userId);
    }
}