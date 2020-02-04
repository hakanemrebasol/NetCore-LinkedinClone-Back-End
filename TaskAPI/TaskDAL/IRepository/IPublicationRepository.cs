using Shared.Entity;
using Shared.Entity.License;
using Shared.Entity.Skill;
using Shared.Models.ViewModels;
using System.Collections.Generic;

namespace TaskDAL.IRepository
{
    public interface IPublicationRepository : IGenericRepository<Publication>
    {
        void AddPublication(Publication publication);
        void DeletePublication(int publicationId);
        void UpdatePublication(Publication publication);
        List<Publication> GetUserPublications(string userId);
    }
}