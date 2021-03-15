using System;
using System.Collections.Generic;
using System.Text;
using TMS.Business.BusinessObjects;
using TMS.Business.Core;

namespace TMS.Business.Managers
{
    public interface IServiceRequestManager : IActionManager
    {
        IEnumerable<TenantServiceRequest> GetTenantServiceRequests();
    }
}
