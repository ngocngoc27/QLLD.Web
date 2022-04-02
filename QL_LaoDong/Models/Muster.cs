using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QL_LaoDong.Models
{
    public partial class Muster
    {
        public long Id { get; set; }
        public long? StudentId { get; set; }
        public bool RollUp { get; set; }
        public long? GroupsId { get; set; }
        public bool? IsDelete { get; set; }
        [NotMapped]
        public List<Muster> DiemdanhSV { get; set;}

        public virtual Groups Groups { get; set; }
        public virtual Student Student { get; set; }
    }
}
