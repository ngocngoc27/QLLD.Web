using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Job
    {
        public Job()
        {
            Workticker = new HashSet<Workticker>();
        }

        public long Id { get; set; }
        public string Job1 { get; set; }
        public string Description { get; set; }
        public string Locate { get; set; }
        public bool? Lock { get; set; }

        public virtual ICollection<Workticker> Workticker { get; set; }
    }
}
