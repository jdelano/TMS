using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Business.Managers
{
    public class BusinessManagerFactory
    {
        private IServiceRequestManager serviceRequestManager;
        private ITenantManager tenantManager;

        public BusinessManagerFactory(IServiceRequestManager serviceRequestManager = null, ITenantManager tenantManager = null)
        {
            this.serviceRequestManager = serviceRequestManager;
            this.tenantManager = tenantManager;
        }

        public IServiceRequestManager GetServiceRequestManager()
        {
            return serviceRequestManager;
        }

        public ITenantManager GetTenantManager()
        {
            return tenantManager;
        }
    }
}
