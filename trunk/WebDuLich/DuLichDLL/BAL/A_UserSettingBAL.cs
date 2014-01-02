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
    public class A_UserSettingBAL
    {
        public A_UserSetting GetByID(long ID)
        {
            try
            {
                A_UserSettingDAL a_UserSettingDAL = new A_UserSettingDAL();
                return a_UserSettingDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingBAL: GetByID"));
            }
        }
        public List<A_UserSetting> GetList()
        {
            try
            {
                A_UserSettingDAL a_UserSettingDAL = new A_UserSettingDAL();
                return a_UserSettingDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingBAL: GetList"));
            }
        }
        public long Insert(A_UserSetting a_UserSetting)
        {
            try
            {
                A_UserSettingDAL a_UserSettingDAL = new A_UserSettingDAL();
                return a_UserSettingDAL.Insert(a_UserSetting);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingBAL: Insert"));
            }
        }
        public long Update(A_UserSetting a_UserSetting)
        {
            try
            {
                A_UserSettingDAL a_UserSettingDAL = new A_UserSettingDAL();
                return a_UserSettingDAL.Update(a_UserSetting);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_UserSettingDAL a_UserSettingDAL = new A_UserSettingDAL();
                return a_UserSettingDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingBAL: Delete"));
            }
        }
    }
}