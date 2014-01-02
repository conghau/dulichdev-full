using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuLichDev.Models
{
    public class vm_Pagination
    {
        public string OrderBy { get; set; }
        public string OrderDirection { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}