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
    public class A_UserRoleDAL
    {
        private A_UserRole ConvertOneRow(DataRow row)
        {
            try
            {
                A_UserRole result = new A_UserRole();
                result.ID = Utility.Utility.ObjectToLong(row[A_UserRoleColumns.ID.ToString()].ToString());
                result.A_UserProfileID = Utility.Utility.ObjectToLong(row[A_UserRoleColumns.A_UserProfileID.ToString()].ToString());
                result.A_RoleID = Utility.Utility.ObjectToLong(row[A_UserRoleColumns.A_RoleID.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_UserRoleColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_UserRoleColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_UserRoleColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_UserRoleColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_UserRoleColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: ConvertOneRow"));
            }
        }
        private List<A_UserRole> GetDataObject(DataTable dt)
        {
            List<A_UserRole> results = new List<A_UserRole>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public A_UserRole GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserRoleProcedure.p_A_UserRole_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<A_UserRole> results = GetDataObject(dt);
                A_UserRole a_UserRole = new A_UserRole();
                if (results.Count > 0)
                {
                    a_UserRole = results[0];
                }
                return a_UserRole;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<A_UserRole> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserRoleProcedure.p_A_UserRole_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_UserRole a_UserRole)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserRoleProcedure.p_A_UserRole_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_UserRole.A_UserProfileID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_UserRole.A_RoleID;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_UserRole.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserRole.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserRole.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_UserRole a_UserRole, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(A_UserRoleProcedure.p_A_UserRole_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_UserRole.A_UserProfileID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_UserRole.A_RoleID;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_UserRole.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserRole.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserRole.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: Insert"));
            }
        }
        public long Update(A_UserRole a_UserRole)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserRoleProcedure.p_A_UserRole_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_UserRole.ID;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_UserRole.A_UserProfileID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_UserRole.A_RoleID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserRole.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserRole.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(A_UserRole a_UserRole, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_UserRoleProcedure.p_A_UserRole_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_UserRole.ID;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_UserRole.A_UserProfileID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_UserRole.A_RoleID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserRole.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserRole.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserRoleProcedure.p_A_UserRole_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(A_UserRoleProcedure.p_A_UserRole_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserRoleDAL: Delete"));
            }
        }
    }
}