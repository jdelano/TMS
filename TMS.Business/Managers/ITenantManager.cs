using System;
using System.Collections.Generic;
using System.Text;
using TMS.Business.Core;
using TMS.Business.Entities;

namespace TMS.Business.Managers
{
    public interface ITenantManager : IActionManager
    {
        Tenant GetTenant(long tenantID);
    }
}
