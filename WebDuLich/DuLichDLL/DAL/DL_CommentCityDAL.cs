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
    public class DL_CommentCityDAL
    {
        private DL_CommentCity ConvertOneRow(DataRow row)
        {
            try
            {
                DL_CommentCity result = new DL_CommentCity();
                result.ID = Utility.Utility.ObjectToLong(row[DL_CommentCityColumns.ID.ToString()].ToString());
                result.DL_CityId = Utility.Utility.ObjectToLong(row[DL_CommentCityColumns.DL_CityId.ToString()].ToString());
                result.UserId = Utility.Utility.ObjectToLong(row[DL_CommentCityColumns.UserId.ToString()].ToString());
                result.Content = Utility.Utility.ObjectToString(row[DL_CommentCityColumns.Content.ToString()].ToString());
                result.Rating = Utility.Utility.ObjectToInt(row[DL_CommentCityColumns.Rating.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_CommentCityColumns.CreatedDate.ToString()].ToString());
                result.UpdatedDate = Utility.Utility.ObjectToDateTime(row[DL_CommentCityColumns.UpdatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_CommentCityColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: ConvertOneRow"));
            }
        }
        private List<DL_CommentCity> GetDataObject(DataTable dt)
        {
            List<DL_CommentCity> results = new List<DL_CommentCity>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_CommentCity GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentCityProcedure.p_DL_CommentCity_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_CommentCity> results = GetDataObject(dt);
                DL_CommentCity dL_CommentCity = new DL_CommentCity();
                if (results.Count > 0)
                {
                    dL_CommentCity = results[0];
                }
                return dL_CommentCity;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_CommentCity> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentCityProcedure.p_DL_CommentCity_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_CommentCity dL_CommentCity)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentCityProcedure.p_DL_CommentCity_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_CommentCity.DL_CityId;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = dL_CommentCity.UserId;
                cmd.Parameters.Add("@Content", SqlDbType.NText).Value = dL_CommentCity.Content;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = dL_CommentCity.Rating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CommentCity.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_CommentCity dL_CommentCity, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_CommentCityProcedure.p_DL_CommentCity_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_CommentCity.DL_CityId;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = dL_CommentCity.UserId;
                cmd.Parameters.Add("@Content", SqlDbType.NText).Value = dL_CommentCity.Content;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = dL_CommentCity.Rating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CommentCity.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: Insert"));
            }
        }
        public long Update(DL_CommentCity dL_CommentCity)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentCityProcedure.p_DL_CommentCity_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_CommentCity.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_CommentCity.DL_CityId;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = dL_CommentCity.UserId;
                cmd.Parameters.Add("@Content", SqlDbType.NText).Value = dL_CommentCity.Content;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = dL_CommentCity.Rating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CommentCity.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_CommentCity dL_CommentCity, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_CommentCityProcedure.p_DL_CommentCity_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_CommentCity.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_CommentCity.DL_CityId;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = dL_CommentCity.UserId;
                cmd.Parameters.Add("@Content", SqlDbType.NText).Value = dL_CommentCity.Content;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = dL_CommentCity.Rating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CommentCity.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentCityProcedure.p_DL_CommentCity_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_CommentCityProcedure.p_DL_CommentCity_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentCityDAL: Delete"));
            }
        }
    }
}