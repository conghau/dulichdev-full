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
    public class webpages_MembershipDAL
    {
        private webpages_Membership ConvertOneRow(DataRow row)
        {
            try
            {
                webpages_Membership result = new webpages_Membership();
                result.UserId = Utility.Utility.ObjectToInt(row[webpages_MembershipColumns.UserId.ToString()].ToString());
                result.CreateDate = Utility.Utility.ObjectToDateTime(row[webpages_MembershipColumns.CreateDate.ToString()].ToString());
                result.ConfirmationToken = Utility.Utility.ObjectToString(row[webpages_MembershipColumns.ConfirmationToken.ToString()].ToString());
                result.IsConfirmed = Utility.Utility.ObjectToBool(row[webpages_MembershipColumns.IsConfirmed.ToString()].ToString());
                result.LastPasswordFailureDate = Utility.Utility.ObjectToDateTime(row[webpages_MembershipColumns.LastPasswordFailureDate.ToString()].ToString());
                result.PasswordFailuresSinceLastSuccess = Utility.Utility.ObjectToInt(row[webpages_MembershipColumns.PasswordFailuresSinceLastSuccess.ToString()].ToString());
                result.Password = Utility.Utility.ObjectToString(row[webpages_MembershipColumns.Password.ToString()].ToString());
                result.PasswordChangedDate = Utility.Utility.ObjectToDateTime(row[webpages_MembershipColumns.PasswordChangedDate.ToString()].ToString());
                result.PasswordSalt = Utility.Utility.ObjectToString(row[webpages_MembershipColumns.PasswordSalt.ToString()].ToString());
                result.PasswordVerificationToken = Utility.Utility.ObjectToString(row[webpages_MembershipColumns.PasswordVerificationToken.ToString()].ToString());
                result.PasswordVerificationTokenExpirationDate = Utility.Utility.ObjectToDateTime(row[webpages_MembershipColumns.PasswordVerificationTokenExpirationDate.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: ConvertOneRow"));
            }
        }
        private List<webpages_Membership> GetDataObject(DataTable dt)
        {
            List<webpages_Membership> results = new List<webpages_Membership>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public webpages_Membership GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_MembershipProcedure.p_webpages_Membership_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<webpages_Membership> results = GetDataObject(dt);
                webpages_Membership webpages_Membership = new webpages_Membership();
                if (results.Count > 0)
                {
                    webpages_Membership = results[0];
                }
                return webpages_Membership;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<webpages_Membership> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_MembershipProcedure.p_webpages_Membership_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(webpages_Membership webpages_Membership)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_MembershipProcedure.p_webpages_Membership_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = webpages_Membership.CreateDate;
                cmd.Parameters.Add("@ConfirmationToken", SqlDbType.NVarChar).Value = webpages_Membership.ConfirmationToken;
                cmd.Parameters.Add("@IsConfirmed", SqlDbType.Bit).Value = webpages_Membership.IsConfirmed;
                cmd.Parameters.Add("@LastPasswordFailureDate", SqlDbType.DateTime).Value = webpages_Membership.LastPasswordFailureDate;
                cmd.Parameters.Add("@PasswordFailuresSinceLastSuccess", SqlDbType.Int).Value = webpages_Membership.PasswordFailuresSinceLastSuccess;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = webpages_Membership.Password;
                cmd.Parameters.Add("@PasswordChangedDate", SqlDbType.DateTime).Value = webpages_Membership.PasswordChangedDate;
                cmd.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar).Value = webpages_Membership.PasswordSalt;
                cmd.Parameters.Add("@PasswordVerificationToken", SqlDbType.NVarChar).Value = webpages_Membership.PasswordVerificationToken;
                cmd.Parameters.Add("@PasswordVerificationTokenExpirationDate", SqlDbType.DateTime).Value = webpages_Membership.PasswordVerificationTokenExpirationDate;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(webpages_Membership webpages_Membership, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(webpages_MembershipProcedure.p_webpages_Membership_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = webpages_Membership.CreateDate;
                cmd.Parameters.Add("@ConfirmationToken", SqlDbType.NVarChar).Value = webpages_Membership.ConfirmationToken;
                cmd.Parameters.Add("@IsConfirmed", SqlDbType.Bit).Value = webpages_Membership.IsConfirmed;
                cmd.Parameters.Add("@LastPasswordFailureDate", SqlDbType.DateTime).Value = webpages_Membership.LastPasswordFailureDate;
                cmd.Parameters.Add("@PasswordFailuresSinceLastSuccess", SqlDbType.Int).Value = webpages_Membership.PasswordFailuresSinceLastSuccess;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = webpages_Membership.Password;
                cmd.Parameters.Add("@PasswordChangedDate", SqlDbType.DateTime).Value = webpages_Membership.PasswordChangedDate;
                cmd.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar).Value = webpages_Membership.PasswordSalt;
                cmd.Parameters.Add("@PasswordVerificationToken", SqlDbType.NVarChar).Value = webpages_Membership.PasswordVerificationToken;
                cmd.Parameters.Add("@PasswordVerificationTokenExpirationDate", SqlDbType.DateTime).Value = webpages_Membership.PasswordVerificationTokenExpirationDate;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: Insert"));
            }
        }
        public long Update(webpages_Membership webpages_Membership)
{
SqlConnection cnn=null;
try
{
long id = 0;
cnn = DataProvider.OpenConnection();
SqlCommand cmd = new SqlCommand(webpages_MembershipProcedure.p_webpages_Membership_Update.ToString(),cnn);
cmd.CommandType = CommandType.StoredProcedure;
cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_Membership.UserId;
cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = webpages_Membership.CreateDate;
cmd.Parameters.Add("@ConfirmationToken", SqlDbType.NVarChar).Value = webpages_Membership.ConfirmationToken;
cmd.Parameters.Add("@IsConfirmed", SqlDbType.Bit).Value = webpages_Membership.IsConfirmed;
cmd.Parameters.Add("@LastPasswordFailureDate", SqlDbType.DateTime).Value = webpages_Membership.LastPasswordFailureDate;
cmd.Parameters.Add("@PasswordFailuresSinceLastSuccess", SqlDbType.Int).Value = webpages_Membership.PasswordFailuresSinceLastSuccess;
cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = webpages_Membership.Password;
cmd.Parameters.Add("@PasswordChangedDate", SqlDbType.DateTime).Value = webpages_Membership.PasswordChangedDate;
cmd.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar).Value = webpages_Membership.PasswordSalt;
cmd.Parameters.Add("@PasswordVerificationToken", SqlDbType.NVarChar).Value = webpages_Membership.PasswordVerificationToken;
cmd.Parameters.Add("@PasswordVerificationTokenExpirationDate", SqlDbType.DateTime).Value = webpages_Membership.PasswordVerificationTokenExpirationDate;
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
throw new DataAccessException(ex.Message) ;
}
catch (Exception ex)
{
throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: Update"));
}
finally
{
cnn.Close();
}
 }
        public long Update(webpages_Membership webpages_Membership, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(webpages_MembershipProcedure.p_webpages_Membership_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_Membership.UserId;
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = webpages_Membership.CreateDate;
                cmd.Parameters.Add("@ConfirmationToken", SqlDbType.NVarChar).Value = webpages_Membership.ConfirmationToken;
                cmd.Parameters.Add("@IsConfirmed", SqlDbType.Bit).Value = webpages_Membership.IsConfirmed;
                cmd.Parameters.Add("@LastPasswordFailureDate", SqlDbType.DateTime).Value = webpages_Membership.LastPasswordFailureDate;
                cmd.Parameters.Add("@PasswordFailuresSinceLastSuccess", SqlDbType.Int).Value = webpages_Membership.PasswordFailuresSinceLastSuccess;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = webpages_Membership.Password;
                cmd.Parameters.Add("@PasswordChangedDate", SqlDbType.DateTime).Value = webpages_Membership.PasswordChangedDate;
                cmd.Parameters.Add("@PasswordSalt", SqlDbType.NVarChar).Value = webpages_Membership.PasswordSalt;
                cmd.Parameters.Add("@PasswordVerificationToken", SqlDbType.NVarChar).Value = webpages_Membership.PasswordVerificationToken;
                cmd.Parameters.Add("@PasswordVerificationTokenExpirationDate", SqlDbType.DateTime).Value = webpages_Membership.PasswordVerificationTokenExpirationDate;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_MembershipProcedure.p_webpages_Membership_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(webpages_MembershipProcedure.p_webpages_Membership_Delete.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_MembershipDAL: Delete"));
            }
        }
    }
}