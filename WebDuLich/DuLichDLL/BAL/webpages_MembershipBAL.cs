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
    public class webpages_MembershipBAL
    {
        public webpages_Membership GetByID(long ID)
        {
            try
            {
                webpages_MembershipDAL webpages_MembershipDAL = new webpages_MembershipDAL();
                return webpages_MembershipDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipBAL: GetByID"));
            }
        }
        public List<webpages_Membership> GetList()
        {
            try
            {
                webpages_MembershipDAL webpages_MembershipDAL = new webpages_MembershipDAL();
                return webpages_MembershipDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipBAL: GetList"));
            }
        }
        public long Insert(webpages_Membership webpages_Membership)
        {
            try
            {
                webpages_MembershipDAL webpages_MembershipDAL = new webpages_MembershipDAL();
                return webpages_MembershipDAL.Insert(webpages_Membership);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipBAL: Insert"));
            }
        }
        public long Update(webpages_Membership webpages_Membership)
        {
            try
            {
                webpages_MembershipDAL webpages_MembershipDAL = new webpages_MembershipDAL();
                return webpages_MembershipDAL.Update(webpages_Membership);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                webpages_MembershipDAL webpages_MembershipDAL = new webpages_MembershipDAL();
                return webpages_MembershipDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipBAL: Delete"));
            }
        }
    }
}