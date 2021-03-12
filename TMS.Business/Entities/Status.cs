using TMS.Business.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.Business.Entities
{
    [Description("To store Status")]
    [Table("Status")]
    public class Status : BaseEntity
    {

        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
