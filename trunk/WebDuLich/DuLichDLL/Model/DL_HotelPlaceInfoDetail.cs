using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_HotelPlaceInfoDetail
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _dL_PlaceId;
        public long DL_PlaceId
        {
            get { return _dL_PlaceId; }
            set { _dL_PlaceId = value; }
        }
        private string _info;
        public string Info
        {
            get { return _info; }
            set { _info = value; }
        }
        private string _service;
        public string Service
        {
            get { return _service; }
            set { _service = value; }
        }
        private string _roomType;
        public string RoomType
        {
            get { return _roomType; }
            set { _roomType = value; }
        }
        private string _openCloseTime;
        public string OpenCloseTime
        {
            get { return _openCloseTime; }
            set { _openCloseTime = value; }
        }
        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private string _payType;
        public string PayType
        {
            get { return _payType; }
            set { _payType = value; }
        }
        private string _note;
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        private string _mobiPhone;
        public string MobiPhone
        {
            get { return _mobiPhone; }
            set { _mobiPhone = value; }
        }
        private string _homePhone;
        public string HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }
        private string _fax;
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private DateTime? _createdDate;
        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
    public enum DL_HotelPlaceInfoDetailColumns
    {
        ID,
        DL_PlaceId,
        Info,
        Service,
        RoomType,
        OpenCloseTime,
        Price,
        PayType,
        Note,
        MobiPhone,
        HomePhone,
        Fax,
        Email,
        CreatedDate,
        Status,
    }
    public enum DL_HotelPlaceInfoDetailProcedure
    {
        p_DL_HotelPlaceInfoDetail_Insert,
        p_DL_HotelPlaceInfoDetail_Delete,
        p_DL_HotelPlaceInfoDetail_Update,
        p_DL_HotelPlaceInfoDetail_Get_List,
        p_DL_HotelPlaceInfoDetail_Get_ByID,
        p_DL_HotelPlaceInfoDetail_Get_By_DL_PlaceId

    }
}