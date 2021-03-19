using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.DataAccess.Core
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void RollbackTransaction();
        void CommitTransaction();
        void SaveChanges();
    }
}
