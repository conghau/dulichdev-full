using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_PlaceType
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private int? _status;
        public int? Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
    public enum DL_PlaceTypeColumns
    {
        ID,
        Type,
        Status,
    }
    public enum DL_PlaceTypeProcedure
    {
        p_DL_PlaceType_Insert,
        p_DL_PlaceType_Delete,
        p_DL_PlaceType_Update,
        p_DL_PlaceType_Get_List,
        p_DL_PlaceType_Get_ByID,

    }

    public enum DL_PlaceTypeId
    {
        Restaurants = 1,
        Hotels = 2,
        Places = 3,
    }
}