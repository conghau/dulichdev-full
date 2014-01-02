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
    public class DL_CategoryBAL
    {
        public DL_Category GetByID(long ID)
        {
            try
            {
                DL_CategoryDAL dL_CategoryDAL = new DL_CategoryDAL();
                return dL_CategoryDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CategoryBAL: GetByID"));
            }
        }
        public List<DL_Category> GetList()
        {
            try
            {
                DL_CategoryDAL dL_CategoryDAL = new DL_CategoryDAL();
                return dL_CategoryDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CategoryBAL: GetList"));
            }
        }
        public long Insert(DL_Category dL_Category)
        {
            try
            {
                DL_CategoryDAL dL_CategoryDAL = new DL_CategoryDAL();
                return dL_CategoryDAL.Insert(dL_Category);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CategoryBAL: Insert"));
            }
        }
        public long Update(DL_Category dL_Category)
        {
            try
            {
                DL_CategoryDAL dL_CategoryDAL = new DL_CategoryDAL();
                return dL_CategoryDAL.Update(dL_Category);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CategoryBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_CategoryDAL dL_CategoryDAL = new DL_CategoryDAL();
                return dL_CategoryDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CategoryBAL: Delete"));
            }
        }
    }
}