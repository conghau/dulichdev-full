using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_ImageCity
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
        private string _link;
        public string Link
        {
            get { return _link; }
            set { _link = value; }
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
    public enum DL_ImageCityColumns
    {
        ID,
        DL_CityId,
        Link,
        CreatedDate,
        Status,
    }
    public enum DL_ImageCityProcedure
    {
        p_DL_ImageCity_Insert,
        p_DL_ImageCity_Delete,
        p_DL_ImageCity_Update,
        p_DL_ImageCity_Get_List,
        p_DL_ImageCity_Get_ByID,

    }
}