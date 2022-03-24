using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Toolticker
    {
        public long Id { get; set; }
        public long? ToolId { get; set; }
        public int? Amount { get; set; }
        public string Notes { get; set; }
        public bool? IsDelete { get; set; }
        public long? GroupsId { get; set; }

        public virtual Groups Groups { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
