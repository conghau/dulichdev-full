using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDuLichDev.Models
{
    public class vm_NicePlace
    {
        public DL_Place dlPlace { get; set; }
        public DL_NicePlaceInfoDetail dlNicePlaceInfoDetail { get; set; }
        public List<DL_ImagePlace> listImagePlace { get; set; }
    }
    public class CityInfo
    {

        public DL_City dlCity { get; set; }
        public DL_CityInfoDetail dlCityInfoDetail { get; set; }

    }
    public class HotelInfo
    {
        public DL_Place dlPlace { get; set; }
        public DL_HotelPlaceInfoDetail dlHotelPlaceInfoDetail { get; set; }
        public List<DL_ImagePlace> listImagePlace { get; set; }
    }

    public class RestaurantInfo
    {
        public DL_Place dlPlace { get; set; }
        public DL_RestaurantInfoDetail dlRestaurantInfoDetail { get; set; }
        public List<DL_ImagePlace> listImagePlace { get; set; }
    }


}
