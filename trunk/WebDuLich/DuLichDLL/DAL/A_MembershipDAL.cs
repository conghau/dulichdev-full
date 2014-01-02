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
namespace DuLichDLL.DAL
{
    public class A_MembershipDAL
    {
        private A_Membership ConvertOneRow(DataRow row)
        {
            try
            {
                A_Membership result = new A_Membership();
                result.ID = Utility.Utility.ObjectToLong(row[A_MembershipColumns.ID.ToString()].ToString());
                result.A_UserProfileID = Utility.Utility.ObjectToLong(row[A_MembershipColumns.A_UserProfileID.ToString()].ToString());
                result.Password = Utility.Utility.ObjectToString(row[A_MembershipColumns.Password.ToString()].ToString());
                result.PasswordFailuresSinceLastSuccess = Utility.Utility.ObjectToInt(row[A_MembershipColumns.PasswordFailuresSinceLastSuccess.ToString()].ToString());
                result.IsBlocked = Utility.Utility.ObjectToBool(row[A_MembershipColumns.IsBlocked.ToString()].ToString());
                result.ComfirmationToken = Utility.Utility.ObjectToString(row[A_MembershipColumns.ComfirmationToken.ToString()].ToString());
                result.IsConfirmed = Utility.Utility.ObjectToBool(row[A_MembershipColumns.IsConfirmed.ToString()].ToString());
                result.LastPasswordFailureDate = Utility.Utility.ObjectToDateTime(row[A_MembershipColumns.LastPasswordFailureDate.ToString()].ToString());
                result.PasswordChangedDate = Utility.Utility.ObjectToDateTime(row[A_MembershipColumns.PasswordChangedDate.ToString()].ToString());
                result.M_CompanyID = Utility.Utility.ObjectToLong(row[A_MembershipColumns.M_CompanyID.ToString()].ToString());
                result.M_TravellerID = Utility.Utility.ObjectToLong(row[A_MembershipColumns.M_TravellerID.ToString()].ToString());
                result.M_HotelID = Utility.Utility.ObjectToLong(row[A_MembershipColumns.M_HotelID.ToString()].ToString());
                result.M_ServiceCenterID = Utility.Utility.ObjectToLong(row[A_MembershipColumns.M_ServiceCenterID.ToString()].ToString());
                result.B_PosID = Utility.Utility.ObjectToLong(row[A_MembershipColumns.B_PosID.ToString()].ToString());
                result.LastestLogin = Utility.Utility.ObjectToDateTime(row[A_MembershipColumns.LastestLogin.ToString()].ToString());
                result.QueryStatus = Utility.Utility.ObjectToInt(row[A_MembershipColumns.QueryStatus.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_MembershipColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_MembershipColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_MembershipColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_MembershipColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_MembershipColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: ConvertOneRow"));
            }
        }
        private List<A_Membership> GetDataObject(DataTable dt)
        {
            List<A_Membership> results = new List<A_Membership>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public A_Membership GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_MembershipProcedure.p_A_Membership_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<A_Membership> results = GetDataObject(dt);
                A_Membership a_Membership = new A_Membership();
                if (results.Count > 0)
                {
                    a_Membership = results[0];
                }
                return a_Membership;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<A_Membership> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_MembershipProcedure.p_A_Membership_Get_List.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_Membership a_Membership)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_MembershipProcedure.p_A_Membership_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_Membership.A_UserProfileID;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = a_Membership.Password;
                cmd.Parameters.Add("@PasswordFailuresSinceLastSuccess", SqlDbType.Int).Value = a_Membership.PasswordFailuresSinceLastSuccess;
                cmd.Parameters.Add("@IsBlocked", SqlDbType.Bit).Value = a_Membership.IsBlocked;
                cmd.Parameters.Add("@ComfirmationToken", SqlDbType.NVarChar).Value = a_Membership.ComfirmationToken;
                cmd.Parameters.Add("@IsConfirmed", SqlDbType.Bit).Value = a_Membership.IsConfirmed;
                cmd.Parameters.Add("@LastPasswordFailureDate", SqlDbType.DateTime).Value = a_Membership.LastPasswordFailureDate;
                cmd.Parameters.Add("@PasswordChangedDate", SqlDbType.DateTime).Value = a_Membership.PasswordChangedDate;
                cmd.Parameters.Add("@M_CompanyID", SqlDbType.BigInt).Value = a_Membership.M_CompanyID;
                cmd.Parameters.Add("@M_TravellerID", SqlDbType.BigInt).Value = a_Membership.M_TravellerID;
                cmd.Parameters.Add("@M_HotelID", SqlDbType.BigInt).Value = a_Membership.M_HotelID;
                cmd.Parameters.Add("@M_ServiceCenterID", SqlDbType.BigInt).Value = a_Membership.M_ServiceCenterID;
                cmd.Parameters.Add("@B_PosID", SqlDbType.BigInt).Value = a_Membership.B_PosID;
                cmd.Parameters.Add("@LastestLogin", SqlDbType.DateTime).Value = a_Membership.LastestLogin;
                cmd.Parameters.Add("@QueryStatus", SqlDbType.Int).Value = a_Membership.QueryStatus;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_Membership.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_Membership.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_Membership.Status;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_Membership a_Membership, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(A_MembershipProcedure.p_A_Membership_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_Membership.A_UserProfileID;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = a_Membership.Password;
                cmd.Parameters.Add("@PasswordFailuresSinceLastSuccess", SqlDbType.Int).Value = a_Membership.PasswordFailuresSinceLastSuccess;
                cmd.Parameters.Add("@IsBlocked", SqlDbType.Bit).Value = a_Membership.IsBlocked;
                cmd.Parameters.Add("@ComfirmationToken", SqlDbType.NVarChar).Value = a_Membership.ComfirmationToken;
                cmd.Parameters.Add("@IsConfirmed", SqlDbType.Bit).Value = a_Membership.IsConfirmed;
                cmd.Parameters.Add("@LastPasswordFailureDate", SqlDbType.DateTime).Value = a_Membership.LastPasswordFailureDate;
                cmd.Parameters.Add("@PasswordChangedDate", SqlDbType.DateTime).Value = a_Membership.PasswordChangedDate;
                cmd.Parameters.Add("@M_CompanyID", SqlDbType.BigInt).Value = a_Membership.M_CompanyID;
                cmd.Parameters.Add("@M_TravellerID", SqlDbType.BigInt).Value = a_Membership.M_TravellerID;
                cmd.Parameters.Add("@M_HotelID", SqlDbType.BigInt).Value = a_Membership.M_HotelID;
                cmd.Parameters.Add("@M_ServiceCenterID", SqlDbType.BigInt).Value = a_Membership.M_ServiceCenterID;
                cmd.Parameters.Add("@B_PosID", SqlDbType.BigInt).Value = a_Membership.B_PosID;
                cmd.Parameters.Add("@LastestLogin", SqlDbType.DateTime).Value = a_Membership.LastestLogin;
                cmd.Parameters.Add("@QueryStatus", SqlDbType.Int).Value = a_Membership.QueryStatus;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_Membership.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_Membership.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_Membership.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: Insert"));
            }
        }
        public long Update(A_Membership a_Membership)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_MembershipProcedure.p_A_Membership_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_Membership.ID;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_Membership.A_UserProfileID;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = a_Membership.Password;
                cmd.Parameters.Add("@PasswordFailuresSinceLastSuccess", SqlDbType.Int).Value = a_Membership.PasswordFailuresSinceLastSuccess;
                cmd.Parameters.Add("@IsBlocked", SqlDbType.Bit).Value = a_Membership.IsBlocked;
                cmd.Parameters.Add("@ComfirmationToken", SqlDbType.NVarChar).Value = a_Membership.ComfirmationToken;
                cmd.Parameters.Add("@IsConfirmed", SqlDbType.Bit).Value = a_Membership.IsConfirmed;
                cmd.Parameters.Add("@LastPasswordFailureDate", SqlDbType.DateTime).Value = a_Membership.LastPasswordFailureDate;
                cmd.Parameters.Add("@PasswordChangedDate", SqlDbType.DateTime).Value = a_Membership.PasswordChangedDate;
                cmd.Parameters.Add("@M_CompanyID", SqlDbType.BigInt).Value = a_Membership.M_CompanyID;
                cmd.Parameters.Add("@M_TravellerID", SqlDbType.BigInt).Value = a_Membership.M_TravellerID;
                cmd.Parameters.Add("@M_HotelID", SqlDbType.BigInt).Value = a_Membership.M_HotelID;
                cmd.Parameters.Add("@M_ServiceCenterID", SqlDbType.BigInt).Value = a_Membership.M_ServiceCenterID;
                cmd.Parameters.Add("@B_PosID", SqlDbType.BigInt).Value = a_Membership.B_PosID;
                cmd.Parameters.Add("@LastestLogin", SqlDbType.DateTime).Value = a_Membership.LastestLogin;
                cmd.Parameters.Add("@QueryStatus", SqlDbType.Int).Value = a_Membership.QueryStatus;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_Membership.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_Membership.Status;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Utility.Utility.ObjectToLong(result.ToString());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(A_Membership a_Membership, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_MembershipProcedure.p_A_Membership_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_Membership.ID;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_Membership.A_UserProfileID;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = a_Membership.Password;
                cmd.Parameters.Add("@PasswordFailuresSinceLastSuccess", SqlDbType.Int).Value = a_Membership.PasswordFailuresSinceLastSuccess;
                cmd.Parameters.Add("@IsBlocked", SqlDbType.Bit).Value = a_Membership.IsBlocked;
                cmd.Parameters.Add("@ComfirmationToken", SqlDbType.NVarChar).Value = a_Membership.ComfirmationToken;
                cmd.Parameters.Add("@IsConfirmed", SqlDbType.Bit).Value = a_Membership.IsConfirmed;
                cmd.Parameters.Add("@LastPasswordFailureDate", SqlDbType.DateTime).Value = a_Membership.LastPasswordFailureDate;
                cmd.Parameters.Add("@PasswordChangedDate", SqlDbType.DateTime).Value = a_Membership.PasswordChangedDate;
                cmd.Parameters.Add("@M_CompanyID", SqlDbType.BigInt).Value = a_Membership.M_CompanyID;
                cmd.Parameters.Add("@M_TravellerID", SqlDbType.BigInt).Value = a_Membership.M_TravellerID;
                cmd.Parameters.Add("@M_HotelID", SqlDbType.BigInt).Value = a_Membership.M_HotelID;
                cmd.Parameters.Add("@M_ServiceCenterID", SqlDbType.BigInt).Value = a_Membership.M_ServiceCenterID;
                cmd.Parameters.Add("@B_PosID", SqlDbType.BigInt).Value = a_Membership.B_PosID;
                cmd.Parameters.Add("@LastestLogin", SqlDbType.DateTime).Value = a_Membership.LastestLogin;
                cmd.Parameters.Add("@QueryStatus", SqlDbType.Int).Value = a_Membership.QueryStatus;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_Membership.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_Membership.Status;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Utility.Utility.ObjectToLong(result.ToString());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_MembershipProcedure.p_A_Membership_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = userID;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Utility.Utility.ObjectToLong(result.ToString());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: Delete"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Delete(long ID, long userID, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_MembershipProcedure.p_A_Membership_Delete.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = userID;
                SqlParameterCollection parameterValues = cmd.Parameters;
                int i = 0;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
                        i++;
                    }
                }
                object result = cmd.ExecuteScalar();
                if (result != null)
                    id = Utility.Utility.ObjectToLong(result.ToString());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_MembershipDAL: Delete"));
            }
        }
    }
}