using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [DataType(DataType.Date)]
<<<<<<< HEAD
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
=======
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
>>>>>>> 19a68486d028da3c76092bf24d13cb8268f58783
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Picture { get; set; }
        public bool? Lock { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Menus> Menus { get; set; }
        public virtual ICollection<Muster> Muster { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
