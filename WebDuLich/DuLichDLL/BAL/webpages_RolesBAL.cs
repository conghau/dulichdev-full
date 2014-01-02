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
    public class webpages_RolesBAL
    {
        public webpages_Roles GetByID(long ID)
        {
            try
            {
                webpages_RolesDAL webpages_RolesDAL = new webpages_RolesDAL();
                return webpages_RolesDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesBAL: GetByID"));
            }
        }
        public List<webpages_Roles> GetList()
        {
            try
            {
                webpages_RolesDAL webpages_RolesDAL = new webpages_RolesDAL();
                return webpages_RolesDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesBAL: GetList"));
            }
        }
        public List<webpages_Roles> GetListWithCountNumberUser(int page, int pageSize, string orderBy, string orderDirection, out long totalRecords)
        {
            try
            {
                webpages_RolesDAL webpages_RolesDAL = new webpages_RolesDAL();
                return webpages_RolesDAL.GetListWithCountNumberUser(page, pageSize, orderBy, orderDirection, out totalRecords);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesBAL: GetListWithCountNumberUser"));
            }
        }
        public long Insert(webpages_Roles webpages_Roles)
        {
            try
            {
                webpages_RolesDAL webpages_RolesDAL = new webpages_RolesDAL();
                return webpages_RolesDAL.Insert(webpages_Roles);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesBAL: Insert"));
            }
        }
        public long Update(webpages_Roles webpages_Roles)
        {
            try
            {
                webpages_RolesDAL webpages_RolesDAL = new webpages_RolesDAL();
                return webpages_RolesDAL.Update(webpages_Roles);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                webpages_RolesDAL webpages_RolesDAL = new webpages_RolesDAL();
                return webpages_RolesDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesBAL: Delete"));
            }
        }
    }
}