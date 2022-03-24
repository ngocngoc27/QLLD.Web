using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Muster
    {
        public long Id { get; set; }
        public long? StudentId { get; set; }
        public bool? RollUp { get; set; }
        public long? GroupsId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Groups Groups { get; set; }
        public virtual Student Student { get; set; }
    }
}
