using System.Linq;
using TaskDAL.IRepository;
using TaskDAL.Context;
using System.Collections.Generic;
using Shared.Entity.Accomplishments;

namespace TaskDAL.Repository
{
    public class ProjectRepository : GenericRepository<UserProject>, IProjectRepository {
        private readonly DatabaseContext _db;
        public ProjectRepository(DatabaseContext db):base(db) {
        }

        public void AddUserProject(UserProject userProject)
        {
            Insert(userProject);
            Save();
        }

        public List<UserProject> GetUserProjects(string userId)
        {
            return GetAll().Where(a => a.userId.Equals(userId)).ToList();
        }

        public void RemoveProject(int projectId)
        {
            Delete(projectId);
            Save();
        }

        public void UpdateProject(UserProject userProject)
        {
            Update(userProject);
            Save();
        }
    }
}