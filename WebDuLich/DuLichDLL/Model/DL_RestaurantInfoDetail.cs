using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
   
    public class DL_RestaurantInfoDetail
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
        private string _menu;
        public string Menu
        {
            get { return _menu; }
            set { _menu = value; }
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
        private string _website;
        public string Website
        {
            get { return _website; }
            set { _website = value; }
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
    public enum DL_RestaurantInfoDetailColumns
    {
        ID,
        DL_PlaceId,
        Info,
        Menu,
        Note,
        MobiPhone,
        HomePhone,
        Fax,
        Email,
        Website,
        CreatedDate,
        Status,
    }
    public enum DL_RestaurantInfoDetailProcedure
    {
        p_DL_RestaurantInfoDetail_Insert,
        p_DL_RestaurantInfoDetail_Delete,
        p_DL_RestaurantInfoDetail_Update,
        p_DL_RestaurantInfoDetail_Get_List,
        p_DL_RestaurantInfoDetail_Get_ByID,
        p_DL_RestaurantInfoDetail_Get_By_DL_PlaceId,

    }
}