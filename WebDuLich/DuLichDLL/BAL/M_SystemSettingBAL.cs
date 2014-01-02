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
    public class M_SystemSettingBAL
    {
        public M_SystemSetting GetByID(long ID)
        {
            try
            {
                M_SystemSettingDAL m_SystemSettingDAL = new M_SystemSettingDAL();
                return m_SystemSettingDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingBAL: GetByID"));
            }
        }
        public List<M_SystemSetting> GetList()
        {
            try
            {
                M_SystemSettingDAL m_SystemSettingDAL = new M_SystemSettingDAL();
                return m_SystemSettingDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingBAL: GetList"));
            }
        }
        public long Insert(M_SystemSetting m_SystemSetting)
        {
            try
            {
                M_SystemSettingDAL m_SystemSettingDAL = new M_SystemSettingDAL();
                return m_SystemSettingDAL.Insert(m_SystemSetting);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingBAL: Insert"));
            }
        }
        public long Update(M_SystemSetting m_SystemSetting)
        {
            try
            {
                M_SystemSettingDAL m_SystemSettingDAL = new M_SystemSettingDAL();
                return m_SystemSettingDAL.Update(m_SystemSetting);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                M_SystemSettingDAL m_SystemSettingDAL = new M_SystemSettingDAL();
                return m_SystemSettingDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingBAL: Delete"));
            }
        }

        public M_SystemSetting_Config GetSystemSetting()
        {
            try
            {
                M_SystemSettingDAL m_SystemSettingDAL = new M_SystemSettingDAL();
                return m_SystemSettingDAL.GetSystemSetting();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingBAL: GetSystemSetting"));
            }
        }
    }
}