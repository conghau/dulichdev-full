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
    public class A_ObjectFunctionDAL
    {
        private A_ObjectFunction ConvertOneRow(DataRow row)
        {
            try
            {
                A_ObjectFunction result = new A_ObjectFunction();
                result.ID = Utility.Utility.ObjectToLong(row[A_ObjectFunctionColumns.ID.ToString()].ToString());
                result.A_ObjectID = Utility.Utility.ObjectToLong(row[A_ObjectFunctionColumns.A_ObjectID.ToString()].ToString());
                result.A_FunctionID = Utility.Utility.ObjectToLong(row[A_ObjectFunctionColumns.A_FunctionID.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_ObjectFunctionColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_ObjectFunctionColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_ObjectFunctionColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_ObjectFunctionColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_ObjectFunctionColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: ConvertOneRow"));
            }
        }
        private List<A_ObjectFunction> GetDataObject(DataTable dt)
        {
            List<A_ObjectFunction> results = new List<A_ObjectFunction>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public A_ObjectFunction GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<A_ObjectFunction> results = GetDataObject(dt);
                A_ObjectFunction a_ObjectFunction = new A_ObjectFunction();
                if (results.Count > 0)
                {
                    a_ObjectFunction = results[0];
                }
                return a_ObjectFunction;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<A_ObjectFunction> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<A_ObjectFunction> GetListByRoleId(long roleId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Get_ByRoleID.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: GetListByRoleId"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public long Insert(A_ObjectFunction a_ObjectFunction)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_ObjectID", SqlDbType.BigInt).Value = a_ObjectFunction.A_ObjectID;
                cmd.Parameters.Add("@A_FunctionID", SqlDbType.BigInt).Value = a_ObjectFunction.A_FunctionID;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_ObjectFunction.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_ObjectFunction.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_ObjectFunction.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_ObjectFunction a_ObjectFunction, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_ObjectID", SqlDbType.BigInt).Value = a_ObjectFunction.A_ObjectID;
                cmd.Parameters.Add("@A_FunctionID", SqlDbType.BigInt).Value = a_ObjectFunction.A_FunctionID;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_ObjectFunction.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_ObjectFunction.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_ObjectFunction.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: Insert"));
            }
        }
        public long Update(A_ObjectFunction a_ObjectFunction)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_ObjectFunction.ID;
                cmd.Parameters.Add("@A_ObjectID", SqlDbType.BigInt).Value = a_ObjectFunction.A_ObjectID;
                cmd.Parameters.Add("@A_FunctionID", SqlDbType.BigInt).Value = a_ObjectFunction.A_FunctionID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_ObjectFunction.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_ObjectFunction.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(A_ObjectFunction a_ObjectFunction, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_ObjectFunction.ID;
                cmd.Parameters.Add("@A_ObjectID", SqlDbType.BigInt).Value = a_ObjectFunction.A_ObjectID;
                cmd.Parameters.Add("@A_FunctionID", SqlDbType.BigInt).Value = a_ObjectFunction.A_FunctionID;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_ObjectFunction.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_ObjectFunction.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(A_ObjectFunctionProcedure.p_A_ObjectFunction_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectFunctionDAL: Delete"));
            }
        }
    }
}