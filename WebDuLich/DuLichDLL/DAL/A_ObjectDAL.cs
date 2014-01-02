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
    public class A_ObjectDAL
    {
        private A_Object ConvertOneRow(DataRow row)
        {
            try
            {
                A_Object result = new A_Object();
                result.ID = Utility.Utility.ObjectToLong(row[A_ObjectColumns.ID.ToString()].ToString());
                result.ParentID = Utility.Utility.ObjectToLong(row[A_ObjectColumns.ParentID.ToString()].ToString());
                result.ObjectName = Utility.Utility.ObjectToString(row[A_ObjectColumns.ObjectName.ToString()].ToString());
                result.Order = Utility.Utility.ObjectToInt(row[A_ObjectColumns.Order.ToString()].ToString());
                result.ObjectType = Utility.Utility.ObjectToString(row[A_ObjectColumns.ObjectType.ToString()].ToString());
                result.Url = Utility.Utility.ObjectToString(row[A_ObjectColumns.Url.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_ObjectColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_ObjectColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_ObjectColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_ObjectColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_ObjectColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: ConvertOneRow"));
            }
        }
        private List<A_Object> GetDataObject(DataTable dt)
        {
            List<A_Object> results = new List<A_Object>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public A_Object GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<A_Object> results = GetDataObject(dt);
                A_Object a_Object = new A_Object();
                if (results.Count > 0)
                {
                    a_Object = results[0];
                }
                return a_Object;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<A_Object> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<A_Object> GetListParent()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Get_ListParent.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: GetListParent"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<A_Object> GetListByParentId(long parentId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Get_ByParentID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ParentID", SqlDbType.BigInt).Value = parentId;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: GetListByParentId"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public long Insert(A_Object a_Object)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ParentID", SqlDbType.BigInt).Value = a_Object.ParentID;
                cmd.Parameters.Add("@ObjectName", SqlDbType.Char).Value = a_Object.ObjectName;
                cmd.Parameters.Add("@Order", SqlDbType.Int).Value = a_Object.Order;
                cmd.Parameters.Add("@ObjectType", SqlDbType.NVarChar).Value = a_Object.ObjectType;
                cmd.Parameters.Add("@Url", SqlDbType.Char).Value = a_Object.Url;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_Object.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_Object.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_Object.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_Object a_Object, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ParentID", SqlDbType.BigInt).Value = a_Object.ParentID;
                cmd.Parameters.Add("@ObjectName", SqlDbType.Char).Value = a_Object.ObjectName;
                cmd.Parameters.Add("@Order", SqlDbType.Int).Value = a_Object.Order;
                cmd.Parameters.Add("@ObjectType", SqlDbType.NVarChar).Value = a_Object.ObjectType;
                cmd.Parameters.Add("@Url", SqlDbType.Char).Value = a_Object.Url;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_Object.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_Object.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_Object.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: Insert"));
            }
        }
        public long Update(A_Object a_Object)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_Object.ID;
                cmd.Parameters.Add("@ParentID", SqlDbType.BigInt).Value = a_Object.ParentID;
                cmd.Parameters.Add("@ObjectName", SqlDbType.Char).Value = a_Object.ObjectName;
                cmd.Parameters.Add("@Order", SqlDbType.Int).Value = a_Object.Order;
                cmd.Parameters.Add("@ObjectType", SqlDbType.NVarChar).Value = a_Object.ObjectType;
                cmd.Parameters.Add("@Url", SqlDbType.Char).Value = a_Object.Url;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_Object.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_Object.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(A_Object a_Object, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_Object.ID;
                cmd.Parameters.Add("@ParentID", SqlDbType.BigInt).Value = a_Object.ParentID;
                cmd.Parameters.Add("@ObjectName", SqlDbType.Char).Value = a_Object.ObjectName;
                cmd.Parameters.Add("@Order", SqlDbType.Int).Value = a_Object.Order;
                cmd.Parameters.Add("@ObjectType", SqlDbType.NVarChar).Value = a_Object.ObjectType;
                cmd.Parameters.Add("@Url", SqlDbType.Char).Value = a_Object.Url;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_Object.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_Object.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(A_ObjectProcedure.p_A_Object_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_ObjectDAL: Delete"));
            }
        }
    }
}