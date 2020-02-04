using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskDAL.Context;
using TaskDAL.IRepository;
using TaskDAL.Helpers;

namespace TaskDAL.Repository
{
    public class GenericRepository<T> : IRepository.IGenericRepository<T> where T : class
    {
        public DatabaseContext _context = null;
        public DbSet<T> table = null;
        public GenericRepository(DatabaseContext db)
        {
            this._context = db;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public IQueryable<T> GetTable()
        {
            return table;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
