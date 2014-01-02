using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_CommentCity
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
        private long _userId;
        public long UserId
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
        private DateTime? _updatedDate;
        public DateTime? UpdatedDate
        {
            get { return _updatedDate; }
            set { _updatedDate = value; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
    public enum DL_CommentCityColumns
    {
        ID,
        DL_CityId,
        UserId,
        Content,
        Rating,
        CreatedDate,
        UpdatedDate,
        Status,
    }
    public enum DL_CommentCityProcedure
    {
        p_DL_CommentCity_Insert,
        p_DL_CommentCity_Delete,
        p_DL_CommentCity_Update,
        p_DL_CommentCity_Get_List,
        p_DL_CommentCity_Get_ByID,

    }
}