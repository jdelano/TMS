using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS.Business.Core;
using TMS.Common.Core;
using TMS.Common.Entities;
using TMS.DataAccess.Core;

namespace TMS.Business.Managers
{
    public class TenantManager : BusinessManager, ITenantManager
    {
        IRepository repository;
        ILogger<TenantManager> logger;
        IUnitOfWork unitOfWork;
        IServiceRequestManager serviceRequestManager;


        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public TenantManager(IRepository repository, ILogger<TenantManager> logger, IUnitOfWork unitOfWork, IServiceRequestManager serviceRequestManager) : base()
        {
            this.repository = repository;
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.serviceRequestManager = serviceRequestManager;
        }

        public virtual Tenant GetTenant(long tenantID)
        {
            logger.LogInformation(LoggingEvents.GET_ITEM, "The tenant Id is " + tenantID);
            return repository.All<Tenant>().Where(i => i.ID == tenantID).FirstOrDefault();
        }

        public void Create(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            logger.LogInformation("Creating record for {0}", this.GetType());
            repository.Create<Tenant>(tenant);
            SaveChanges();
            logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Update(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            logger.LogInformation("Updating record for {0}", this.GetType());
            repository.Update<Tenant>(tenant);
            SaveChanges();
            logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            Tenant tenant = (Tenant)entity;
            logger.LogInformation("Updating record for {0}", this.GetType());
            repository.Delete<Tenant>(tenant);
            SaveChanges();
            logger.LogInformation("Record deleted for {0}", this.GetType());
        }

        IEnumerable<BaseEntity> IActionManager.GetAll()
        {
            return repository.All<Tenant>().ToList();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}
