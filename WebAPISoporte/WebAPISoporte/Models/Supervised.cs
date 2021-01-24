using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPISoporte.Models
{
    public partial class Supervised
    {
        public int? SupervisorId { get; set; }
        public int? SupervisedId { get; set; }

        public virtual Employee SupervisedNavigation { get; set; }
        public virtual Employee Supervisor { get; set; }
    }
}
