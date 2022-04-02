using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QL_LaoDong.ViewModels
{
    public class AppUser
    {
        public long AccountId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public int? Total { get; set; }
        public int? TotalOfWork { get; set; }
        public int? NumberWork { get; set; }
        public string TypeOfEducation { get; set; }
    }
}
