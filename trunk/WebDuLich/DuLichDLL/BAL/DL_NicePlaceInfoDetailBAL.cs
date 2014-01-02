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
    public class DL_NicePlaceInfoDetailBAL
    {
        public DL_NicePlaceInfoDetail GetByID(long ID)
        {
            try
            {
                DL_NicePlaceInfoDetailDAL dL_NicePlaceInfoDetailDAL = new DL_NicePlaceInfoDetailDAL();
                return dL_NicePlaceInfoDetailDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailBAL: GetByID"));
            }
        }
        public List<DL_NicePlaceInfoDetail> GetList()
        {
            try
            {
                DL_NicePlaceInfoDetailDAL dL_NicePlaceInfoDetailDAL = new DL_NicePlaceInfoDetailDAL();
                return dL_NicePlaceInfoDetailDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailBAL: GetList"));
            }
        }

        public DL_NicePlaceInfoDetail GetByPlaceId(long placeId)
        {
            try
            {
                DL_NicePlaceInfoDetailDAL dL_NicePlaceInfoDetailDAL = new DL_NicePlaceInfoDetailDAL();
                return dL_NicePlaceInfoDetailDAL.GetByPlaceID(placeId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailBAL: GetByPlaceId"));
            }
        }
        public long Insert(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail)
        {
            try
            {
                DL_NicePlaceInfoDetailDAL dL_NicePlaceInfoDetailDAL = new DL_NicePlaceInfoDetailDAL();
                return dL_NicePlaceInfoDetailDAL.Insert(dL_NicePlaceInfoDetail);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailBAL: Insert"));
            }
        }
        public long Update(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail)
        {
            try
            {
                DL_NicePlaceInfoDetailDAL dL_NicePlaceInfoDetailDAL = new DL_NicePlaceInfoDetailDAL();
                return dL_NicePlaceInfoDetailDAL.Update(dL_NicePlaceInfoDetail);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_NicePlaceInfoDetailDAL dL_NicePlaceInfoDetailDAL = new DL_NicePlaceInfoDetailDAL();
                return dL_NicePlaceInfoDetailDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailBAL: Delete"));
            }
        }
    }
}