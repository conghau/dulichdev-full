using DuLichDLL.BAL;
using DuLichDLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace WebDuLichDev.WebUtility
{
    public class common
    {
        public static void LoadPagingData(System.Web.Mvc.Controller controller, int page, int pageSize, long totalRecords)
        {
            try
            {
                controller.ViewData["Page"] = page;
                controller.ViewData["PageSize"] = pageSize;
                double PageNum = Math.Ceiling((double)totalRecords / pageSize);
                controller.ViewData["PageNum"] = PageNum;
                controller.ViewData["TotalRecord"] = totalRecords;

                if (totalRecords > 0)
                {
                    if (page == PageNum)
                        controller.ViewData["PageInfo"] = string.Format(GetResourceValue("PageInfo"), (((page - 1) * pageSize) + 1).ToString(), totalRecords.ToString(), totalRecords.ToString());
                    else
                        controller.ViewData["PageInfo"] = string.Format(GetResourceValue("PageInfo"), (((page - 1) * pageSize) + 1).ToString(), (pageSize * page).ToString(), totalRecords.ToString());
                }
            }
            catch
            {
                throw;
            }
        }
        public static string GetResourceValue(string resourceName)
        {
            string value = string.Empty;

            value = DuLichDLL.Utility.Utility.ObjectToString(HttpContext.GetGlobalResourceObject("Language", resourceName));
            if (string.IsNullOrWhiteSpace(value))
            {
                value = resourceName;
            }

            return value;
        }

        #region Menu
        public static string RenderMenu()
        {
            string menu = string.Empty;
            A_ObjectBAL objectBal = new A_ObjectBAL();
            A_AssignedPermissionBAL assignedpermissionBal = new A_AssignedPermissionBAL();
            A_UserProfileBAL userProfileBal = new A_UserProfileBAL();
            //userProfileBal.

            try
            {
                List<A_Object> listObject = objectBal.GetList();

                var listRolesForUser = Roles.GetRolesForUser(WebSecurity.CurrentUserName);
                string roleName = listRolesForUser[0];
                List<A_AssignedPermission> listPermission = assignedpermissionBal.GetList(roleName);

                List<A_Object> listParent = new List<A_Object>();
                listParent = objectBal.GetListParent().OrderBy(m=>m.Order).ToList();
                listObject.RemoveAll(m => m.ParentID == 0);
                foreach (A_Object item in listParent)
                {
                    menu = menu + BuildChildNode(item, listObject, listPermission);
                }
                return menu;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        private static string BuildChildNode(A_Object node, List<A_Object> listObject, List<A_AssignedPermission> listPermission)
        {
            try
            {
                string menu = "<li class=\"dropdown item\"><a class=\"dropdown-toggle\" data-toggle=\"dropdown\" href=\"#\">" + node.ObjectName + "<b class=\"caret\"></b></a><ul class=\"dropdown-menu\"> ";

                if (node.ObjectType != WebDuLichDev.WebUtility.Enum.ObjectType.WebPartial.ToString())
                {
                    UrlHelper url = new UrlHelper(HttpContext.Current.Request.RequestContext);
                    List<A_Object> listChild = new List<A_Object>();
                    listChild = listObject.Where(m => m.ParentID == node.ID).ToList();
                    listChild = listChild.OrderBy(m => m.Order).ToList();                  
                    if (listChild.Count > 0)
                    {
                        int countChild = listChild.Count;
                        string href = string.Empty;
                        foreach (A_Object item in listChild)
                        {
                            if (listPermission.Where(m => m.A_ObjectId == item.ID && m.A_FunctionId == 1).Count() > 0)
                            {
                                if (!string.IsNullOrWhiteSpace(item.Url))
                                {
                                    string[] link = item.Url.Split('/');
                                    string actionName = link[1];
                                    string controllerName = link[0];
                                    href = url.Action(actionName, controllerName);
                                }
                                else
                                {
                                    href = "#";
                                }
                                menu = menu + "<li class=\"dropdown-item\"><a href=\"" + href + "\" title=\"niceplace\">" + item.ObjectName + "</a></li>";

                            }
                            else
                            {
                                countChild--;
                            }
                            
                        }
                        if (0 == countChild)
                        {
                            menu = string.Empty;
                        }
                        else
                        {
                            menu = menu + "</ul></li>"; 
                        }
                    }

                    return menu;
                }
                return string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}