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
    public class webpages_OAuthMembershipDAL
    {
        private webpages_OAuthMembership ConvertOneRow(DataRow row)
        {
            try
            {
                webpages_OAuthMembership result = new webpages_OAuthMembership();
                result.Provider = Utility.Utility.ObjectToString(row[webpages_OAuthMembershipColumns.Provider.ToString()].ToString());
                result.ProviderUserId = Utility.Utility.ObjectToString(row[webpages_OAuthMembershipColumns.ProviderUserId.ToString()].ToString());
                result.UserId = Utility.Utility.ObjectToInt(row[webpages_OAuthMembershipColumns.UserId.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: ConvertOneRow"));
            }
        }
        private List<webpages_OAuthMembership> GetDataObject(DataTable dt)
        {
            List<webpages_OAuthMembership> results = new List<webpages_OAuthMembership>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public webpages_OAuthMembership GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_OAuthMembershipProcedure.p_webpages_OAuthMembership_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<webpages_OAuthMembership> results = GetDataObject(dt);
                webpages_OAuthMembership webpages_OAuthMembership = new webpages_OAuthMembership();
                if (results.Count > 0)
                {
                    webpages_OAuthMembership = results[0];
                }
                return webpages_OAuthMembership;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<webpages_OAuthMembership> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_OAuthMembershipProcedure.p_webpages_OAuthMembership_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(webpages_OAuthMembership webpages_OAuthMembership)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_OAuthMembershipProcedure.p_webpages_OAuthMembership_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_OAuthMembership.UserId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(webpages_OAuthMembership webpages_OAuthMembership, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(webpages_OAuthMembershipProcedure.p_webpages_OAuthMembership_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_OAuthMembership.UserId;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: Insert"));
            }
        }
        public long Update(webpages_OAuthMembership webpages_OAuthMembership)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_OAuthMembershipProcedure.p_webpages_OAuthMembership_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Provider", SqlDbType.NVarChar).Value = webpages_OAuthMembership.Provider;
                cmd.Parameters.Add("@ProviderUserId", SqlDbType.NVarChar).Value = webpages_OAuthMembership.ProviderUserId;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_OAuthMembership.UserId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(webpages_OAuthMembership webpages_OAuthMembership, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(webpages_OAuthMembershipProcedure.p_webpages_OAuthMembership_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Provider", SqlDbType.NVarChar).Value = webpages_OAuthMembership.Provider;
                cmd.Parameters.Add("@ProviderUserId", SqlDbType.NVarChar).Value = webpages_OAuthMembership.ProviderUserId;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_OAuthMembership.UserId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_OAuthMembershipProcedure.p_webpages_OAuthMembership_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Provider", SqlDbType.NVarChar).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(webpages_OAuthMembershipProcedure.p_webpages_OAuthMembership_Delete.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Provider", SqlDbType.NVarChar).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_OAuthMembershipDAL: Delete"));
            }
        }
    }
}