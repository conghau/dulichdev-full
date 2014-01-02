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
    public class A_ObjectFunctionBAL
    {
        public A_ObjectFunction GetByID(long ID)
        {
            try
            {
                A_ObjectFunctionDAL a_ObjectFunctionDAL = new A_ObjectFunctionDAL();
                return a_ObjectFunctionDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionBAL: GetByID"));
            }
        }
        public List<A_ObjectFunction> GetList()
        {
            try
            {
                A_ObjectFunctionDAL a_ObjectFunctionDAL = new A_ObjectFunctionDAL();
                return a_ObjectFunctionDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionBAL: GetList"));
            }
        }

        public List<A_ObjectFunction> GetListByRoleId(long roleId)
        {
            try
            {
                A_ObjectFunctionDAL a_ObjectFunctionDAL = new A_ObjectFunctionDAL();
                return a_ObjectFunctionDAL.GetListByRoleId(roleId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionBAL: GetListByRoleId"));
            }
        }

        public long Insert(A_ObjectFunction a_ObjectFunction)
        {
            try
            {
                A_ObjectFunctionDAL a_ObjectFunctionDAL = new A_ObjectFunctionDAL();
                return a_ObjectFunctionDAL.Insert(a_ObjectFunction);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionBAL: Insert"));
            }
        }
        public long Update(A_ObjectFunction a_ObjectFunction)
        {
            try
            {
                A_ObjectFunctionDAL a_ObjectFunctionDAL = new A_ObjectFunctionDAL();
                return a_ObjectFunctionDAL.Update(a_ObjectFunction);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_ObjectFunctionDAL a_ObjectFunctionDAL = new A_ObjectFunctionDAL();
                return a_ObjectFunctionDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionBAL: Delete"));
            }
        }
    }
}