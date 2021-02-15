using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiSupport.Models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public string Description { get; set; }
        public DateTime? NoteTimestamp { get; set; }
        public int? ReportNumber { get; set; }
        public bool? State { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Issue ReportNumberNavigation { get; set; }
    }
}
