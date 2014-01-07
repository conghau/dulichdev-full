using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_Place
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _dL_CityId;
        public long DL_CityId
        {
            get { return _dL_CityId; }
            set { _dL_CityId = value; }
        }
        private long _dL_PlaceTypeId;
        public long DL_PlaceTypeId
        {
            get { return _dL_PlaceTypeId; }
            set { _dL_PlaceTypeId = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _avatar;
        public string Avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }
        private int _avgRating;
        public int AvgRating
        {
            get { return _avgRating; }
            set { _avgRating = value; }
        }
        private long _totalUserRating;
        public long TotalUserRating
        {
            get { return _totalUserRating; }
            set { _totalUserRating = value; }
        }
        private long _totalPointRating;
        public long TotalPointRating
        {
            get { return _totalPointRating; }
            set { _totalPointRating = value; }
        }
        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private long _createdBy;
        public long CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        private string _firstChar;

        public string FirstChar
        {
            get { return _firstChar; }
            set { _firstChar = value; }
        }

        private string _co_ordinate;

        public string Co_ordinate
        {
            get { return _co_ordinate; }
            set { _co_ordinate = value; }
        }
    }
    public enum DL_PlaceColumns
    {
        ID,
        DL_CityId,
        DL_PlaceTypeId,
        Name,
        Address,
        Avatar,
        AvgRating,
        TotalUserRating,
        TotalPointRating,
        CreatedDate,
        CreatedBy,
        Status,
        FirstChar,
        Co_ordinate,
    }
    public enum DL_PlaceProcedure
    {
        p_DL_Place_Insert,
        p_DL_Place_Delete,
        p_DL_Place_Update,
        p_DL_Place_Get_List,
        p_DL_Place_Get_ByID,
        p_DL_Place_Get_ByCityID,
        p_DL_Place_Get_NicePlaceByCityID,
        p_DL_Place_Get_RestaurantByCityID,
        p_DL_Place_Get_HotelByCityID,
        p_DL_Place_Get_List_WithFilter,
        p_DL_Place_Update_Hotel,
        p_DL_Place_Update_SomeValue,
        p_DL_Place_Update_Status,
    }
    public enum DL_PlaceTypeConvert
    {
        Default = 0,
        HasFirstChar =1,
    }
}