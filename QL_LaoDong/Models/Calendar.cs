using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        public DateTime? Day { get; set; }

        public virtual ICollection<Workticker> Workticker { get; set; }
    }
}
