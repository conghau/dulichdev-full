using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DL_Category
    {
        private long _iD;
        public long ID
        {
            get { return _iD; }
            set { _iD = value; }
        }
        private long? _parentId;
        public long? ParentId
        {
            get { return _parentId; }
            set { _parentId = value; }
        }
        private string _category;
        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }
        private int? _status;
        public int? Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
    public enum DL_CategoryColumns
    {
        ID,
        ParentId,
        Category,
        Status,
    }
    public enum DL_CategoryProcedure
    {
        p_DL_Category_Insert,
        p_DL_Category_Delete,
        p_DL_Category_Update,
        p_DL_Category_Get_List,
        p_DL_Category_Get_ByID,

    }
}