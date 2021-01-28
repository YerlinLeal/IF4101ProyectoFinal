using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSupport.Models
{
    public partial class EmployeeService
    {
        public int EmployeeId { get; set; }
        public int ServiceId { get; set; }
        public bool? State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Service Service { get; set; }
    }
}
