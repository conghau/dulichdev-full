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
    public class A_UserRoleBAL
    {
        public A_UserRole GetByID(long ID)
        {
            try
            {
                A_UserRoleDAL a_UserRoleDAL = new A_UserRoleDAL();
                return a_UserRoleDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleBAL: GetByID"));
            }
        }
        public List<A_UserRole> GetList()
        {
            try
            {
                A_UserRoleDAL a_UserRoleDAL = new A_UserRoleDAL();
                return a_UserRoleDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleBAL: GetList"));
            }
        }
        public long Insert(A_UserRole a_UserRole)
        {
            try
            {
                A_UserRoleDAL a_UserRoleDAL = new A_UserRoleDAL();
                return a_UserRoleDAL.Insert(a_UserRole);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleBAL: Insert"));
            }
        }
        public long Update(A_UserRole a_UserRole)
        {
            try
            {
                A_UserRoleDAL a_UserRoleDAL = new A_UserRoleDAL();
                return a_UserRoleDAL.Update(a_UserRole);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_UserRoleDAL a_UserRoleDAL = new A_UserRoleDAL();
                return a_UserRoleDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleBAL: Delete"));
            }
        }
    }
}