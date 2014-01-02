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
    public class webpages_RolesDAL
    {
        private webpages_Roles ConvertOneRow(DataRow row)
        {
            try
            {
                webpages_Roles result = new webpages_Roles();
                result.RoleId = Utility.Utility.ObjectToInt(row[webpages_RolesColumns.RoleId.ToString()].ToString());
                result.RoleName = Utility.Utility.ObjectToString(row[webpages_RolesColumns.RoleName.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: ConvertOneRow"));
            }
        }
        private List<webpages_Roles> GetDataObject(DataTable dt)
        {
            List<webpages_Roles> results = new List<webpages_Roles>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }

        private webpages_Roles ConvertOneRowWithNumberUser(DataRow row)
        {
            try
            {
                webpages_Roles result = new webpages_Roles();
                result.RoleId = Utility.Utility.ObjectToInt(row[webpages_RolesColumns.RoleId.ToString()].ToString());
                result.RoleName = Utility.Utility.ObjectToString(row[webpages_RolesColumns.RoleName.ToString()].ToString());
                result.NumberUser = Utility.Utility.ObjectToInt(row[webpages_RolesColumns.NumberUser.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: ConvertOneRowWithNumberUser"));
            }
        }
        private List<webpages_Roles> GetDataObjectWithNumberUser(DataTable dt)
        {
            List<webpages_Roles> results = new List<webpages_Roles>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRowWithNumberUser(item));
            }
            return results;
        }
        public webpages_Roles GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleId", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<webpages_Roles> results = GetDataObject(dt);
                webpages_Roles webpages_Roles = new webpages_Roles();
                if (results.Count > 0)
                {
                    webpages_Roles = results[0];
                }
                return webpages_Roles;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<webpages_Roles> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<webpages_Roles> GetListWithCountNumberUser(int page, int pageSize, string orderBy, string orderDirection, out long totalRecords)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_CountNumberUser.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderBy", SqlDbType.NVarChar).Value = orderBy ?? string.Empty;
                cmd.Parameters.Add("@OrderDirection", SqlDbType.NVarChar).Value = orderDirection ?? string.Empty;
                cmd.Parameters.Add("@Page", SqlDbType.BigInt).Value = page;
                cmd.Parameters.Add("@PageSize", SqlDbType.BigInt).Value = pageSize;
                SqlParameter totalRecord = cmd.Parameters.Add("@TotalRecords", SqlDbType.BigInt);
                totalRecord.Direction = ParameterDirection.Output;

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObjectWithNumberUser(dt);
                totalRecords = Utility.Utility.ObjectToLong(totalRecord.Value);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: GetListWithCountNumberUser"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(webpages_Roles webpages_Roles)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = webpages_Roles.RoleName;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(webpages_Roles webpages_Roles, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = webpages_Roles.RoleName;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: Insert"));
            }
        }
        public long Update(webpages_Roles webpages_Roles)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = webpages_Roles.RoleId;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = webpages_Roles.RoleName;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(webpages_Roles webpages_Roles, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = webpages_Roles.RoleId;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = webpages_Roles.RoleName;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(webpages_RolesProcedure.p_webpages_Roles_Delete.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_RolesDAL: Delete"));
            }
        }
    }
}