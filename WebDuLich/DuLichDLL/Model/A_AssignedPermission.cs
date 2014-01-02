using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class A_AssignedPermission
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _a_ObjectFunctionID;
        public long A_ObjectFunctionID
        {
            get { return _a_ObjectFunctionID; }
            set { _a_ObjectFunctionID = value; }
        }
        private long _a_RoleID;
        public long A_RoleID
        {
            get { return _a_RoleID; }
            set { _a_RoleID = value; }
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
        private long _a_FunctionId;

        public long A_FunctionId
        {
            get { return _a_FunctionId; }
            set { _a_FunctionId = value; }
        }
        private long _a_ObjectId;

        public long A_ObjectId
        {
            get { return _a_ObjectId; }
            set { _a_ObjectId = value; }
        }
    }
    public enum A_AssignedPermissionColumns
    {
        ID,
        A_ObjectFunctionID,
        A_RoleID,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
        A_FunctionId,
        A_ObjectId,
    }
    public enum A_AssignedPermissionProcedure
    {
        p_A_AssignedPermission_Insert,
        p_A_AssignedPermission_Delete,
        p_A_AssignedPermission_Update,
        p_A_AssignedPermission_Get_List,
        p_A_AssignedPermission_Get_ByID,
        p_A_AssignedPermission_Get_ListByRoleId,
        p_A_AssignedPermission_DeleteAdv,
        p_A_AssignedPermission_InsertAdv,
        p_A_AssignedPermission_HasPermission,
        p_A_AssignedPermission_Get_ListByRoleName,

    }
}