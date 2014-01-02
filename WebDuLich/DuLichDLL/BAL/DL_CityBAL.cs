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
    public class DL_CityBAL
    {
        public DL_City GetByID(long ID)
        {
            try
            {
                DL_CityDAL dL_CityDAL = new DL_CityDAL();
                return dL_CityDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityBAL: GetByID"));
            }
        }
        public List<DL_City> GetList()
        {
            try
            {
                DL_CityDAL dL_CityDAL = new DL_CityDAL();
                return dL_CityDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityBAL: GetList"));
            }
        }
        public long Insert(DL_City dL_City)
        {
            try
            {
                DL_CityDAL dL_CityDAL = new DL_CityDAL();
                return dL_CityDAL.Insert(dL_City);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityBAL: Insert"));
            }
        }
        public long Update(DL_City dL_City)
        {
            try
            {
                DL_CityDAL dL_CityDAL = new DL_CityDAL();
                return dL_CityDAL.Update(dL_City);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_CityDAL dL_CityDAL = new DL_CityDAL();
                return dL_CityDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityBAL: Delete"));
            }
        }

        public bool InsertRating(DL_City dlCity, DL_CommentCity dlCommentCity)
        {
            try
            {
                bool result = false;
                DL_CityDAL dL_CityDAL = new DL_CityDAL();
                return result = dL_CityDAL.InsertRating(dlCity, dlCommentCity);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityBAL: InsertRating"));
            }
        }
        public bool UpdateCity(DL_City dlCity, DL_CityInfoDetail dlCityInfo)
        {
            try
            {
                bool result = false;
                DL_CityDAL dL_CityDAL = new DL_CityDAL();
                return result = dL_CityDAL.UpdateCity(dlCity, dlCityInfo);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityBAL: UpdateCity"));
            }
        }
        public List<DL_City> GetListWithFilter(string countryCode, string cityName, int page, int pageSize, string orderBy, string orderDirection, out long totalRecords)
        {
            try
            {
                DL_CityDAL dL_CityDAL = new DL_CityDAL();
                var result = dL_CityDAL.GetListWithFilter(countryCode, cityName, page, pageSize, orderBy, orderDirection, out totalRecords);
                return result;

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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityBAL: GetListWithFilter"));
            }
        }
    }
}