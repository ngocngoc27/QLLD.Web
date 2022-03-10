using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Account
    {
        public Account()
        {
            Menus = new HashSet<Menus>();
            Muster = new HashSet<Muster>();
            Student = new HashSet<Student>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public string Fullname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Picture { get; set; }
        public bool? Lock { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Menus> Menus { get; set; }
        public virtual ICollection<Muster> Muster { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
