using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Job
    {
        public Job()
        {
            Groups = new HashSet<Groups>();
        }

        public long Id { get; set; }
        public string JobName { get; set; }
        public string Description { get; set; }
        public string Locate { get; set; }
        public bool? IsDelete { get; set; }
        public int BenefitOfDay { get; set; }

        public virtual ICollection<Groups> Groups { get; set; }
    }
}
