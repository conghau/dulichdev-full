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
    public class A_UserProfileDAL
    {
        private A_UserProfile ConvertOneRow(DataRow row)
        {
            try
            {
                A_UserProfile result = new A_UserProfile();
                result.Id = Utility.Utility.ObjectToLong(row[A_UserProfileColumns.Id.ToString()].ToString());
                result.UserName = Utility.Utility.ObjectToString(row[A_UserProfileColumns.UserName.ToString()].ToString());
                result.FirstName = Utility.Utility.ObjectToString(row[A_UserProfileColumns.FirstName.ToString()].ToString());
                result.LastName = Utility.Utility.ObjectToString(row[A_UserProfileColumns.LastName.ToString()].ToString());
                result.PhoneNumber = Utility.Utility.ObjectToString(row[A_UserProfileColumns.PhoneNumber.ToString()].ToString());
                result.Email = Utility.Utility.ObjectToString(row[A_UserProfileColumns.Email.ToString()].ToString());
                result.Department = Utility.Utility.ObjectToString(row[A_UserProfileColumns.Department.ToString()].ToString());
                result.Description = Utility.Utility.ObjectToString(row[A_UserProfileColumns.Description.ToString()].ToString());
                result.CompanyId = Utility.Utility.ObjectToLong(row[A_UserProfileColumns.CompanyId.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[A_UserProfileColumns.CreatedBy.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[A_UserProfileColumns.CreatedDate.ToString()].ToString());
                result.UpdatedBy = Utility.Utility.ObjectToLong(row[A_UserProfileColumns.UpdatedBy.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[A_UserProfileColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[A_UserProfileColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: ConvertOneRow"));
            }
        }
        private List<A_UserProfile> GetDataObject(DataTable dt)
        {
            List<A_UserProfile> results = new List<A_UserProfile>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public A_UserProfile GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserProfileProcedure.p_A_UserProfile_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<A_UserProfile> results = GetDataObject(dt);
                A_UserProfile a_UserProfile = new A_UserProfile();
                if (results.Count > 0)
                {
                    a_UserProfile = results[0];
                }
                return a_UserProfile;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<A_UserProfile> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserProfileProcedure.p_A_UserProfile_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_UserProfile a_UserProfile)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserProfileProcedure.p_A_UserProfile_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = a_UserProfile.UserName;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = a_UserProfile.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = a_UserProfile.LastName;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = a_UserProfile.PhoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = a_UserProfile.Email;
                cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = a_UserProfile.Department;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = a_UserProfile.Description;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = a_UserProfile.CompanyId;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_UserProfile.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserProfile.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserProfile.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(A_UserProfile a_UserProfile, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(A_UserProfileProcedure.p_A_UserProfile_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = a_UserProfile.UserName;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = a_UserProfile.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = a_UserProfile.LastName;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = a_UserProfile.PhoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = a_UserProfile.Email;
                cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = a_UserProfile.Department;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = a_UserProfile.Description;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = a_UserProfile.CompanyId;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = a_UserProfile.CreatedBy;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserProfile.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserProfile.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: Insert"));
            }
        }
        public long Update(A_UserProfile a_UserProfile)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserProfileProcedure.p_A_UserProfile_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = a_UserProfile.Id;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = a_UserProfile.UserName;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = a_UserProfile.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = a_UserProfile.LastName;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = a_UserProfile.PhoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = a_UserProfile.Email;
                cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = a_UserProfile.Department;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = a_UserProfile.Description;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = a_UserProfile.CompanyId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserProfile.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserProfile.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(A_UserProfile a_UserProfile, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(A_UserProfileProcedure.p_A_UserProfile_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = a_UserProfile.Id;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = a_UserProfile.UserName;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = a_UserProfile.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = a_UserProfile.LastName;
                cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = a_UserProfile.PhoneNumber;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = a_UserProfile.Email;
                cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = a_UserProfile.Department;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = a_UserProfile.Description;
                cmd.Parameters.Add("@CompanyId", SqlDbType.BigInt).Value = a_UserProfile.CompanyId;
                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = a_UserProfile.UpdatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = a_UserProfile.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(A_UserProfileProcedure.p_A_UserProfile_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(A_UserProfileProcedure.p_A_UserProfile_Delete.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_A_UserProfileDAL: Delete"));
            }
        }
    }
}