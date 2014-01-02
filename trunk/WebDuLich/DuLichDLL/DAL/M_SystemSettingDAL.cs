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
    public class M_SystemSettingDAL
    {
        private M_SystemSetting ConvertOneRow(DataRow row)
        {
            try
            {
                M_SystemSetting result = new M_SystemSetting();
                result.ID = Utility.Utility.ObjectToLong(row[M_SystemSettingColumns.ID.ToString()].ToString());
                result.Attribute = Utility.Utility.ObjectToString(row[M_SystemSettingColumns.Attribute.ToString()].ToString());
                result.Value = Utility.Utility.ObjectToString(row[M_SystemSettingColumns.Value.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[M_SystemSettingColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: ConvertOneRow"));
            }
        }
        private List<M_SystemSetting> GetDataObject(DataTable dt)
        {
            List<M_SystemSetting> results = new List<M_SystemSetting>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public M_SystemSetting GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<M_SystemSetting> results = GetDataObject(dt);
                M_SystemSetting m_SystemSetting = new M_SystemSetting();
                if (results.Count > 0)
                {
                    m_SystemSetting = results[0];
                }
                return m_SystemSetting;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<M_SystemSetting> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(M_SystemSetting m_SystemSetting)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Attribute", SqlDbType.NVarChar).Value = m_SystemSetting.Attribute;
                cmd.Parameters.Add("@Value", SqlDbType.NText).Value = m_SystemSetting.Value;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = m_SystemSetting.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(M_SystemSetting m_SystemSetting, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Attribute", SqlDbType.NVarChar).Value = m_SystemSetting.Attribute;
                cmd.Parameters.Add("@Value", SqlDbType.NText).Value = m_SystemSetting.Value;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = m_SystemSetting.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: Insert"));
            }
        }
        public long Update(M_SystemSetting m_SystemSetting)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = m_SystemSetting.ID;
                cmd.Parameters.Add("@Attribute", SqlDbType.NVarChar).Value = m_SystemSetting.Attribute;
                cmd.Parameters.Add("@Value", SqlDbType.NText).Value = m_SystemSetting.Value;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = m_SystemSetting.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(M_SystemSetting m_SystemSetting, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = m_SystemSetting.ID;
                cmd.Parameters.Add("@Attribute", SqlDbType.NVarChar).Value = m_SystemSetting.Attribute;
                cmd.Parameters.Add("@Value", SqlDbType.NText).Value = m_SystemSetting.Value;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = m_SystemSetting.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: Delete"));
            }
        }

        public M_SystemSetting_Config GetSystemSetting()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(M_SystemSettingProcedure.p_M_SystemSetting_Get_List.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cnn.Close();
                return GetSystemSetting(dt);

            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_SystemSettingDAL: GetSystemSetting"));
            }
            finally
            {
                if (null != cnn)
                    cnn.Close();
            }
        }
        private M_SystemSetting_Config GetSystemSetting(DataTable result)
        {
            try
            {
                M_SystemSetting_Config SYSTEM = new M_SystemSetting_Config();
                foreach (DataRow row in result.Rows)
                {
                    string attribute = row[M_SystemSettingColumns.Attribute.ToString()].ToString();
                    if (System.Enum.IsDefined(typeof(SystemSettingAttri), attribute))
                    {
                        SystemSettingAttri tableName = (SystemSettingAttri)System.Enum.Parse(typeof(SystemSettingAttri), attribute.Trim(), true);
                        switch (tableName)
                        {

                            #region Path File information
                            case SystemSettingAttri.AVATAR_DEFAULT:
                                SYSTEM.AVATAR_DEFAULT = row[M_SystemSettingColumns.Value.ToString()].ToString();
                                break;

                            case SystemSettingAttri.PATH_AVATAR_CITY:
                                SYSTEM.PATH_AVATAR_CITY = row[M_SystemSettingColumns.Value.ToString()].ToString();
                                break;
                            case SystemSettingAttri.PATH_IMAGE_CITY:
                                SYSTEM.PATH_IMAGE_CITY = row[M_SystemSettingColumns.Value.ToString()].ToString();
                                break;
                            case SystemSettingAttri.PATH_IMAGE_PLACE:
                                SYSTEM.PATH_IMAGE_PLACE = row[M_SystemSettingColumns.Value.ToString()].ToString();
                                break;
                            #endregion
                            default:
                                break;
                        }
                    }
                }
                return SYSTEM;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_M_SystemSettingDAL: GetSystemSetting"));
            }
        }

    }
}