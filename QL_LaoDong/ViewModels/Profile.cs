using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.ViewModels
{
    public class Profile
    {
        public string Mssv { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string RoleName { get; set; }
        public string ClassName { get; set; }
        public string Training { get; set; }
        public string TypeOfEducation { get; set; }
        public string FacultyName { get; set; }
        public int? NumberOfWork { get; set; }
    }
}
