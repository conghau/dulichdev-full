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
    public class A_MembershipBAL
    {
        public A_Membership GetByID(long ID)
        {
            try
            {
                A_MembershipDAL a_MembershipDAL = new A_MembershipDAL();
                return a_MembershipDAL.GetByID(ID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipBAL: GetByID"));
            }
        }
        public List<A_Membership> GetList()
        {
            try
            {
                A_MembershipDAL a_MembershipDAL = new A_MembershipDAL();
                return a_MembershipDAL.GetList();
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipBAL: GetList"));
            }
        }
        public long Insert(A_Membership a_Membership)
        {
            try
            {
                A_MembershipDAL a_MembershipDAL = new A_MembershipDAL();
                return a_MembershipDAL.Insert(a_Membership);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipBAL: Insert"));
            }
        }
        public long Update(A_Membership a_Membership)
        {
            try
            {
                A_MembershipDAL a_MembershipDAL = new A_MembershipDAL();
                return a_MembershipDAL.Update(a_Membership);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipBAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            try
            {
                A_MembershipDAL a_MembershipDAL = new A_MembershipDAL();
                return a_MembershipDAL.Delete(ID, userID);
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
                throw new BusinessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipBAL: Delete"));
            }
        }
    }
}