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
    public class A_FunctionBAL
    {
        public A_Function GetByID(long ID)
        {
            try
            {
                A_FunctionDAL a_FunctionDAL = new A_FunctionDAL();
                return a_FunctionDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_FunctionBAL: GetByID"));
            }
        }
        public List<A_Function> GetList()
        {
            try
            {
                A_FunctionDAL a_FunctionDAL = new A_FunctionDAL();
                return a_FunctionDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_FunctionBAL: GetList"));
            }
        }

        public List<A_Function> GetListFunctionByObjectId(long objectId)
        {
            try
            {
                A_FunctionDAL a_FunctionDAL = new A_FunctionDAL();
                return a_FunctionDAL.GetListFunctionByObjectId(objectId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_FunctionBAL: GetList"));
            }
        }

        public List<A_Function> GetListFunctionByObjectIdAndRoleId(long objectId, long roleId)
        {
            try
            {
                A_FunctionDAL a_FunctionDAL = new A_FunctionDAL();
                return a_FunctionDAL.GetListFunctionByObjectIdAndRoleId(objectId, roleId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_FunctionBAL: GetListFunctionByObjectIdAndRoleId"));
            }
        }

        public long Insert(A_Function a_Function)
        {
            try
            {
                A_FunctionDAL a_FunctionDAL = new A_FunctionDAL();
                return a_FunctionDAL.Insert(a_Function);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_FunctionBAL: Insert"));
            }
        }
        public long Update(A_Function a_Function)
        {
            try
            {
                A_FunctionDAL a_FunctionDAL = new A_FunctionDAL();
                return a_FunctionDAL.Update(a_Function);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_FunctionBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_FunctionDAL a_FunctionDAL = new A_FunctionDAL();
                return a_FunctionDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_FunctionBAL: Delete"));
            }
        }
    }
}