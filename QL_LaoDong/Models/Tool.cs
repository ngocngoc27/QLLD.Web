using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Tool
    {
        public Tool()
        {
            Toolticker = new HashSet<Toolticker>();
        }

        public long Id { get; set; }
        public string Tool1 { get; set; }
        public int? Sum { get; set; }
        public string Unit { get; set; }
        public int? Available { get; set; }
        public bool? Lock { get; set; }

        public virtual ICollection<Toolticker> Toolticker { get; set; }
    }
}
