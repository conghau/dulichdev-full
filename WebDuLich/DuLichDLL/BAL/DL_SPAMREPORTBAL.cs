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
    public class DL_SPAMREPORTBAL
    {
        public DL_SPAMREPORT GetByID(long ID)
        {
            try
            {
                DL_SPAMREPORTDAL dL_SPAMREPORTDAL = new DL_SPAMREPORTDAL();
                return dL_SPAMREPORTDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTBAL: GetByID"));
            }
        }
        public List<DL_SPAMREPORT> GetList()
        {
            try
            {
                DL_SPAMREPORTDAL dL_SPAMREPORTDAL = new DL_SPAMREPORTDAL();
                return dL_SPAMREPORTDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTBAL: GetList"));
            }
        }

        public List<DL_SPAMREPORT> GetListWithGroupByPlace(int page, int pageSize, string orderBy, string orderDirection, out long totalRecords)
        {
            try
            {
                DL_SPAMREPORTDAL dL_SPAMREPORTDAL = new DL_SPAMREPORTDAL();
                return dL_SPAMREPORTDAL.GetListWithGroupByPlace(page,pageSize,orderBy,orderDirection, out totalRecords);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTBAL: GetListWithGroupByPlace"));
            }
        }
        public long Insert(DL_SPAMREPORT dL_SPAMREPORT)
        {
            try
            {
                DL_SPAMREPORTDAL dL_SPAMREPORTDAL = new DL_SPAMREPORTDAL();
                return dL_SPAMREPORTDAL.Insert(dL_SPAMREPORT);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTBAL: Insert"));
            }
        }
        public long Update(DL_SPAMREPORT dL_SPAMREPORT)
        {
            try
            {
                DL_SPAMREPORTDAL dL_SPAMREPORTDAL = new DL_SPAMREPORTDAL();
                return dL_SPAMREPORTDAL.Update(dL_SPAMREPORT);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTBAL: Update"));
            }
        }
        public long Delete(long ID)
        {
            try
            {
                DL_SPAMREPORTDAL dL_SPAMREPORTDAL = new DL_SPAMREPORTDAL();
                return dL_SPAMREPORTDAL.Delete(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTBAL: Delete"));
            }
        }

        public bool ProcessingReportSpam(long[] listReportIdSkip, long[] listReportIdAccept)
        {
            try
            {
                DL_SPAMREPORTDAL dlSpamReportDal = new DL_SPAMREPORTDAL();
                return dlSpamReportDal.ProcessingReportSpam(listReportIdAccept, listReportIdSkip);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTBAL: ProcessingReportSpam"));
            }
        }

        public List<DL_SPAMREPORT> GetListUserByPlace(long placeId)
        {
            try
            {
                DL_SPAMREPORTDAL dL_SPAMREPORTDAL = new DL_SPAMREPORTDAL();
                return dL_SPAMREPORTDAL.GetListUserByPlace(placeId);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTBAL: GetListUserByPlace"));
            }
        }
    }
}