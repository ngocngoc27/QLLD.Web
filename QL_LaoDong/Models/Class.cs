using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Class
    {
        public Class()
        {
            Student = new HashSet<Student>();
        }

        public long Id { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public string Training { get; set; }
        public string TypeOfEducation { get; set; }
        public int Total { get; set; }
        public int TotalOfWork { get; set; }
        public int? Status { get; set; }
        public long? FacultyId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
