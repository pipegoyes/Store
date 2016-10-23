using System;
using Store.Data.Repositories;

namespace Store.Data.Interface
{
    public interface IDbFactory : IDisposable
    {
        StoreEntities Init();
    }
}