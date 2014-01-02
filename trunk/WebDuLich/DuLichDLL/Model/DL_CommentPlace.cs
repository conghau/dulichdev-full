using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_CommentPlace
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
        private long? _userId;
        public long? UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _content;
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        private int? _rating;
        public int? Rating
        {
            get { return _rating; }
            set { _rating = value; }
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
    public enum DL_CommentPlaceColumns
    {
        ID,
        DL_PlaceID,
        UserId,
        Content,
        Rating,
        CreatedDate,
        Status,
    }
    public enum DL_CommentPlaceProcedure
    {
        p_DL_CommentPlace_Insert,
        p_DL_CommentPlace_Delete,
        p_DL_CommentPlace_Update,
        p_DL_CommentPlace_Get_List,
        p_DL_CommentPlace_Get_ByID,

    }
}