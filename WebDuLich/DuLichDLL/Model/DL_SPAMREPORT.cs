using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_SPAMREPORT
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _dL_PlaceID;
        public long DL_PlaceID
        {
            get { return _dL_PlaceID; }
            set { _dL_PlaceID = value; }
        }
        private long _userID;
        public long UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private DateTime _createDate;
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        private DateTime? _updateDate;
        public DateTime? UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }

        private int _numberReport;

        public int NumberReport
        {
            get { return _numberReport; }
            set { _numberReport = value; }
        }

        private string _placeName;


        public string PlaceName
        {
            get { return _placeName; }
            set { _placeName = value; }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
    }
    public enum DL_SPAMREPORTColumns
    {
        ID,
        DL_PlaceID,
        UserID,
        CreateDate,
        UpdateDate,
        Status,
        NumberReport,
        PlaceName,
        UserName,
    }
    public enum DL_SPAMREPORTProcedure
    {
        p_DL_SPAMREPORT_Insert,
        p_DL_SPAMREPORT_Delete,
        p_DL_SPAMREPORT_Update,
        p_DL_SPAMREPORT_Get_List,
        p_DL_SPAMREPORT_Get_ByID,
        p_DL_SPAMREPORT_Get_ListPlaceID,
        p_DL_SPAMREPORT_Get_ListGroupByPlace,
        p_DL_SPAMREPORT_DeleteByPlaceId,
        p_DL_SPAMREPORT_GetListUserByPlaceID

    }
}