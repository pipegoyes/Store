using Store.Data.Interface;
using Store.Data.Repositories;

namespace Store.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private StoreEntities _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }
        
        public StoreEntities DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());


        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
