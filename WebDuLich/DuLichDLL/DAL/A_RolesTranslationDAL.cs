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
    public class A_RolesTranslationDAL
    {
        private A_RolesTranslation ConvertOneRow(DataRow row)
        {
            try
            {
                A_RolesTranslation result = new A_RolesTranslation();
                result.ID = Utility.Utility.ObjectToLong(row[A_RolesTranslationColumns.ID.ToString()].ToString());
                result.M_LanguageID = Utility.Utility.ObjectToLong(row[A_RolesTranslationColumns.M_LanguageID.ToString()].ToString());
                result.A_RoleID = Utility.Utility.ObjectToLong(row[A_RolesTranslationColumns.A_RoleID.ToString()].ToString());
                result.RoleName = Utility.Utility.ObjectToString(row[A_RolesTranslationColumns.RoleName.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_RolesTranslationColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_RolesTranslationColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_RolesTranslationColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_RolesTranslationColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_RolesTranslationColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: ConvertOneRow"));
            }
        }
        private List<A_RolesTranslation> GetDataObject(DataTable dt)
        {
            List<A_RolesTranslation> results = new List<A_RolesTranslation>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public A_RolesTranslation GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_RolesTranslationProcedure.p_A_RolesTranslation_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<A_RolesTranslation> results = GetDataObject(dt);
                A_RolesTranslation a_RolesTranslation = new A_RolesTranslation();
                if (results.Count > 0)
                {
                    a_RolesTranslation = results[0];
                }
                return a_RolesTranslation;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<A_RolesTranslation> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_RolesTranslationProcedure.p_A_RolesTranslation_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_RolesTranslation a_RolesTranslation)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_RolesTranslationProcedure.p_A_RolesTranslation_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@M_LanguageID", SqlDbType.BigInt).Value = a_RolesTranslation.M_LanguageID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_RolesTranslation.A_RoleID;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = a_RolesTranslation.RoleName;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_RolesTranslation.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_RolesTranslation.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_RolesTranslation.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_RolesTranslation a_RolesTranslation, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(A_RolesTranslationProcedure.p_A_RolesTranslation_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@M_LanguageID", SqlDbType.BigInt).Value = a_RolesTranslation.M_LanguageID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_RolesTranslation.A_RoleID;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = a_RolesTranslation.RoleName;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_RolesTranslation.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_RolesTranslation.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_RolesTranslation.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: Insert"));
            }
        }
        public long Update(A_RolesTranslation a_RolesTranslation)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_RolesTranslationProcedure.p_A_RolesTranslation_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_RolesTranslation.ID;
                cmd.Parameters.Add("@M_LanguageID", SqlDbType.BigInt).Value = a_RolesTranslation.M_LanguageID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_RolesTranslation.A_RoleID;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = a_RolesTranslation.RoleName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_RolesTranslation.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_RolesTranslation.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(A_RolesTranslation a_RolesTranslation, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_RolesTranslationProcedure.p_A_RolesTranslation_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_RolesTranslation.ID;
                cmd.Parameters.Add("@M_LanguageID", SqlDbType.BigInt).Value = a_RolesTranslation.M_LanguageID;
                cmd.Parameters.Add("@A_RoleID", SqlDbType.BigInt).Value = a_RolesTranslation.A_RoleID;
                cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar).Value = a_RolesTranslation.RoleName;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_RolesTranslation.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_RolesTranslation.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_RolesTranslationProcedure.p_A_RolesTranslation_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(A_RolesTranslationProcedure.p_A_RolesTranslation_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_RolesTranslationDAL: Delete"));
            }
        }
    }
}