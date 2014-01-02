using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DuLichDLL.Model
{
    public class webpages_UsersInRoles
    {
        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        private int _roleId;
        public int RoleId
        {
            get { return _roleId; }
            set { _roleId = value; }
        }

    }
    public enum webpages_UsersInRolesColumns
    {
        UserId,
        RoleId,

    }
    public enum webpages_UsersInRolesProcedure
    {
        p_webpages_UsersInRoles_Insert,
        p_webpages_UsersInRoles_Delete,
        p_webpages_UsersInRoles_Update,
        p_webpages_UsersInRoles_Get_List,
        p_webpages_UsersInRoles_Get_ByID,
        p_IsAdminByUserId,
        p_webpages_UsersInRoles_UpdateRoleforUser,

    }
}