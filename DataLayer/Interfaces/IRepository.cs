using System;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IRepository : IDisposable
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class;
        TEntity GetByStringCode<TEntity>(string code) where TEntity : class;
        void SaveChanges();
    }
}
