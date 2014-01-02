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
    public class webpages_UsersInRolesDAL
    {
        private webpages_UsersInRoles ConvertOneRow(DataRow row)
        {
            try
            {
                webpages_UsersInRoles result = new webpages_UsersInRoles();
                result.UserId = Utility.Utility.ObjectToInt(row[webpages_UsersInRolesColumns.UserId.ToString()].ToString());
                result.RoleId = Utility.Utility.ObjectToInt(row[webpages_UsersInRolesColumns.RoleId.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: ConvertOneRow"));
            }
        }
        private List<webpages_UsersInRoles> GetDataObject(DataTable dt)
        {
            List<webpages_UsersInRoles> results = new List<webpages_UsersInRoles>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public webpages_UsersInRoles GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<webpages_UsersInRoles> results = GetDataObject(dt);
                webpages_UsersInRoles webpages_UsersInRoles = new webpages_UsersInRoles();
                if (results.Count > 0)
                {
                    webpages_UsersInRoles = results[0];
                }
                return webpages_UsersInRoles;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<webpages_UsersInRoles> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(webpages_UsersInRoles webpages_UsersInRoles)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_UsersInRoles.UserId;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = webpages_UsersInRoles.RoleId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(webpages_UsersInRoles webpages_UsersInRoles, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: Insert"));
            }
        }
        public long Update(webpages_UsersInRoles webpages_UsersInRoles)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_UsersInRoles.UserId;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = webpages_UsersInRoles.RoleId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(webpages_UsersInRoles webpages_UsersInRoles, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_UsersInRoles.UserId;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = webpages_UsersInRoles.RoleId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: Update"));
            }
        }
        public long Delete(long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userID;                
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: Delete"));
            }
        }

        public bool UserIsAdmin(long userID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_IsAdminByUserId.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = userID;
                //DataTable dt = new DataTable();
                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //adapter.Fill(dt);
                if (1 == Utility.Utility.ObjectToInt(cmd.ExecuteScalar()))
                    return true;
                else
                    return false;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: UserIsAdmin"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long UpdateRoleforUser(webpages_UsersInRoles webpages_UsersInRoles)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(webpages_UsersInRolesProcedure.p_webpages_UsersInRoles_UpdateRoleforUser.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = webpages_UsersInRoles.UserId;
                cmd.Parameters.Add("@RoleId", SqlDbType.Int).Value = webpages_UsersInRoles.RoleId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_webpages_UsersInRolesDAL: UpdateRoleforUser"));
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}