using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSupport.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Notes = new HashSet<Note>();
        }

        public int ReportNumber { get; set; }
        public string Classification { get; set; }
        public string Status { get; set; }
        public DateTime? ReportTimestamp { get; set; }
        public string ResolutionComment { get; set; }
        public int? Service { get; set; }
        public bool? State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public int? EmployeeAssigned { get; set; }

        public virtual Employee EmployeeAssignedNavigation { get; set; }
        public virtual Service ServiceNavigation { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
