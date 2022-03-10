﻿using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Calendar
    {
        public Calendar()
        {
            Workticker = new HashSet<Workticker>();
        }

        public long Id { get; set; }
        public string SessionOfDay { get; set; }
        public string Weekdays { get; set; }
        public DateTime? Day { get; set; }

        public virtual ICollection<Workticker> Workticker { get; set; }
    }
}
