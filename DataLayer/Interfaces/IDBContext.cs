using System;
using System.Data.Entity;
namespace DataLayer.Interfaces
{
    public interface IDBContext : IDisposable
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
