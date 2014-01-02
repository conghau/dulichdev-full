using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuLichDev.Models
{
    public class vm_Search
    {
        public string placename { get; set; }
        public string address { get; set; }
        public long? cityId { get; set; }
    }
}