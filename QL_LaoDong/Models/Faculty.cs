using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Class = new HashSet<Class>();
        }

        public long Id { get; set; }
        public string FacultyName { get; set; }
        public bool? IsDelete { get; set; }

        public virtual ICollection<Class> Class { get; set; }
    }
}
