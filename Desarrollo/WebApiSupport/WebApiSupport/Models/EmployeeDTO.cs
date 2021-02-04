using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSupport.Models
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string Dni { get; set; }
        public string EmployeeName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? EmployeeType { get; set; }
        public bool? State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? Supervised { get; set; }

        public EmployeeDTO()
        {

        }
    }
}
