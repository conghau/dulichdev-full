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
    public class DL_HotelPlaceInfoDetailBAL
    {
        public DL_HotelPlaceInfoDetail GetByID(long ID)
        {
            try
            {
                DL_HotelPlaceInfoDetailDAL dL_HotelPlaceInfoDetailDAL = new DL_HotelPlaceInfoDetailDAL();
                return dL_HotelPlaceInfoDetailDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailBAL: GetByID"));
            }
        }
        public DL_HotelPlaceInfoDetail GetByDLPlaceID(long DLPlaceID)
        {
            try
            {
                DL_HotelPlaceInfoDetailDAL dL_HotelPlaceInfoDetailDAL = new DL_HotelPlaceInfoDetailDAL();
                return dL_HotelPlaceInfoDetailDAL.GetByDLPlaceID(DLPlaceID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailBAL: GetByDLPlaceID"));
            }
        }
        public List<DL_HotelPlaceInfoDetail> GetList()
        {
            try
            {
                DL_HotelPlaceInfoDetailDAL dL_HotelPlaceInfoDetailDAL = new DL_HotelPlaceInfoDetailDAL();
                return dL_HotelPlaceInfoDetailDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailBAL: GetList"));
            }
        }
        public long Insert(DL_HotelPlaceInfoDetail dL_HotelPlaceInfoDetail)
        {
            try
            {
                DL_HotelPlaceInfoDetailDAL dL_HotelPlaceInfoDetailDAL = new DL_HotelPlaceInfoDetailDAL();
                return dL_HotelPlaceInfoDetailDAL.Insert(dL_HotelPlaceInfoDetail);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailBAL: Insert"));
            }
        }
        public long Update(DL_HotelPlaceInfoDetail dL_HotelPlaceInfoDetail)
        {
            try
            {
                DL_HotelPlaceInfoDetailDAL dL_HotelPlaceInfoDetailDAL = new DL_HotelPlaceInfoDetailDAL();
                return dL_HotelPlaceInfoDetailDAL.Update(dL_HotelPlaceInfoDetail);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_HotelPlaceInfoDetailDAL dL_HotelPlaceInfoDetailDAL = new DL_HotelPlaceInfoDetailDAL();
                return dL_HotelPlaceInfoDetailDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailBAL: Delete"));
            }
        }
    }

}
