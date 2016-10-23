using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Store.Data.Interface;

namespace Store.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T: class 
    {
        private StoreEntities _dataContext;
        private readonly IDbSet<T> _dbSet;

        protected IDbFactory DbFactory { get; private set; }
        
        public StoreEntities DbContext => _dataContext ?? (_dataContext = DbFactory.Init());

        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteExpression(Expression<Func<T, bool>> whereExpression)
        {
            var selectedObjects = _dbSet.Where(whereExpression).AsEnumerable();
            foreach (var selectedObject in selectedObjects)
            {
                _dbSet.Remove(selectedObject);
            }

        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> whereExpression)
        {
            return _dbSet.Where(whereExpression).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> whereExpression)
        {
            return _dbSet.Where(whereExpression).ToList();
        }
        
    }
}