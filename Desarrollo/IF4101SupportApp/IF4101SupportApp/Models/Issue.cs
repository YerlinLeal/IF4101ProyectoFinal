using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IF4101SupportApp.Models
{
    public class Issue
    {
        public Issue()
        {
        }

        public int ReportNumber { get; set; }
        public string UserName { get; set; }
        public string UserFirstSurname { get; set; }
        public string UserSecondSurname { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Address { get; set; }
        public string SecondContact { get; set; }
        public string ContactEmail { get; set; }
        public int ContactPhone { get; set; }
        public char Classification { get; set; }
        public int? IdSupportAssigned { get; set; }
        public char Status { get; set; }
        public string Comments { get; set; }
        public List<Note> Notes { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ReportTimestamp { get; set; }
    }
}
