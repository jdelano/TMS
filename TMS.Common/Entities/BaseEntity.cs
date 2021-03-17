using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TMS.Common.Entities
{
    public abstract class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        [NotMapped]
        public int State { get; set; }

        public enum EntityState
        {
            New = 1, 
            Update = 2,
            Delete = 3,
            Ignore = 4
        }

    }
}
