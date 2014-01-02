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
    public class UserProfileBAL
    {
        public DLUserProfile GetByID(long ID)
        {
            try
            {
                UserProfileDAL userProfileDAL = new UserProfileDAL();
                return userProfileDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileBAL: GetByID"));
            }
        }

        public DLUserProfile GetByUserName(string userName)
        {
            try
            {
                UserProfileDAL userProfileDAL = new UserProfileDAL();
                return userProfileDAL.GetByUserName(userName);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileBAL: GetUserIdByUserName"));
            }
        }
        public List<DLUserProfile> GetList()
        {
            try
            {
                UserProfileDAL userProfileDAL = new UserProfileDAL();
                return userProfileDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileBAL: GetList"));
            }
        }
        public long Insert(DLUserProfile userProfile)
        {
            try
            {
                UserProfileDAL userProfileDAL = new UserProfileDAL();
                return userProfileDAL.Insert(userProfile);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileBAL: Insert"));
            }
        }
        public long Update(DLUserProfile userProfile)
        {
            try
            {
                UserProfileDAL userProfileDAL = new UserProfileDAL();
                return userProfileDAL.Update(userProfile);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                UserProfileDAL userProfileDAL = new UserProfileDAL();
                return userProfileDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileBAL: Delete"));
            }
        }
    }
}