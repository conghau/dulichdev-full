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
    public class DL_ImageCityBAL
    {
        public DL_ImageCity GetByID(long ID)
        {
            try
            {
                DL_ImageCityDAL dL_ImageCityDAL = new DL_ImageCityDAL();
                return dL_ImageCityDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImageCityBAL: GetByID"));
            }
        }
        public List<DL_ImageCity> GetList()
        {
            try
            {
                DL_ImageCityDAL dL_ImageCityDAL = new DL_ImageCityDAL();
                return dL_ImageCityDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImageCityBAL: GetList"));
            }
        }
        public long Insert(DL_ImageCity dL_ImageCity)
        {
            try
            {
                DL_ImageCityDAL dL_ImageCityDAL = new DL_ImageCityDAL();
                return dL_ImageCityDAL.Insert(dL_ImageCity);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImageCityBAL: Insert"));
            }
        }
        public long Update(DL_ImageCity dL_ImageCity)
        {
            try
            {
                DL_ImageCityDAL dL_ImageCityDAL = new DL_ImageCityDAL();
                return dL_ImageCityDAL.Update(dL_ImageCity);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImageCityBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                DL_ImageCityDAL dL_ImageCityDAL = new DL_ImageCityDAL();
                return dL_ImageCityDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImageCityBAL: Delete"));
            }
        }
    }
}