using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Student
    {
        public Student()
        {
            Muster = new HashSet<Muster>();
        }

        public long Id { get; set; }
        public string Mssv { get; set; }
        public int? NumberOfWork { get; set; }
        public long? ClassId { get; set; }
        public long? AccountId { get; set; }
        public bool? IsDelete { get; set; }

        public virtual Account Account { get; set; }
        public virtual Class Class { get; set; }
        public virtual ICollection<Muster> Muster { get; set; }
    }
}
