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
    public class DL_LikePlaceBAL
    {
        public DL_LikePlace GetByID(long ID)
        {
            try
            {
                DL_LikePlaceDAL dL_LikePlaceDAL = new DL_LikePlaceDAL();
                return dL_LikePlaceDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_LikePlaceBAL: GetByID"));
            }
        }
        public List<DL_LikePlace> GetList()
        {
            try
            {
                DL_LikePlaceDAL dL_LikePlaceDAL = new DL_LikePlaceDAL();
                return dL_LikePlaceDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_LikePlaceBAL: GetList"));
            }
        }
        public long Insert(DL_LikePlace dL_LikePlace)
        {
            try
            {
                DL_LikePlaceDAL dL_LikePlaceDAL = new DL_LikePlaceDAL();
                return dL_LikePlaceDAL.Insert(dL_LikePlace);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_LikePlaceBAL: Insert"));
            }
        }
        public long Update(DL_LikePlace dL_LikePlace)
        {
            try
            {
                DL_LikePlaceDAL dL_LikePlaceDAL = new DL_LikePlaceDAL();
                return dL_LikePlaceDAL.Update(dL_LikePlace);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_LikePlaceBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_LikePlaceDAL dL_LikePlaceDAL = new DL_LikePlaceDAL();
                return dL_LikePlaceDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_LikePlaceBAL: Delete"));
            }
        }
    }
}