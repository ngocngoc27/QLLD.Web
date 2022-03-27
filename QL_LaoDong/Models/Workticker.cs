using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Workticker
    {
        public long Id { get; set; }
        public long? CalendarId { get; set; }
        public long? AccountId { get; set; }
        public int? Status { get; set; }
        public string RegistrationForm { get; set; }
        public bool? IsDelete { get; set; }
        public string Note { get; set; }
        public int? RegistrationNumber { get; set; }

        public virtual Account Account { get; set; }
        public virtual Calendar Calendar { get; set; }
    }
}
