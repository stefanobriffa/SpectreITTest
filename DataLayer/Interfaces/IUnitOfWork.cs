using System;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void StartTransaction();
        void Commit();
    }
}
