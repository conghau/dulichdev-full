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
    public class A_RoleBAL
    {
        public A_Role GetByID(long ID)
        {
            try
            {
                A_RoleDAL a_RoleDAL = new A_RoleDAL();
                return a_RoleDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RoleBAL: GetByID"));
            }
        }
        public List<A_Role> GetList()
        {
            try
            {
                A_RoleDAL a_RoleDAL = new A_RoleDAL();
                return a_RoleDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RoleBAL: GetList"));
            }
        }
        public long Insert(A_Role a_Role)
        {
            try
            {
                A_RoleDAL a_RoleDAL = new A_RoleDAL();
                return a_RoleDAL.Insert(a_Role);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RoleBAL: Insert"));
            }
        }
        public long Update(A_Role a_Role)
        {
            try
            {
                A_RoleDAL a_RoleDAL = new A_RoleDAL();
                return a_RoleDAL.Update(a_Role);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RoleBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_RoleDAL a_RoleDAL = new A_RoleDAL();
                return a_RoleDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RoleBAL: Delete"));
            }
        }
    }
}