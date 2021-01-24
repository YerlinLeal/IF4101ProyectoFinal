using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPISoporte.Models
{
    public partial class Employee
    {
        public Employee()
        {
            IssueCreatedByNavigations = new HashSet<Issue>();
            IssueEmployeeAssignedNavigations = new HashSet<Issue>();
            IssueModifiedByNavigations = new HashSet<Issue>();
            NoteCreatedByNavigations = new HashSet<Note>();
            NoteModifiedByNavigations = new HashSet<Note>();
        }

        public int EmployeeId { get; set; }
        public string Dni { get; set; }
        public string EmployeeName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Email { get; set; }
        public bool? EmployeeState { get; set; }
        public int? EmployeeType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<Issue> IssueCreatedByNavigations { get; set; }
        public virtual ICollection<Issue> IssueEmployeeAssignedNavigations { get; set; }
        public virtual ICollection<Issue> IssueModifiedByNavigations { get; set; }
        public virtual ICollection<Note> NoteCreatedByNavigations { get; set; }
        public virtual ICollection<Note> NoteModifiedByNavigations { get; set; }
    }
}
