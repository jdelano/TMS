using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.DataAccess.Core
{
    public interface IDbFactory
    {
        DataContext GetDataContext { get; }
    }
}
