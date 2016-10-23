using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Store.Data.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteExpression(Expression<Func<T, bool>> whereExpression);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> whereExpression);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> whereExpression);
    }
}