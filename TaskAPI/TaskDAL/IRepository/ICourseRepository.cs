using System.Collections.Generic;
using Shared.Entity.Accomplishments;
namespace TaskDAL.IRepository
{
    public interface ICourseRepository: IGenericRepository<UserCourse>
    {
        void AddUserCourse(UserCourse userCourse);
        List<UserCourse> GetUserCourses(string userId);
        void UpdateCourse(UserCourse userCourse);
        void RemoveCourse(int courseId);
    }
}