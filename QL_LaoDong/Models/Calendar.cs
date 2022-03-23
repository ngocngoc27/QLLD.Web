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
<<<<<<< HEAD
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
=======
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
>>>>>>> 19a68486d028da3c76092bf24d13cb8268f58783
        public DateTime? Day { get; set; }

        public virtual ICollection<Workticker> Workticker { get; set; }
    }
}
