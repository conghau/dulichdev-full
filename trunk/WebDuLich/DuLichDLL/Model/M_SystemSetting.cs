using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class M_SystemSetting
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _attribute;
        public string Attribute
        {
            get { return _attribute; }
            set { _attribute = value; }
        }
        private string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
    public enum M_SystemSettingColumns
    {
        ID,
        Attribute,
        Value,
        Status,
    }
    public enum M_SystemSettingProcedure
    {
        p_M_SystemSetting_Insert,
        p_M_SystemSetting_Delete,
        p_M_SystemSetting_Update,
        p_M_SystemSetting_Get_List,
        p_M_SystemSetting_Get_ByID,

    }
}