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
            Student = new HashSet<Student>();
            Workticker = new HashSet<Workticker>();
        }

        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long? RoleId { get; set; }
        public string Fullname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Picture { get; set; }
        public bool? IsDelete { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Student> Student { get; set; }
        public virtual ICollection<Workticker> Workticker { get; set; }
    }
}
