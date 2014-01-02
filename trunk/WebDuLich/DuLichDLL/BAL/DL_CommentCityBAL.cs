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
    public class DL_CommentCityBAL
    {
        public DL_CommentCity GetByID(long ID)
        {
            try
            {
                DL_CommentCityDAL dL_CommentCityDAL = new DL_CommentCityDAL();
                return dL_CommentCityDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityBAL: GetByID"));
            }
        }
        public List<DL_CommentCity> GetList()
        {
            try
            {
                DL_CommentCityDAL dL_CommentCityDAL = new DL_CommentCityDAL();
                return dL_CommentCityDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityBAL: GetList"));
            }
        }
        public long Insert(DL_CommentCity dL_CommentCity)
        {
            try
            {
                DL_CommentCityDAL dL_CommentCityDAL = new DL_CommentCityDAL();
                return dL_CommentCityDAL.Insert(dL_CommentCity);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityBAL: Insert"));
            }
        }
        public long Update(DL_CommentCity dL_CommentCity)
        {
            try
            {
                DL_CommentCityDAL dL_CommentCityDAL = new DL_CommentCityDAL();
                return dL_CommentCityDAL.Update(dL_CommentCity);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_CommentCityDAL dL_CommentCityDAL = new DL_CommentCityDAL();
                return dL_CommentCityDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityBAL: Delete"));
            }
        }
    }
}