using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class A_RolesTranslation
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _m_LanguageID;
        public long M_LanguageID
        {
            get { return _m_LanguageID; }
            set { _m_LanguageID = value; }
        }
        private long _a_RoleID;
        public long A_RoleID
        {
            get { return _a_RoleID; }
            set { _a_RoleID = value; }
        }
        private string _roleName;
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
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
    public enum A_RolesTranslationColumns
    {
        ID,
        M_LanguageID,
        A_RoleID,
        RoleName,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
    }
    public enum A_RolesTranslationProcedure
    {
        p_A_RolesTranslation_Insert,
        p_A_RolesTranslation_Delete,
        p_A_RolesTranslation_Update,
        p_A_RolesTranslation_Get_List,
        p_A_RolesTranslation_Get_ByID,

    }
}