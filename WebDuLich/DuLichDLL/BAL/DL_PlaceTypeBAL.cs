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
    public class DL_PlaceTypeBAL
    {
        public DL_PlaceType GetByID(long ID)
        {
            try
            {
                DL_PlaceTypeDAL dL_PlaceTypeDAL = new DL_PlaceTypeDAL();
                return dL_PlaceTypeDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceTypeBAL: GetByID"));
            }
        }
        public List<DL_PlaceType> GetList()
        {
            try
            {
                DL_PlaceTypeDAL dL_PlaceTypeDAL = new DL_PlaceTypeDAL();
                return dL_PlaceTypeDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceTypeBAL: GetList"));
            }
        }
        public long Insert(DL_PlaceType dL_PlaceType)
        {
            try
            {
                DL_PlaceTypeDAL dL_PlaceTypeDAL = new DL_PlaceTypeDAL();
                return dL_PlaceTypeDAL.Insert(dL_PlaceType);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceTypeBAL: Insert"));
            }
        }
        public long Update(DL_PlaceType dL_PlaceType)
        {
            try
            {
                DL_PlaceTypeDAL dL_PlaceTypeDAL = new DL_PlaceTypeDAL();
                return dL_PlaceTypeDAL.Update(dL_PlaceType);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceTypeBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_PlaceTypeDAL dL_PlaceTypeDAL = new DL_PlaceTypeDAL();
                return dL_PlaceTypeDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceTypeBAL: Delete"));
            }
        }
    }
}