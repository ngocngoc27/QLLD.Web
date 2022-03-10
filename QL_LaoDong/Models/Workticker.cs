using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Workticker
    {
        public Workticker()
        {
            Muster = new HashSet<Muster>();
            Toolticker = new HashSet<Toolticker>();
        }

        public long Id { get; set; }
        public long CalendarId { get; set; }
        public long JobId { get; set; }
        public string Status { get; set; }

        public virtual Calendar Calendar { get; set; }
        public virtual Job Job { get; set; }
        public virtual ICollection<Muster> Muster { get; set; }
        public virtual ICollection<Toolticker> Toolticker { get; set; }
    }
}
