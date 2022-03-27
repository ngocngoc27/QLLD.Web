using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Groups
    {
        public Groups()
        {
            Muster = new HashSet<Muster>();
            Toolticker = new HashSet<Toolticker>();
            Workticker = new HashSet<Workticker>();
        }

        public long Id { get; set; }
        public string GroupsName { get; set; }
        public long? JobId { get; set; }
        public string Leader { get; set; }
        public int? Status { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Job Job { get; set; }
        public virtual ICollection<Muster> Muster { get; set; }
        public virtual ICollection<Toolticker> Toolticker { get; set; }
        public virtual ICollection<Workticker> Workticker { get; set; }
    }
}
