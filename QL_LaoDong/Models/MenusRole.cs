using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class MenusRole
    {
        public long? IdMn { get; set; }
        public long? RoleId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Menus IdMnNavigation { get; set; }
        public virtual Role Role { get; set; }
    }
}
