using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class A_Function
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private string _functionName;
        public string FunctionName
        {
            get { return _functionName; }
            set { _functionName = value; }
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

        public bool? isHasPermission { get; set; }
    }
    public enum A_FunctionColumns
    {
        ID,
        FunctionName,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
    }
    public enum A_FunctionProcedure
    {
        p_A_Function_Insert,
        p_A_Function_Delete,
        p_A_Function_Update,
        p_A_Function_Get_List,
        p_A_Function_Get_ByID,
        p_A_Function_Get_ByObjectID,
        p_A_Function_Get_ByObjectIDAndRoleId,

    }

    public enum A_FunctionName
    {
        View,
        Insert,
        Delete,
        Asign,
    }
}