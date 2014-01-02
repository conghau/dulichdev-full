using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_NicePlaceInfoDetail
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
        private string _history;
        public string History
        {
            get { return _history; }
            set { _history = value; }
        }
        private string _openCloseTime;
        public string OpenCloseTime
        {
            get { return _openCloseTime; }
            set { _openCloseTime = value; }
        }
        private string _note;
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        private DateTime? _createdDate;
        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private int _staus;
        public int Staus
        {
            get { return _staus; }
            set { _staus = value; }
        }
    }
    public enum DL_NicePlaceInfoDetailColumns
    {
        ID,
        DL_PlaceId,
        Info,
        History,
        OpenCloseTime,
        Note,
        CreatedDate,
        Staus,
    }
    public enum DL_NicePlaceInfoDetailProcedure
    {
        p_DL_NicePlaceInfoDetail_Insert,
        p_DL_NicePlaceInfoDetail_Delete,
        p_DL_NicePlaceInfoDetail_Update,
        p_DL_NicePlaceInfoDetail_Get_List,
        p_DL_NicePlaceInfoDetail_Get_ByID,
        p_DL_NicePlaceInfoDetail_Get_ByPlaceID,

    }
}