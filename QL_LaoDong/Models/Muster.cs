using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Muster
    {
        public long Id { get; set; }
        public long WorkTickerId { get; set; }
        public long AccountId { get; set; }
        public int? Present { get; set; }
        public string Status { get; set; }

        public virtual Account Account { get; set; }
        public virtual Workticker WorkTicker { get; set; }
    }
}
