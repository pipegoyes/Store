using System.Runtime.Remoting.Metadata.W3cXsd2001;
using Store.Data.Interface;
using Store.Data.Repositories;

namespace Store.Data
{
    public class DbFactory : DisposableBase, IDbFactory
    {
        public StoreEntities DbContext;

        public StoreEntities Init()
        {
            return DbContext ?? (DbContext = new StoreEntities());
        }

        protected override void DisposeCore()
        {
            DbContext?.Dispose();
            //base.DisposeCore();
        }
    }
}