using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_LikePlace
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long? _dL_PlaceID;
        public long? DL_PlaceID
        {
            get { return _dL_PlaceID; }
            set { _dL_PlaceID = value; }
        }
        private long? _uSERID;
        public long? USERID
        {
            get { return _uSERID; }
            set { _uSERID = value; }
        }
        private DateTime? _createdDate;
        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private int? _status;
        public int? Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
    public enum DL_LikePlaceColumns
    {
        ID,
        DL_PlaceID,
        USERID,
        CreatedDate,
        Status,
    }
    public enum DL_LikePlaceProcedure
    {
        p_DL_LikePlace_Insert,
        p_DL_LikePlace_Delete,
        p_DL_LikePlace_Update,
        p_DL_LikePlace_Get_List,
        p_DL_LikePlace_Get_ByID,

    }
}