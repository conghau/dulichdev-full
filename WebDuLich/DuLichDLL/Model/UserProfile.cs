using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class DLUserProfile
    {
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
    }
    public enum DLUserProfileColumns
    {
        UserId,
        UserName,
    }
    public enum DLUserProfileProcedure
    {
        p_UserProfile_Insert,
        p_UserProfile_Delete,
        p_UserProfile_Update,
        p_UserProfile_Get_List,
        p_UserProfile_Get_ByID,
        p_UserProfile_ByUserName,
    }
}