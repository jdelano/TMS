using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.DataAccess.Core
{
    public class DbFactory : IDbFactory, IDisposable
    {
        private DataContext dataContext;
        public DataContext GetDataContext => dataContext;

        public DbFactory(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        private bool isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                if (dataContext != null)
                {
                    dataContext.Dispose();
                }
            }
            isDisposed = true;
        }
    }
}
