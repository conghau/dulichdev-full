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
    public class DL_CommentPlaceBAL
    {
        public DL_CommentPlace GetByID(long ID)
        {
            try
            {
                DL_CommentPlaceDAL dL_CommentPlaceDAL = new DL_CommentPlaceDAL();
                return dL_CommentPlaceDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceBAL: GetByID"));
            }
        }
        public List<DL_CommentPlace> GetList()
        {
            try
            {
                DL_CommentPlaceDAL dL_CommentPlaceDAL = new DL_CommentPlaceDAL();
                return dL_CommentPlaceDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceBAL: GetList"));
            }
        }
        public long Insert(DL_CommentPlace dL_CommentPlace)
        {
            try
            {
                DL_CommentPlaceDAL dL_CommentPlaceDAL = new DL_CommentPlaceDAL();
                return dL_CommentPlaceDAL.Insert(dL_CommentPlace);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceBAL: Insert"));
            }
        }
        public long Update(DL_CommentPlace dL_CommentPlace)
        {
            try
            {
                DL_CommentPlaceDAL dL_CommentPlaceDAL = new DL_CommentPlaceDAL();
                return dL_CommentPlaceDAL.Update(dL_CommentPlace);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_CommentPlaceDAL dL_CommentPlaceDAL = new DL_CommentPlaceDAL();
                return dL_CommentPlaceDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceBAL: Delete"));
            }
        }
    }
}