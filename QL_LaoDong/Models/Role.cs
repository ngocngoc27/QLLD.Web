using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Role
    {
        public Role()
        {
            Account = new HashSet<Account>();
        }

        public long Id { get; set; }
        public string NameRole { get; set; }
        public bool? IsDelete { get; set; }
        public int? Code { get; set; }

        public virtual ICollection<Account> Account { get; set; }
    }
}
