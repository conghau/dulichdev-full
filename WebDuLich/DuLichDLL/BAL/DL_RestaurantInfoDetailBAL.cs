using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DuLichDLL.Model;
using System.Data.SqlClient;
using System.Data;
using DuLichDLL.ExceptionType;
using DuLichDLL.Enum;
using DuLichDLL.TOOLS;
using DuLichDLL.DAL;
namespace DuLichDLL.BAL
{
    public class DL_RestaurantInfoDetailBAL
    {
        public DL_RestaurantInfoDetail GetByID(long ID)
        {
            try
            {
                DL_RestaurantInfoDetailDAL dL_RestaurantInfoDetailDAL = new DL_RestaurantInfoDetailDAL();
                return dL_RestaurantInfoDetailDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailBAL: GetByID"));
            }
        }
        public List<DL_RestaurantInfoDetail> GetList()
        {
            try
            {
                DL_RestaurantInfoDetailDAL dL_RestaurantInfoDetailDAL = new DL_RestaurantInfoDetailDAL();
                return dL_RestaurantInfoDetailDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailBAL: GetList"));
            }
        }
        public long Insert(DL_RestaurantInfoDetail dL_RestaurantInfoDetail)
        {
            try
            {
                DL_RestaurantInfoDetailDAL dL_RestaurantInfoDetailDAL = new DL_RestaurantInfoDetailDAL();
                return dL_RestaurantInfoDetailDAL.Insert(dL_RestaurantInfoDetail);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailBAL: Insert"));
            }
        }
        public long Update(DL_RestaurantInfoDetail dL_RestaurantInfoDetail)
        {
            try
            {
                DL_RestaurantInfoDetailDAL dL_RestaurantInfoDetailDAL = new DL_RestaurantInfoDetailDAL();
                return dL_RestaurantInfoDetailDAL.Update(dL_RestaurantInfoDetail);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_RestaurantInfoDetailDAL dL_RestaurantInfoDetailDAL = new DL_RestaurantInfoDetailDAL();
                return dL_RestaurantInfoDetailDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailBAL: Delete"));
            }
        }
        public DL_RestaurantInfoDetail GetByDLPlaceID (long DLPlaceID)
        {
            try
            {
                DL_RestaurantInfoDetailDAL dL_RestaurantInfoDetailDAL = new DL_RestaurantInfoDetailDAL();
                return dL_RestaurantInfoDetailDAL.GetByDLPlaceID(DLPlaceID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailBAL: GetByDLPlaceID"));
            }
        }
    }
}