using System.Linq;
using TaskDAL.IRepository;
using TaskDAL.Context;
using System.Collections.Generic;
using Shared.Entity.Skill;
using Shared.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Shared.Entity;

namespace TaskDAL.Repository
{
    public class PublicationRepository : GenericRepository<Publication>, IPublicationRepository {
        public PublicationRepository(DatabaseContext db):base(db) {
        }

        public void AddPublication(Publication publication)
        {
            Insert(publication);
            Save();
        }

        public List<Publication> GetUserPublications(string userId)
        {
            return GetTable().Where(a => a.userId.Equals(userId)).ToList();
        }

        public void DeletePublication(int publicationId)
        {
            Delete(publicationId);
            Save();
        }

        public void UpdatePublication(Publication publication)
        {
            Update(publication);
            Save();
        }
    }
}