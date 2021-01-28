using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSupport.Models
{
    public partial class Service
    {
        public Service()
        {
            EmployeeServices = new HashSet<EmployeeService>();
            Issues = new HashSet<Issue>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public bool? State { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<EmployeeService> EmployeeServices { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
