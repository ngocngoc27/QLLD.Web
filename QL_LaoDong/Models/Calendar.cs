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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

>>>>>>> d500ce276cf83405ba621cba9cf38805ca3fd45b
        public DateTime? Day { get; set; }

        public virtual ICollection<Workticker> Workticker { get; set; }
    }
}
