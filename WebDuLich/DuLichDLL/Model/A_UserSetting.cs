using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class A_UserSetting
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _a_UserProfileID;
        public long A_UserProfileID
        {
            get { return _a_UserProfileID; }
            set { _a_UserProfileID = value; }
        }
        private long _m_LanguageID;
        public long M_LanguageID
        {
            get { return _m_LanguageID; }
            set { _m_LanguageID = value; }
        }
        private string _dateFormat;
        public string DateFormat
        {
            get { return _dateFormat; }
            set { _dateFormat = value; }
        }
        private string _timeFormat;
        public string TimeFormat
        {
            get { return _timeFormat; }
            set { _timeFormat = value; }
        }
        private long _createdBy;
        public long CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        private DateTime _createdDate;
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }
        private long _updatedBy;
        public long UpdatedBy
        {
            get { return _updatedBy; }
            set { _updatedBy = value; }
        }
        private DateTime _updatedDate;
        public DateTime UpdatedDate
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
    public enum A_UserSettingColumns
    {
        ID,
        A_UserProfileID,
        M_LanguageID,
        DateFormat,
        TimeFormat,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
    }
    public enum A_UserSettingProcedure
    {
        p_A_UserSetting_Insert,
        p_A_UserSetting_Delete,
        p_A_UserSetting_Update,
        p_A_UserSetting_Get_List,
        p_A_UserSetting_Get_ByID,

    }
}