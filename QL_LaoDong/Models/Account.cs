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

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
<<<<<<< HEAD
=======

>>>>>>> 26f71339fc0c17931963d51868af7ad77a80c88b
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
