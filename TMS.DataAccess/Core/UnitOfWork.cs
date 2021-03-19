using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.DataAccess.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory dbFactory;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void BeginTransaction()
        {
            dbFactory.GetDataContext.Database.BeginTransaction();
        }

        public void RollbackTransaction()
        {
            dbFactory.GetDataContext.Database.RollbackTransaction();
        }

        public void CommitTransaction()
        {
            dbFactory.GetDataContext.Database.CommitTransaction();
        }

        public void SaveChanges()
        {
            dbFactory.GetDataContext.SaveChanges();
        }
    }
}
