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
    public class A_AssignedPermissionDAL
    {
        private A_AssignedPermission ConvertOneRow(DataRow row)
        {
            try
            {
                A_AssignedPermission result = new A_AssignedPermission();
                result.ID = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.ID.ToString()].ToString());
                result.A_ObjectFunctionID = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.A_ObjectFunctionID.ToString()].ToString());
                result.A_RoleID = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.A_RoleID.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_AssignedPermissionColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_AssignedPermissionColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_AssignedPermissionColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: ConvertOneRow"));
            }
        }

        private A_AssignedPermission ConvertOneRowAdv(DataRow row)
        {
            try
            {
                A_AssignedPermission result = new A_AssignedPermission();
                result.ID = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.ID.ToString()].ToString());
                result.A_ObjectFunctionID = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.A_ObjectFunctionID.ToString()].ToString());
                result.A_RoleID = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.A_RoleID.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_AssignedPermissionColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_AssignedPermissionColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_AssignedPermissionColumns.Status.ToString()].ToString());
                result.A_FunctionId = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.A_FunctionId.ToString()].ToString());
                result.A_ObjectId = Utility.Utility.ObjectToLong(row[A_AssignedPermissionColumns.A_ObjectId.ToString()].ToString());
                
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: ConvertOneRowAdv"));
            }
        }
        private List<A_AssignedPermission> GetDataObject(DataTable dt)
        {
            List<A_AssignedPermission> results = new List<A_AssignedPermission>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }

        private List<A_AssignedPermission> GetDataObjectAdv(DataTable dt)
        {
            List<A_AssignedPermission> results = new List<A_AssignedPermission>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRowAdv(item));
            }
            return results;
        }
        public A_AssignedPermission GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<A_AssignedPermission> results = GetDataObject(dt);
                A_AssignedPermission a_AssignedPermission = new A_AssignedPermission();
                if (results.Count > 0)
                {
                    a_AssignedPermission = results[0];
                }
                return a_AssignedPermission;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<A_AssignedPermission> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<A_AssignedPermission> GetList(long roleId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Get_ListByRoleId.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleId", SqlDbType.BigInt).Value = roleId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<A_AssignedPermission> GetList(string roleName)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Get_ListByRoleName.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RoleName", SqlDbType.VarChar).Value = roleName;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObjectAdv(dt);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }


        public long Insert(A_AssignedPermission a_AssignedPermission)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_ObjectFunctionID", SqlDbType.BigInt).Value = a_AssignedPermission.A_ObjectFunctionID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_AssignedPermission.A_RoleID;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_AssignedPermission.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_AssignedPermission.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_AssignedPermission.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public long Insert(A_AssignedPermission a_AssignedPermission, long functionId, long objectId)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_InsertAdv.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_AssignedPermission.A_RoleID;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_AssignedPermission.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_AssignedPermission.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_AssignedPermission.Status;
                cmd.Parameters.Add("@FunctionId", SqlDbType.BigInt).Value = functionId;
                cmd.Parameters.Add("@ObjectId", SqlDbType.BigInt).Value = objectId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public long Insert(A_AssignedPermission a_AssignedPermission, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_ObjectFunctionID", SqlDbType.BigInt).Value = a_AssignedPermission.A_ObjectFunctionID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_AssignedPermission.A_RoleID;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_AssignedPermission.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_AssignedPermission.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_AssignedPermission.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: Insert"));
            }
        }
        public long Update(A_AssignedPermission a_AssignedPermission)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_AssignedPermission.ID;
                cmd.Parameters.Add("@A_ObjectFunctionID", SqlDbType.BigInt).Value = a_AssignedPermission.A_ObjectFunctionID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_AssignedPermission.A_RoleID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_AssignedPermission.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_AssignedPermission.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(A_AssignedPermission a_AssignedPermission, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_AssignedPermission.ID;
                cmd.Parameters.Add("@A_ObjectFunctionID", SqlDbType.BigInt).Value = a_AssignedPermission.A_ObjectFunctionID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_AssignedPermission.A_RoleID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_AssignedPermission.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_AssignedPermission.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: Update"));
            }
        }
        public long Delete(long roleId, long functionId, long objectId)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_DeleteAdv.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = roleId;
                cmd.Parameters.Add("@FunctionId", SqlDbType.BigInt).Value = functionId;
                cmd.Parameters.Add("@ObjectId", SqlDbType.BigInt).Value = objectId;
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
                return id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: Delete"));
            }
        }

        public bool HasPermission(string roleName, string functionName, string objectName)
        {
            SqlConnection cnn = null;
            int result ;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_AssignedPermissionProcedure.p_A_AssignedPermission_HasPermission.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@roleName", SqlDbType.VarChar).Value = roleName;
                cmd.Parameters.Add("@functionName", SqlDbType.VarChar).Value = functionName;
                cmd.Parameters.Add("@objectName", SqlDbType.VarChar).Value = objectName;
                result = Utility.Utility.ObjectToInt(cmd.ExecuteScalar());
                if (0 == result)
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_AssignedPermissionDAL: HasPermission"));
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}