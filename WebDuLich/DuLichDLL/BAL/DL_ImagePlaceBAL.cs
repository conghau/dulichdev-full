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
    public class DL_ImagePlaceBAL
    {
        public DL_ImagePlace GetByID(long ID)
        {
            try
            {
                DL_ImagePlaceDAL dL_ImagePlaceDAL = new DL_ImagePlaceDAL();
                return dL_ImagePlaceDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceBAL: GetByID"));
            }
        }
        public List<DL_ImagePlace> GetByDLPlaceID(long DLPlaceID)
        {
            try
            {
                DL_ImagePlaceDAL dL_ImagePlaceDAL = new DL_ImagePlaceDAL();
                return dL_ImagePlaceDAL.GetByDLPlaceID(DLPlaceID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceBAL: GetByID"));
            }
        }
        public List<DL_ImagePlace> GetList()
        {
            try
            {
                DL_ImagePlaceDAL dL_ImagePlaceDAL = new DL_ImagePlaceDAL();
                return dL_ImagePlaceDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceBAL: GetList"));
            }
        }
        public long Insert(DL_ImagePlace dL_ImagePlace)
        {
            try
            {
                DL_ImagePlaceDAL dL_ImagePlaceDAL = new DL_ImagePlaceDAL();
                return dL_ImagePlaceDAL.Insert(dL_ImagePlace);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceBAL: Insert"));
            }
        }
        public long Update(DL_ImagePlace dL_ImagePlace)
        {
            try
            {
                DL_ImagePlaceDAL dL_ImagePlaceDAL = new DL_ImagePlaceDAL();
                return dL_ImagePlaceDAL.Update(dL_ImagePlace);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceBAL: Update"));
            }
        }
        public long Delete(long ID)
        {
            try
            {
                DL_ImagePlaceDAL dL_ImagePlaceDAL = new DL_ImagePlaceDAL();
                return dL_ImagePlaceDAL.Delete(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceBAL: Delete"));
            }
        }
    }
}