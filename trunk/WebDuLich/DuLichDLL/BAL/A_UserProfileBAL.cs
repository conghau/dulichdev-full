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
    public class A_UserProfileBAL
    {
        public A_UserProfile GetByID(long ID)
        {
            try
            {
                A_UserProfileDAL a_UserProfileDAL = new A_UserProfileDAL();
                return a_UserProfileDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileBAL: GetByID"));
            }
        }
        public List<A_UserProfile> GetList()
        {
            try
            {
                A_UserProfileDAL a_UserProfileDAL = new A_UserProfileDAL();
                return a_UserProfileDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileBAL: GetList"));
            }
        }
        public long Insert(A_UserProfile a_UserProfile)
        {
            try
            {
                A_UserProfileDAL a_UserProfileDAL = new A_UserProfileDAL();
                return a_UserProfileDAL.Insert(a_UserProfile);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileBAL: Insert"));
            }
        }
        public long Update(A_UserProfile a_UserProfile)
        {
            try
            {
                A_UserProfileDAL a_UserProfileDAL = new A_UserProfileDAL();
                return a_UserProfileDAL.Update(a_UserProfile);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_UserProfileDAL a_UserProfileDAL = new A_UserProfileDAL();
                return a_UserProfileDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileBAL: Delete"));
            }
        }
    }
}