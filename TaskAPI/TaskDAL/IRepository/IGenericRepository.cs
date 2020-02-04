using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TaskDAL.IRepository
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        IQueryable<T> GetTable();

        T GetById(object id);

        void Insert(T obj);

        void Update(T obj);


        void Delete(object id);

        void Save();


    }
}
