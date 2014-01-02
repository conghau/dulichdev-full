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
    public class webpages_OAuthMembershipBAL
    {
        public webpages_OAuthMembership GetByID(long ID)
        {
            try
            {
                webpages_OAuthMembershipDAL webpages_OAuthMembershipDAL = new webpages_OAuthMembershipDAL();
                return webpages_OAuthMembershipDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipBAL: GetByID"));
            }
        }
        public List<webpages_OAuthMembership> GetList()
        {
            try
            {
                webpages_OAuthMembershipDAL webpages_OAuthMembershipDAL = new webpages_OAuthMembershipDAL();
                return webpages_OAuthMembershipDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipBAL: GetList"));
            }
        }
        public long Insert(webpages_OAuthMembership webpages_OAuthMembership)
        {
            try
            {
                webpages_OAuthMembershipDAL webpages_OAuthMembershipDAL = new webpages_OAuthMembershipDAL();
                return webpages_OAuthMembershipDAL.Insert(webpages_OAuthMembership);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipBAL: Insert"));
            }
        }
        public long Update(webpages_OAuthMembership webpages_OAuthMembership)
        {
            try
            {
                webpages_OAuthMembershipDAL webpages_OAuthMembershipDAL = new webpages_OAuthMembershipDAL();
                return webpages_OAuthMembershipDAL.Update(webpages_OAuthMembership);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                webpages_OAuthMembershipDAL webpages_OAuthMembershipDAL = new webpages_OAuthMembershipDAL();
                return webpages_OAuthMembershipDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipBAL: Delete"));
            }
        }
    }
}