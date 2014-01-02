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
    public class A_RolesTranslationBAL
    {
        public A_RolesTranslation GetByID(long ID)
        {
            try
            {
                A_RolesTranslationDAL a_RolesTranslationDAL = new A_RolesTranslationDAL();
                return a_RolesTranslationDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationBAL: GetByID"));
            }
        }
        public List<A_RolesTranslation> GetList()
        {
            try
            {
                A_RolesTranslationDAL a_RolesTranslationDAL = new A_RolesTranslationDAL();
                return a_RolesTranslationDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationBAL: GetList"));
            }
        }
        public long Insert(A_RolesTranslation a_RolesTranslation)
        {
            try
            {
                A_RolesTranslationDAL a_RolesTranslationDAL = new A_RolesTranslationDAL();
                return a_RolesTranslationDAL.Insert(a_RolesTranslation);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationBAL: Insert"));
            }
        }
        public long Update(A_RolesTranslation a_RolesTranslation)
        {
            try
            {
                A_RolesTranslationDAL a_RolesTranslationDAL = new A_RolesTranslationDAL();
                return a_RolesTranslationDAL.Update(a_RolesTranslation);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_RolesTranslationDAL a_RolesTranslationDAL = new A_RolesTranslationDAL();
                return a_RolesTranslationDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationBAL: Delete"));
            }
        }
    }
}