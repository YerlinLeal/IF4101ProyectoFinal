using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSupport.Models
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeServices = new HashSet<EmployeeService>();
            InverseSupervisedNavigation = new HashSet<Employee>();
            Issues = new HashSet<Issue>();
        }

        public int EmployeeId { get; set; }
        public string Dni { get; set; }
        public string EmployeeName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public int? EmployeeType { get; set; }
        public bool? State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? Supervised { get; set; }

        public virtual Employee SupervisedNavigation { get; set; }
        public virtual ICollection<EmployeeService> EmployeeServices { get; set; }
        public virtual ICollection<Employee> InverseSupervisedNavigation { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
