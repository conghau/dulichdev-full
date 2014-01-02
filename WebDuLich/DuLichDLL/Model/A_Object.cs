using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class A_Object
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long? _parentID;
        public long? ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }
        private string _objectName;
        public string ObjectName
        {
            get { return _objectName; }
            set { _objectName = value; }
        }
        private int _order;
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }
        private string _objectType;
        public string ObjectType
        {
            get { return _objectType; }
            set { _objectType = value; }
        }
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
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

        public List<A_Function> ListFunction { get; set; }
    }
    public enum A_ObjectColumns
    {
        ID,
        ParentID,
        ObjectName,
        Order,
        ObjectType,
        Url,
        CreatedBy,
        CreatedDate,
        UpdatedBy,
        UpdatedDate,
        Status,
    }
    public enum A_ObjectProcedure
    {
        p_A_Object_Insert,
        p_A_Object_Delete,
        p_A_Object_Update,
        p_A_Object_Get_List,
        p_A_Object_Get_ByID,
        p_A_Object_Get_ListParent,
        p_A_Object_Get_ByParentID,
    }
}