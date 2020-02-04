using System.Linq;
using TaskDAL.IRepository;
using TaskDAL.Context;
using Shared.Entity.License;
using System.Collections.Generic;
using Shared.Entity.Accomplishments;

namespace TaskDAL.Repository
{
    public class CourseRepository : GenericRepository<UserCourse>, ICourseRepository {
        private readonly DatabaseContext _db;
        public CourseRepository(DatabaseContext db):base(db) {
        }

        public void AddUserCourse(UserCourse userCourse)
        {
            Insert(userCourse);
            Save();
        }

        public List<UserCourse> GetUserCourses(string userId)
        {
            return GetAll().Where(a => a.userId.Equals(userId)).ToList();
        }

        public void RemoveCourse(int courseId)
        {
            Delete(courseId);
            Save();
        }

        public void UpdateCourse(UserCourse userCourse)
        {
            Update(userCourse);
            Save();
        }
    }
}