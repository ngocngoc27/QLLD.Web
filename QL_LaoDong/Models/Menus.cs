using System;
using System.Collections.Generic;

namespace QL_LaoDong.Models
{
    public partial class Menus
    {
        public long IdMn { get; set; }
        public string Label { get; set; }
        public long? Parent { get; set; }
        public string UrlLink { get; set; }
        public long? OrderKey { get; set; }
        public long? UserAdd { get; set; }
        public bool? Hide { get; set; }
    }
}
