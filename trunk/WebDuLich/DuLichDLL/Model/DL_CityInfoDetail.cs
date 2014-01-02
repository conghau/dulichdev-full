using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
namespace DuLichDLL.Model
{
    public class DL_CityInfoDetail
    {
        private long _id;
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private long _dL_CityId;
        public long DL_CityId
        {
            get { return _dL_CityId; }
            set { _dL_CityId = value; }
        }
        private string _history;
        [AllowHtml]
        public string History
        {
            get { return _history; }
            set { _history = value; }
        }
        private string _nature;
        public string Nature
        {
            get { return _nature; }
            set { _nature = value; }
        }
        private string _social;
        public string Social
        {
            get { return _social; }
            set { _social = value; }
        }
        private string _administrative;
        public string Administrative
        {
            get { return _administrative; }
            set { _administrative = value; }
        }
        private string _economy;
        public string Economy
        {
            get { return _economy; }
            set { _economy = value; }
        }
        private string _travel;
        public string Travel
        {
            get { return _travel; }
            set { _travel = value; }
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
    public enum DL_CityInfoDetailColumns
    {
        Id,
        DL_CityId,
        History,
        Nature,
        Social,
        Administrative,
        Economy,
        Travel,
        CreatedDate,
        Status,
    }
    public enum DL_CityInfoDetailProcedure
    {
        p_DL_CityInfoDetail_Insert,
        p_DL_CityInfoDetail_Delete,
        p_DL_CityInfoDetail_Update,
        p_DL_CityInfoDetail_Get_List,
        p_DL_CityInfoDetail_Get_ByCityID,

    }
}