using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_City
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _countryCode;
        public string CountryCode
        {
            get { return _countryCode; }
            set { _countryCode = value; }
        }
        private string _cityName;
        public string CityName
        {
            get { return _cityName; }
            set { _cityName = value; }
        }
        private float? _avgRating;
        public float? AvgRating
        {
            get { return _avgRating; }
            set { _avgRating = value; }
        }
        private int? _totalUserRating;
        public int? TotalUserRating
        {
            get { return _totalUserRating; }
            set { _totalUserRating = value; }
        }
        private int? _totalPointRating;
        public int? TotalPointRating
        {
            get { return _totalPointRating; }
            set { _totalPointRating = value; }
        }
        private int? _status;
        public int? Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private string _avatar;

        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        private string _summary;

        public string Summary
        {
            get { return _summary; }
            set { _summary = value; }
        }
    }
    public enum DL_CityColumns
    {
        ID,
        CountryCode,
        CityName,
        Avatar,
        Summary,
        AvgRating,
        TotalUserRating,
        TotalPointRating,
        Status,
    }
    public enum DL_CityProcedure
    {
        p_DL_City_Insert,
        p_DL_City_Delete,
        p_DL_City_Update,
        p_DL_City_Get_List,
        p_DL_City_Get_ByID,
        p_DL_City_UpdateContent,
        p_DL_City_Get_List_WithFilter

    }
}