using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventPlannig.DAL.Interfaces
{
    public interface IRepository<T> where T : IBaseEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
    }
}
