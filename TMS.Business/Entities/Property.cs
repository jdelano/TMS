using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TMS.Business.Core;

namespace TMS.Business.Entities
{
    [Description("To store Property information")]
    [Table("Property")]
    public class Property : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }

    }
}
