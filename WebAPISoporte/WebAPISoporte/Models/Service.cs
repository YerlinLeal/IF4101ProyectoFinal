using System;
using System.Collections.Generic;

#nullable disable

namespace WebAPISoporte.Models
{
    public partial class Service
    {
        public Service()
        {
            Issues = new HashSet<Issue>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
