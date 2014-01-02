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
    public class DL_CityDAL
    {
        private DL_City ConvertOneRow(DataRow row)
        {
            try
            {
                DL_City result = new DL_City();
                result.ID = Utility.Utility.ObjectToLong(row[DL_CityColumns.ID.ToString()].ToString());
                result.CountryCode = Utility.Utility.ObjectToString(row[DL_CityColumns.CountryCode.ToString()].ToString());
                result.CityName = Utility.Utility.ObjectToString(row[DL_CityColumns.CityName.ToString()].ToString());
                result.Avatar = Utility.Utility.ObjectToString(row[DL_CityColumns.Avatar.ToString()].ToString());
                result.Summary = Utility.Utility.ObjectToString(row[DL_CityColumns.Summary.ToString()].ToString());
                result.AvgRating = Utility.Utility.ObjectToFloat(row[DL_CityColumns.AvgRating.ToString()].ToString());
                result.TotalUserRating = Utility.Utility.ObjectToInt(row[DL_CityColumns.TotalUserRating.ToString()].ToString());
                result.TotalPointRating = Utility.Utility.ObjectToInt(row[DL_CityColumns.TotalPointRating.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_CityColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: ConvertOneRow"));
            }
        }
        private List<DL_City> GetDataObject(DataTable dt)
        {
            List<DL_City> results = new List<DL_City>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_City GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_City> results = GetDataObject(dt);
                DL_City dL_City = new DL_City();
                if (results.Count > 0)
                {
                    dL_City = results[0];
                }
                return dL_City;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_City> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_City dL_City)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CountryCode", SqlDbType.Char).Value = dL_City.CountryCode;
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = dL_City.CityName;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_City.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Float).Value = dL_City.AvgRating;
                cmd.Parameters.Add("@TotalUserRate", SqlDbType.Int).Value = dL_City.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.Int).Value = dL_City.TotalPointRating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_City.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_City dL_City, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CountryCode", SqlDbType.Char).Value = dL_City.CountryCode;
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = dL_City.CityName;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_City.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Float).Value = dL_City.AvgRating;
                cmd.Parameters.Add("@TotalUserRate", SqlDbType.Int).Value = dL_City.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.Int).Value = dL_City.TotalPointRating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_City.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: Insert"));
            }
        }
        public long Update(DL_City dL_City)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_City.ID;
                cmd.Parameters.Add("@CountryCode", SqlDbType.Char).Value = dL_City.CountryCode;
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = dL_City.CityName;
                cmd.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = dL_City.Summary;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_City.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Float).Value = dL_City.AvgRating;
                cmd.Parameters.Add("@TotalUserRate", SqlDbType.Int).Value = dL_City.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.Int).Value = dL_City.TotalPointRating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_City.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_City dL_City, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_City.ID;
                cmd.Parameters.Add("@CountryCode", SqlDbType.Char).Value = dL_City.CountryCode;
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = dL_City.CityName;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_City.Avatar;
                cmd.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = dL_City.Summary;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Float).Value = dL_City.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.Int).Value = dL_City.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.Int).Value = dL_City.TotalPointRating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_City.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: Delete"));
            }
        }



        public long UpdateContent(DL_City dL_City, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_UpdateContent.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_City.ID;
                cmd.Parameters.Add("@CountryCode", SqlDbType.Char).Value = dL_City.CountryCode;
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = dL_City.CityName;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_City.Avatar;
                cmd.Parameters.Add("@Summary", SqlDbType.NVarChar).Value = dL_City.Summary;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_City.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: UpdateContent"));
            }
        }

        public bool InsertRating(DL_City dlCity, DL_CommentCity dlCommentCity)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {
                DL_CommentCityDAL dlCmCityDAL = new DL_CommentCityDAL();
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();
                Update(dlCity, cnn, tran);
                dlCmCityDAL.Insert(dlCommentCity, cnn, tran);
                tran.Commit();
                result = true;
                return result;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: InsertRating"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }
        public bool UpdateCity(DL_City dlCity, DL_CityInfoDetail dlCityInfo)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {

                DL_CityInfoDetailDAL dlCityInfoDAL = new DL_CityInfoDetailDAL();
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();
                UpdateContent(dlCity, cnn, tran);
                dlCityInfoDAL.Update(dlCityInfo, cnn, tran);
                tran.Commit();
                result = true;
                return result;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: UpdateCity"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }
        public List<DL_City> GetListWithFilter(string countryCode, string cityName, int page, int pageSize, string orderBy, string orderDirection, out long totalRecords)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityProcedure.p_DL_City_Get_List_WithFilter.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar).Value = countryCode;
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = cityName;
                cmd.Parameters.Add("@OrderBy", SqlDbType.NVarChar).Value = orderBy ?? string.Empty;
                cmd.Parameters.Add("@OrderDirection", SqlDbType.NVarChar).Value = orderDirection ?? string.Empty;
                cmd.Parameters.Add("@Page", SqlDbType.BigInt).Value = page;
                cmd.Parameters.Add("@PageSize", SqlDbType.BigInt).Value = pageSize;
                SqlParameter totalRecord = cmd.Parameters.Add("@TotalRecords", SqlDbType.BigInt);
                totalRecord.Direction = ParameterDirection.Output;

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt);
                totalRecords = Utility.Utility.ObjectToLong(totalRecord.Value);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityDAL: GetListWithFilter"));
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}