using System.Collections.Generic;
using Shared.Entity.Accomplishments;

namespace TaskDAL.IRepository
{
    public interface IProjectRepository: IGenericRepository<UserProject>
    {
        void AddUserProject(UserProject userProject);
        List<UserProject> GetUserProjects(string userId);
        void UpdateProject(UserProject userProject);
        void RemoveProject(int projectId);
    }
}