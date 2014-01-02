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
namespace DuLichDLL.BAL
{
    public class webpages_UsersInRolesBAL
    {
        public webpages_UsersInRoles GetByID(long ID)
        {
            try
            {
                webpages_UsersInRolesDAL webpages_UsersInRolesDAL = new webpages_UsersInRolesDAL();
                return webpages_UsersInRolesDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesBAL: GetByID"));
            }
        }
        public List<webpages_UsersInRoles> GetList()
        {
            try
            {
                webpages_UsersInRolesDAL webpages_UsersInRolesDAL = new webpages_UsersInRolesDAL();
                return webpages_UsersInRolesDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesBAL: GetList"));
            }
        }
        public long Insert(webpages_UsersInRoles webpages_UsersInRoles)
        {
            try
            {
                webpages_UsersInRolesDAL webpages_UsersInRolesDAL = new webpages_UsersInRolesDAL();
                return webpages_UsersInRolesDAL.Insert(webpages_UsersInRoles);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesBAL: Insert"));
            }
        }
        public long Update(webpages_UsersInRoles webpages_UsersInRoles)
        {
            try
            {
                webpages_UsersInRolesDAL webpages_UsersInRolesDAL = new webpages_UsersInRolesDAL();
                return webpages_UsersInRolesDAL.Update(webpages_UsersInRoles);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesBAL: Update"));
            }
        }
        public long Delete(long userID)
        {
            try
            {
                webpages_UsersInRolesDAL webpages_UsersInRolesDAL = new webpages_UsersInRolesDAL();
                return webpages_UsersInRolesDAL.Delete(userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesBAL: Delete"));
            }
        }

        public bool UserIsAdmin(long userId)
        {
            try
            {
                webpages_UsersInRolesDAL webpages_UsersInRolesDAL = new webpages_UsersInRolesDAL();
                return webpages_UsersInRolesDAL.UserIsAdmin(userId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesBAL: UserIsAdmin"));
            }
        }
        public long UpdateRoleforUser(webpages_UsersInRoles webpages_UsersInRoles)
        {
            try
            {
                webpages_UsersInRolesDAL webpages_UsersInRolesDAL = new webpages_UsersInRolesDAL();
                return webpages_UsersInRolesDAL.UpdateRoleforUser(webpages_UsersInRoles);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesBAL: UpdateRoleforUser"));
            }
        }
    }
}