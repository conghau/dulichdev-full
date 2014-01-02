using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDuLichDev.Models;
using DuLichDLL.Model;
using WebDuLichDev.Filters;
using DuLichDLL.Utility;
using WebDuLichDev.WebUtility;
using DuLichDLL.BAL;
using System.Web.Security;
using WebDuLichDev.Enum;
using DuLichDLL.ExceptionType;
using DuLichDLL.Enum;
using WebMatrix.WebData;
namespace WebDuLichDev.Controllers
{
    public class RoleController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(RoleController).Name);
        string version = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " ";

        [Permission("Roles","View")]
        public ActionResult Manage()
        {
            try
            {
                vm_Pagination pagination = new vm_Pagination
                {
                    Page = MvcApplication.pageDefault,
                    PageSize = MvcApplication.pageSizeDefault,
                    OrderBy = webpages_RolesColumns.RoleName.ToString(),
                    OrderDirection = "ASC",

                };
                long totalRecords = 0;
                webpages_RolesBAL wpRolesBAL = new webpages_RolesBAL();
                var model = wpRolesBAL.GetListWithCountNumberUser(pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
                common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
                ViewData["OrderBy"] = pagination.OrderBy;
                ViewData["OrderDirection"] = pagination.OrderDirection;

                return View(model);
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public ActionResult Manage(vm_Pagination pagination)
        {
            try
            {

                long totalRecords = 0;
                webpages_RolesBAL wpRolesBAL = new webpages_RolesBAL();
                var model = wpRolesBAL.GetListWithCountNumberUser(pagination.Page.Value, pagination.PageSize.Value, pagination.OrderBy, pagination.OrderDirection, out totalRecords);
                common.LoadPagingData(this, pagination.Page ?? MvcApplication.pageDefault, pagination.PageSize ?? MvcApplication.pageSizeDefault, totalRecords);
                ViewData["OrderBy"] = pagination.OrderBy;
                ViewData["OrderDirection"] = pagination.OrderDirection;

                return View(model);
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // GET: /ManagerUserRole/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /ManagerUserRole/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ManagerUserRole/Create

        [HttpPost]
        public ActionResult Create(webpages_Roles roles)
        {
            try
            {
                webpages_RolesBAL roleBal = new webpages_RolesBAL();

                var listRolesNamePresent = roleBal.GetList().Select(m => m.RoleName).ToList();
                long result = 0;

                roles.RoleName = roles.RoleName.Trim().ToUpper();
                if (ModelState.IsValid)
                {
                    if (false == listRolesNamePresent.Any(m => listRolesNamePresent.Contains(roles.RoleName)))
                    {
                        result = roleBal.Insert(roles);
                    }
                    else
                        result = -1;

                }
                if (-1 == result)
                {
                    TempData["Message"] = ResultMessage.ERR_Exist;
                    return View(roles);
                }
                if (0 == result)
                {
                    TempData["Message"] = ResultMessage.ERR_Insert;
                    return View(roles);
                }
                else
                {
                    TempData["Message"] = ResultMessage.SUC_Insert;
                    return View(roles);
                }

            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
        }

        //
        // GET: /ManagerUserRole/Edit/5

        [Authorize]
        public ActionResult UpdateRole(long ID)
        {
            ViewBag.RoleId = ID;

            webpages_RolesBAL roleBal = new webpages_RolesBAL();
            A_AssignedPermissionBAL assignPermisstionBal = new A_AssignedPermissionBAL();
            A_FunctionBAL funcitionBal = new A_FunctionBAL();
            A_ObjectBAL objectBal = new A_ObjectBAL();
            A_ObjectFunctionBAL ObFnBal = new A_ObjectFunctionBAL();

            var listParentObject = objectBal.GetListParent();
            var model = new List<ObjectParent>();


            if(null != listParentObject)
                for(int index=0; index <listParentObject.Count;index++)
                {
                    ObjectParent tmp = new ObjectParent();
                    tmp.ObjectParentName = listParentObject[index].ObjectName;
                    
                    var objectTmp = objectBal.GetListByParentId(listParentObject[index].ID);
                    foreach(var item in objectTmp)
                    {
                        
                        var listFunctionbyObId = funcitionBal.GetListFunctionByObjectId(item.ID);
                        var listFuncionHasPermission = funcitionBal.GetListFunctionByObjectIdAndRoleId(item.ID, ID);
                        foreach(var func in listFuncionHasPermission)
                            listFunctionbyObId.Where(m => m.ID == func.ID).Single().isHasPermission = true;
                        item.ListFunction  = listFunctionbyObId;
                    }

                    tmp.ListObject = objectTmp;
                    model.Add(tmp);
                }  
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public ActionResult UpdateRole(long ID, List<vm_EditRole> listEditRole)
        {
            try
            {
                bool result=false;
                A_AssignedPermissionBAL assignedPermissionBal = new A_AssignedPermissionBAL();
                for (int index = 0; index < listEditRole.Count; index++)
                {
                    if (true == listEditRole[index].Checked)
                    {
                        A_AssignedPermission item = new A_AssignedPermission();
                        item.A_RoleID = ID;
                        item.Status = 0;
                        item.CreatedBy = 1;
                        item.UpdatedBy = WebSecurity.CurrentUserId;
                        assignedPermissionBal.Insert(item, listEditRole[index].FunctionId, listEditRole[index].ObjectId);
                    }
                    else
                    {
                        assignedPermissionBal.Delete(ID, listEditRole[index].FunctionId, listEditRole[index].ObjectId);
                    }
                }
                return View("Manage"); 
            }
            catch (BusinessException bx)
            {
                log.Error(bx.Message);
                //TempData[PageInfo.Message.ToString()] = bx.Message;
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                log.Error(version + ExceptionMessage.throwEx(ex, "ERROR_RoleController: UpdateRole"));
                
                TempData[PageInfo.Message.ToString()] = "BLM_ERR_Common";
                return RedirectToAction("Error", "Home");
            }
            
        }

        public ActionResult Edit(int roleId)
        {
            ManagerUserRole manageUserRole = new ManagerUserRole();
            UserProfileBAL userProfileBAL = new UserProfileBAL();

            webpages_UsersInRolesBAL wpUserInRolesBAL = new webpages_UsersInRolesBAL();
            var userlist = userProfileBAL.GetList();
            var inrole = wpUserInRolesBAL.GetList();
            webpages_RolesBAL roleBal = new webpages_RolesBAL();
            var roleName = roleBal.GetByID(roleId).RoleName;
            List<DLUserProfile> userlistinrole = new List<DLUserProfile>();
            List<DLUserProfile> userlistnotinrole = new List<DLUserProfile>();
            foreach (var user in userlist)
            {
                var i = 0;
                foreach (var roleitem in inrole)
                {
                    if ((roleitem.RoleId == roleId) & (user.UserId == roleitem.UserId))
                    {
                        userlistinrole.Add(user);
                        //i++;
                    }
                    else
                    {
                        i++;
                        if (i == inrole.Count())
                            userlistnotinrole.Add(user);
                    }
                }
            }
            userlistinrole.ToList();
            manageUserRole.listUserProfile = userlistinrole;
            manageUserRole.listwpUserInRoles = wpUserInRolesBAL.GetList();
            manageUserRole.listUserProfileNotInRole = userlistnotinrole;

            ViewBag.RoleId = roleId;
            ViewBag.RoleName = roleName;
            var model = manageUserRole;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(int roleId, int[] UserID)
        {
            //lay duoc userID can gan
            //update lai role cho UserId
            UserProfileBAL userProfileBAL = new UserProfileBAL();
            webpages_UsersInRolesBAL wpUserInRoleBal = new webpages_UsersInRolesBAL();

            if (null != UserID)
            {
                for (int index = 0; index < UserID.Count(); index++)
                {
                    webpages_UsersInRoles userinRole = new webpages_UsersInRoles
                    {
                        UserId = UserID[index],
                        RoleId = roleId,
                    };
                    wpUserInRoleBal.UpdateRoleforUser(userinRole);
                }
            }
            return RedirectToAction("Edit", new { roleId = roleId });
        }

        [HttpPost]
        public ActionResult DelUser(long roleId, int[] UserID)
        {
            webpages_UsersInRolesBAL wpUserInRoleBal = new webpages_UsersInRolesBAL();
            if (null != UserID)
            {
                for (int index = 0; index < UserID.Count(); index++)
                {

                    wpUserInRoleBal.Delete(UserID[index]);
                }
            }
            return RedirectToAction("Edit", new { roleId = roleId });
        }
        //
        // POST: /ManagerUserRole/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ManagerUserRole/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ManagerUserRole/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
