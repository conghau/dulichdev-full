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
    public class UserProfileDAL
    {
        private DLUserProfile ConvertOneRow(DataRow row)
        {
            try
            {
                DLUserProfile result = new DLUserProfile();
                result.UserId = Utility.Utility.ObjectToInt(row[DLUserProfileColumns.UserId.ToString()].ToString());
                result.UserName = Utility.Utility.ObjectToString(row[DLUserProfileColumns.UserName.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: ConvertOneRow"));
            }
        }
        private List<DLUserProfile> GetDataObject(DataTable dt)
        {
            List<DLUserProfile> results = new List<DLUserProfile>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DLUserProfile GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DLUserProfile> results = GetDataObject(dt);
                DLUserProfile userProfile = new DLUserProfile();
                if (results.Count > 0)
                {
                    userProfile = results[0];
                }
                return userProfile;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DLUserProfile> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DLUserProfile userProfile)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userProfile.UserName;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DLUserProfile userProfile, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userProfile.UserName;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: Insert"));
            }
        }
        public long Update(DLUserProfile userProfile)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userProfile.UserId;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userProfile.UserName;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DLUserProfile userProfile, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = userProfile.UserId;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userProfile.UserName;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: Delete"));
            }
        }

        public DLUserProfile GetByUserName(string userName)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DLUserProfileProcedure.p_UserProfile_ByUserName.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DLUserProfile> results = GetDataObject(dt);
                DLUserProfile userProfile = new DLUserProfile();
                if (results.Count > 0)
                {
                    userProfile = results[0];
                }
                return userProfile;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_UserProfileDAL: GetUserIdByUserName"));
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}