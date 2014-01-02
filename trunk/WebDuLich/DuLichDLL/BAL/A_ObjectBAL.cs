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
    public class A_ObjectBAL
    {
        public A_Object GetByID(long ID)
        {
            try
            {
                A_ObjectDAL a_ObjectDAL = new A_ObjectDAL();
                return a_ObjectDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectBAL: GetByID"));
            }
        }
        public List<A_Object> GetList()
        {
            try
            {
                A_ObjectDAL a_ObjectDAL = new A_ObjectDAL();
                return a_ObjectDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectBAL: GetList"));
            }
        }

        public List<A_Object> GetListParent()
        {
            try
            {
                A_ObjectDAL a_ObjectDAL = new A_ObjectDAL();
                return a_ObjectDAL.GetListParent();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectBAL: GetListParent"));
            }
        }

        public List<A_Object> GetListByParentId(long parentId)
        {
            try
            {
                A_ObjectDAL a_ObjectDAL = new A_ObjectDAL();
                return a_ObjectDAL.GetListByParentId(parentId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectBAL: GetListByParentId"));
            }
        }

        public long Insert(A_Object a_Object)
        {
            try
            {
                A_ObjectDAL a_ObjectDAL = new A_ObjectDAL();
                return a_ObjectDAL.Insert(a_Object);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectBAL: Insert"));
            }
        }
        public long Update(A_Object a_Object)
        {
            try
            {
                A_ObjectDAL a_ObjectDAL = new A_ObjectDAL();
                return a_ObjectDAL.Update(a_Object);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_ObjectDAL a_ObjectDAL = new A_ObjectDAL();
                return a_ObjectDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectBAL: Delete"));
            }
        }
    }
}