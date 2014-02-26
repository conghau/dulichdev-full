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
    public class DL_SPAMREPORTDAL
    {
        private DL_SPAMREPORT ConvertOneRow(DataRow row)
        {
            try
            {
                DL_SPAMREPORT result = new DL_SPAMREPORT();
                result.ID = Utility.Utility.ObjectToLong(row[DL_SPAMREPORTColumns.ID.ToString()].ToString());
                result.DL_PlaceID = Utility.Utility.ObjectToLong(row[DL_SPAMREPORTColumns.DL_PlaceID.ToString()].ToString());
                result.UserID = Utility.Utility.ObjectToLong(row[DL_SPAMREPORTColumns.UserID.ToString()].ToString());
                result.CreateDate = Utility.Utility.ObjectToDateTime(row[DL_SPAMREPORTColumns.CreateDate.ToString()].ToString());
                result.UpdateDate = Utility.Utility.ObjectToDateTime(row[DL_SPAMREPORTColumns.UpdateDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_SPAMREPORTColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: ConvertOneRow"));
            }
        }
        private DL_SPAMREPORT ConvertOneRowWithGroup(DataRow row)
        {
            try
            {
                DL_SPAMREPORT result = new DL_SPAMREPORT();
                result.DL_PlaceID = Utility.Utility.ObjectToLong(row[DL_SPAMREPORTColumns.DL_PlaceID.ToString()].ToString());
                result.NumberReport = Utility.Utility.ObjectToInt(row[DL_SPAMREPORTColumns.NumberReport.ToString()].ToString());
                result.PlaceName = Utility.Utility.ObjectToString(row[DL_SPAMREPORTColumns.PlaceName.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: ConvertOneRow"));
            }
        }
        private List<DL_SPAMREPORT> GetDataObject(DataTable dt)
        {
            List<DL_SPAMREPORT> results = new List<DL_SPAMREPORT>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        private List<DL_SPAMREPORT> GetDataObjectWithGroup(DataTable dt)
        {
            List<DL_SPAMREPORT> results = new List<DL_SPAMREPORT>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRowWithGroup(item));
            }
            return results;
        }
        public DL_SPAMREPORT GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_SPAMREPORT> results = GetDataObject(dt);
                DL_SPAMREPORT dL_SPAMREPORT = new DL_SPAMREPORT();
                if (results.Count > 0)
                {
                    dL_SPAMREPORT = results[0];
                }
                return dL_SPAMREPORT;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_SPAMREPORT> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Get_ListGroupByPlace.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<DL_SPAMREPORT> GetListWithGroupByPlace(int page, int pageSize, string orderBy, string orderDirection, out long totalRecords)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Get_ListPlaceID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@OrderBy", SqlDbType.NVarChar).Value = orderBy ?? string.Empty;
                cmd.Parameters.Add("@OrderDirection", SqlDbType.NVarChar).Value = orderDirection ?? string.Empty;
                cmd.Parameters.Add("@Page", SqlDbType.BigInt).Value = page;
                cmd.Parameters.Add("@PageSize", SqlDbType.BigInt).Value = pageSize;
                SqlParameter totalRecord = cmd.Parameters.Add("@TotalRecords", SqlDbType.BigInt);
                totalRecord.Direction = ParameterDirection.Output;

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObjectWithGroup(dt);
                totalRecords = Utility.Utility.ObjectToLong(totalRecord.Value);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: GetListWithGroupByPlace"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_SPAMREPORT dL_SPAMREPORT)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_SPAMREPORT.DL_PlaceID;
                cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = dL_SPAMREPORT.UserID;
                cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = dL_SPAMREPORT.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_SPAMREPORT dL_SPAMREPORT, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_SPAMREPORT.DL_PlaceID;
                cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = dL_SPAMREPORT.UserID;
                cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = dL_SPAMREPORT.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: Insert"));
            }
        }
        public long Update(DL_SPAMREPORT dL_SPAMREPORT)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_SPAMREPORT.ID;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_SPAMREPORT.DL_PlaceID;
                cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = dL_SPAMREPORT.UserID;
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = dL_SPAMREPORT.CreateDate;
                cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = dL_SPAMREPORT.UpdateDate;
                cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = dL_SPAMREPORT.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_SPAMREPORT dL_SPAMREPORT, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_SPAMREPORT.ID;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_SPAMREPORT.DL_PlaceID;
                cmd.Parameters.Add("@UserID", SqlDbType.BigInt).Value = dL_SPAMREPORT.UserID;
                cmd.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = dL_SPAMREPORT.CreateDate;
                cmd.Parameters.Add("@UpdateDate", SqlDbType.DateTime).Value = dL_SPAMREPORT.UpdateDate;
                cmd.Parameters.Add("@Status", SqlDbType.TinyInt).Value = dL_SPAMREPORT.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: Update"));
            }
        }
        public long Delete(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: Delete"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Delete(long ID, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_Delete.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: Delete"));
            }
        }

        public long DeleteByPlaceId(long placeID, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_SPAMREPORTProcedure.p_DL_SPAMREPORT_DeleteByPlaceId.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PlaceID", SqlDbType.BigInt).Value = placeID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: Delete"));
            }
        }

        public bool ProcessingReportSpam(long[] listReportIdSkip, long[] listReportIdAccept)
        {
            SqlConnection cnn = null;
            System.Data.SqlClient.SqlTransaction tran = null;
            bool result = false;
            try
            {
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();
                if (null != listReportIdAccept && 0 < listReportIdAccept.Count())
                {
                    for (int index = 0; index < listReportIdAccept.Count(); index++)
                    {
                        DL_PlaceDAL dlPlaceDal = new DL_PlaceDAL();
                        dlPlaceDal.Delete(listReportIdAccept[index], cnn, tran);
                        DeleteByPlaceId(listReportIdAccept[index], cnn, tran);
                    }
                }
                if (null != listReportIdSkip && 0 < listReportIdSkip.Count())
                {
                    for (int index = 0; index < listReportIdSkip.Count(); index++)
                    {
                        DeleteByPlaceId(listReportIdSkip[index], cnn, tran);
                    }
                }
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_SPAMREPORTDAL: ProcessingReportSpam"));
            }
            finally
            {
                cnn.Close();
            }
        }

    }
}