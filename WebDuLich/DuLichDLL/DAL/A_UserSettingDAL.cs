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
    public class A_UserSettingDAL
    {
        private A_UserSetting ConvertOneRow(DataRow row)
        {
            try
            {
                A_UserSetting result = new A_UserSetting();
                result.ID = Utility.Utility.ObjectToLong(row[A_UserSettingColumns.ID.ToString()].ToString());
                result.A_UserProfileID = Utility.Utility.ObjectToLong(row[A_UserSettingColumns.A_UserProfileID.ToString()].ToString());
                result.M_LanguageID = Utility.Utility.ObjectToLong(row[A_UserSettingColumns.M_LanguageID.ToString()].ToString());
                result.DateFormat = Utility.Utility.ObjectToString(row[A_UserSettingColumns.DateFormat.ToString()].ToString());
                result.TimeFormat = Utility.Utility.ObjectToString(row[A_UserSettingColumns.TimeFormat.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_UserSettingColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_UserSettingColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_UserSettingColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_UserSettingColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_UserSettingColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: ConvertOneRow"));
            }
        }
        private List<A_UserSetting> GetDataObject(DataTable dt)
        {
            List<A_UserSetting> results = new List<A_UserSetting>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public A_UserSetting GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserSettingProcedure.p_A_UserSetting_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<A_UserSetting> results = GetDataObject(dt);
                A_UserSetting a_UserSetting = new A_UserSetting();
                if (results.Count > 0)
                {
                    a_UserSetting = results[0];
                }
                return a_UserSetting;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<A_UserSetting> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserSettingProcedure.p_A_UserSetting_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_UserSetting a_UserSetting)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserSettingProcedure.p_A_UserSetting_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_UserSetting.A_UserProfileID;
                cmd.Parameters.Add("@M_LanguageID", SqlDbType.BigInt).Value = a_UserSetting.M_LanguageID;
                cmd.Parameters.Add("@DateFormat", SqlDbType.NVarChar).Value = a_UserSetting.DateFormat;
                cmd.Parameters.Add("@TimeFormat", SqlDbType.NVarChar).Value = a_UserSetting.TimeFormat;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_UserSetting.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserSetting.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserSetting.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_UserSetting a_UserSetting, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(A_UserSettingProcedure.p_A_UserSetting_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_UserSetting.A_UserProfileID;
                cmd.Parameters.Add("@M_LanguageID", SqlDbType.BigInt).Value = a_UserSetting.M_LanguageID;
                cmd.Parameters.Add("@DateFormat", SqlDbType.NVarChar).Value = a_UserSetting.DateFormat;
                cmd.Parameters.Add("@TimeFormat", SqlDbType.NVarChar).Value = a_UserSetting.TimeFormat;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_UserSetting.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserSetting.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserSetting.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: Insert"));
            }
        }
        public long Update(A_UserSetting a_UserSetting)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserSettingProcedure.p_A_UserSetting_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_UserSetting.ID;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_UserSetting.A_UserProfileID;
                cmd.Parameters.Add("@M_LanguageID", SqlDbType.BigInt).Value = a_UserSetting.M_LanguageID;
                cmd.Parameters.Add("@DateFormat", SqlDbType.NVarChar).Value = a_UserSetting.DateFormat;
                cmd.Parameters.Add("@TimeFormat", SqlDbType.NVarChar).Value = a_UserSetting.TimeFormat;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserSetting.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserSetting.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(A_UserSetting a_UserSetting, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_UserSettingProcedure.p_A_UserSetting_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = a_UserSetting.ID;
                cmd.Parameters.Add("@A_UserProfileID", SqlDbType.BigInt).Value = a_UserSetting.A_UserProfileID;
                cmd.Parameters.Add("@M_LanguageID", SqlDbType.BigInt).Value = a_UserSetting.M_LanguageID;
                cmd.Parameters.Add("@DateFormat", SqlDbType.NVarChar).Value = a_UserSetting.DateFormat;
                cmd.Parameters.Add("@TimeFormat", SqlDbType.NVarChar).Value = a_UserSetting.TimeFormat;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserSetting.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserSetting.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserSettingProcedure.p_A_UserSetting_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(A_UserSettingProcedure.p_A_UserSetting_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserSettingDAL: Delete"));
            }
        }
    }
}