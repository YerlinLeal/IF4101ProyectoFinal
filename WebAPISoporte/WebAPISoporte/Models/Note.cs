using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPISoporte.Models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public string Description { get; set; }
        public byte[] NoteTimestamp { get; set; }
        public int? ReportNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual Employee CreatedByNavigation { get; set; }
        public virtual Employee ModifiedByNavigation { get; set; }
        public virtual Issue ReportNumberNavigation { get; set; }
    }
}
