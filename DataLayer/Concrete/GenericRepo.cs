using DataLayer.Interfaces;
using System;
using System.Collections.Generic;

namespace DataLayer.Concrete
{
    public class GenericRepo : IRepository, IDisposable
    {
        private readonly IDBContext _context;

        public GenericRepo(IDBContext context)
        {
            _context = context;
        }

        public virtual TEntity GetByStringCode<TEntity>(string code) where TEntity : class
        {
            var result = _context.Set<TEntity>().Find(code);
            return result;
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _context.Set<TEntity>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
