using System;
using System.Collections.Generic;
using System.Text;
using TMS.DataAccess.Core;
using TMS.Common.Core;
using Microsoft.Extensions.Logging;
using TMS.Common.Entities;
using TMS.Business.BusinessObjects;
using System.Linq;

namespace TMS.Business.Managers
{
    public class ServiceRequestManager : BusinessManager, IServiceRequestManager
    {
        IRepository repository;
        ILogger<ServiceRequestManager> logger;
        IUnitOfWork unitOfWork;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return unitOfWork;
            }
        }

        public ServiceRequestManager(IRepository repository, ILogger<ServiceRequestManager> logger, IUnitOfWork unitOfWork) : base()
        {
            this.repository = repository;
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public void Create(BaseEntity entity)
        {
            ServiceRequest serviceRequest = (ServiceRequest)entity;
            logger.LogInformation("Creating record for {0}", this.GetType());
            repository.Create(serviceRequest);
            logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TenantServiceRequest> GetTenantServiceRequests()
        {

            var query = from tenants in repository.All<Tenant>()
                        join serviceReqs in repository.All<ServiceRequest>()
                        on tenants.ID equals serviceReqs.TenantID
                        join status in repository.All<Status>()
                        on serviceReqs.StatusID equals status.ID
                        select new TenantServiceRequest()
                        {
                            TenantID = tenants.ID,
                            Description = serviceReqs.Description,
                            Email = tenants.Email,
                            EmployeeComments = serviceReqs.EmployeeComments,
                            Phone = tenants.Phone,
                            Status = status.Description,
                            TenantName = tenants.Name
                        };
            return query.ToList();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

    }
}
