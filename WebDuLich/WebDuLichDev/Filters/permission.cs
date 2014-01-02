using DuLichDLL.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace WebDuLichDev.Filters
{
    public class PermissionAttribute : AuthorizeAttribute
    {
        private EPermissionType permissionType;

        public string ObName { get; set; }
        public string FnName { get; set; }

        public PermissionAttribute(string obName, string fnName)
        {
            ObName = obName;
            FnName = fnName;

            permissionType = EPermissionType.Authorization;
        }
        public PermissionAttribute()
        {
            permissionType = EPermissionType.Authentication;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = WebSecurity.IsAuthenticated;
            if (!isAuthorized)
            {
                return false;
            }

            switch (permissionType)
            {
                case EPermissionType.Authorization:
                    A_AssignedPermissionBAL assignedBal = new A_AssignedPermissionBAL();
                    return assignedBal.HasPermisson(WebSecurity.CurrentUserName, FnName, ObName);

                case EPermissionType.Authentication:
                    return true;

                default:
                    return false;
            }
        }
    }

    public enum EPermissionType
    {
        Authentication,
        Authorization
    }
}