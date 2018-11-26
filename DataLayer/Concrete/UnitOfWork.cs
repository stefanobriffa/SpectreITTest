using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Transactions;

namespace DataLayer.Concrete
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private TransactionScope _transaction;

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public void Commit()
        {
            _transaction.Complete();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
