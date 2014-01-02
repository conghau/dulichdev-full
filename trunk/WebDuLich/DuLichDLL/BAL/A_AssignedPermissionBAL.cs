using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DuLichDLL.Model;
using DuLichDLL.DAL;
using DuLichDLL.ExceptionType;
using DuLichDLL.Enum;
using System.Data;
using System.Configuration;
using System.Web.Security;
namespace DuLichDLL.BAL
{
    public class A_AssignedPermissionBAL
    {
        public A_AssignedPermission GetByID(long ID)
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
                return a_AssignedPermissionDAL.GetByID(ID);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: GetByID"));
            }
        }
        public List<A_AssignedPermission> GetList()
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
                return a_AssignedPermissionDAL.GetList();
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: GetList"));
            }
        }

        public List<A_AssignedPermission> GetList(long roleId)
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
                return a_AssignedPermissionDAL.GetList(roleId);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: GetList"));
            }
        }

        public List<A_AssignedPermission> GetList(string roleName)
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
                return a_AssignedPermissionDAL.GetList(roleName);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: GetList"));
            }
        }

        public long Insert(A_AssignedPermission a_AssignedPermission)
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
                return a_AssignedPermissionDAL.Insert(a_AssignedPermission);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: Insert"));
            }
        }

        public long Insert(A_AssignedPermission a_AssignedPermission, long funtionId, long ObjectId)
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
                return a_AssignedPermissionDAL.Insert(a_AssignedPermission, funtionId, ObjectId);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: Insert"));
            }
        }
        public long Update(A_AssignedPermission a_AssignedPermission)
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
                return a_AssignedPermissionDAL.Update(a_AssignedPermission);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: Update"));
            }
        }
        public long Delete(long roleId, long functionId, long ObjectId)
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();
                return a_AssignedPermissionDAL.Delete(roleId, functionId, ObjectId);
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: Delete"));
            }
        }

        public bool HasPermisson(string userName, string functionName, string objectName)
        {
            try
            {
                A_AssignedPermissionDAL a_AssignedPermissionDAL = new A_AssignedPermissionDAL();

                bool result = false;
                var listRolesForUser = Roles.GetRolesForUser(userName);
                if (null == listRolesForUser)
                    return false;
                else
                {
                    for (int index = 0; index < listRolesForUser.Count();index++ )
                    {
                        if (true == a_AssignedPermissionDAL.HasPermission(listRolesForUser[index], functionName, objectName))
                        {
                            result = true;
                            break;

                        }
                    }
                    return result;
                }
            }
            catch (DataAccessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionBAL: HasPermisson"));
            }
        }
    }
}