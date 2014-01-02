using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_ImagePlace
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
        private string _linkImage;
        public string LinkImage
        {
            get { return _linkImage; }
            set { _linkImage = value; }
        }
        private DateTime _createdDate;
        public DateTime CreatedDate
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
    public enum DL_ImagePlaceColumns
    {
        ID,
        DL_PlaceID,
        LinkImage,
        CreatedDate,
        Status,
    }
    public enum DL_ImagePlaceProcedure
    {
        p_DL_ImagePlace_Insert,
        p_DL_ImagePlace_Delete,
        p_DL_ImagePlace_Update,
        p_DL_ImagePlace_Get_List,
        p_DL_ImagePlace_Get_ByID,
        p_DL_ImagePlace_Get_ByDL_PlaceID

    }
}