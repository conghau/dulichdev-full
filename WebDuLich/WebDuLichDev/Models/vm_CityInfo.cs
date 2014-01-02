using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDuLichDev.Models
{
    public class vm_CityInfo
    {
        public DL_CityInfoDetail cityInfoDetail { get; set; }
        public string summary { get; set; }
    }
}