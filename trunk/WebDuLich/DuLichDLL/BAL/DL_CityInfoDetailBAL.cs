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
    public class DL_CityInfoDetailBAL
    {
        public DL_CityInfoDetail GetByCityID(long cityID)
        {
            try
            {
                DL_CityInfoDetailDAL dL_CityInfoDetailDAL = new DL_CityInfoDetailDAL();
                return dL_CityInfoDetailDAL.GetByCityID(cityID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailBAL: GetByCityID"));
            }
        }
        public List<DL_CityInfoDetail> GetList()
        {
            try
            {
                DL_CityInfoDetailDAL dL_CityInfoDetailDAL = new DL_CityInfoDetailDAL();
                return dL_CityInfoDetailDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailBAL: GetList"));
            }
        }
        public long Insert(DL_CityInfoDetail dL_CityInfoDetail)
        {
            try
            {
                DL_CityInfoDetailDAL dL_CityInfoDetailDAL = new DL_CityInfoDetailDAL();
                return dL_CityInfoDetailDAL.Insert(dL_CityInfoDetail);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailBAL: Insert"));
            }
        }
        public long Update(DL_CityInfoDetail dL_CityInfoDetail)
        {
            try
            {
                DL_CityInfoDetailDAL dL_CityInfoDetailDAL = new DL_CityInfoDetailDAL();
                return dL_CityInfoDetailDAL.Update(dL_CityInfoDetail);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_CityInfoDetailDAL dL_CityInfoDetailDAL = new DL_CityInfoDetailDAL();
                return dL_CityInfoDetailDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailBAL: Delete"));
            }
        }
    }
}