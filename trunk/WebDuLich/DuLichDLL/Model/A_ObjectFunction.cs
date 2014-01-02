using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class A_ObjectFunction
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long _a_ObjectID;
        public long A_ObjectID
        {
            get { return _a_ObjectID; }
            set { _a_ObjectID = value; }
        }
        private long _a_FunctionID;
        public long A_FunctionID
        {
            get { return _a_FunctionID; }
            set { _a_FunctionID = value; }
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
    public enum A_ObjectFunctionColumns
    {
        ID,
        A_ObjectID,
        A_FunctionID,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
    }
    public enum A_ObjectFunctionProcedure
    {
        p_A_ObjectFunction_Insert,
        p_A_ObjectFunction_Delete,
        p_A_ObjectFunction_Update,
        p_A_ObjectFunction_Get_List,
        p_A_ObjectFunction_Get_ByID,
        p_A_ObjectFunction_Get_ByRoleID,

    }
}