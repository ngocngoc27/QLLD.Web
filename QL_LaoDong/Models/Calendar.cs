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

>>>>>>> 26f71339fc0c17931963d51868af7ad77a80c88b
        public DateTime? Day { get; set; }

        public virtual ICollection<Workticker> Workticker { get; set; }
    }
}
