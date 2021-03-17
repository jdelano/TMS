using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TMS.Common.Entities;

namespace TMS.DataAccess.Core
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobTask> JobTask { get; set; }
        public DbSet<JobWorker> JobWorker { get; set; }
        public DbSet<Property> Property { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
    }
}
