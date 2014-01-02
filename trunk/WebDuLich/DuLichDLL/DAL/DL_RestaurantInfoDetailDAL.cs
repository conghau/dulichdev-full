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
    public class DL_RestaurantInfoDetailDAL
    {
        private DL_RestaurantInfoDetail ConvertOneRow(DataRow row)
        {
            try
            {
                DL_RestaurantInfoDetail result = new DL_RestaurantInfoDetail();
                result.ID = Utility.Utility.ObjectToLong(row[DL_RestaurantInfoDetailColumns.ID.ToString()].ToString());
                result.DL_PlaceId = Utility.Utility.ObjectToLong(row[DL_RestaurantInfoDetailColumns.DL_PlaceId.ToString()].ToString());
                result.Info = Utility.Utility.ObjectToString(row[DL_RestaurantInfoDetailColumns.Info.ToString()].ToString());
                result.Menu = Utility.Utility.ObjectToString(row[DL_RestaurantInfoDetailColumns.Menu.ToString()].ToString());
                result.Note = Utility.Utility.ObjectToString(row[DL_RestaurantInfoDetailColumns.Note.ToString()].ToString());
                result.MobiPhone = Utility.Utility.ObjectToString(row[DL_RestaurantInfoDetailColumns.MobiPhone.ToString()].ToString());
                result.HomePhone = Utility.Utility.ObjectToString(row[DL_RestaurantInfoDetailColumns.HomePhone.ToString()].ToString());
                result.Fax = Utility.Utility.ObjectToString(row[DL_RestaurantInfoDetailColumns.Fax.ToString()].ToString());
                result.Email = Utility.Utility.ObjectToString(row[DL_RestaurantInfoDetailColumns.Email.ToString()].ToString());
                result.Website = Utility.Utility.ObjectToString(row[DL_RestaurantInfoDetailColumns.Website.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_RestaurantInfoDetailColumns.CreatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_RestaurantInfoDetailColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: ConvertOneRow"));
            }
        }
        private List<DL_RestaurantInfoDetail> GetDataObject(DataTable dt)
        {
            List<DL_RestaurantInfoDetail> results = new List<DL_RestaurantInfoDetail>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_RestaurantInfoDetail GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_RestaurantInfoDetail> results = GetDataObject(dt);
                DL_RestaurantInfoDetail dL_RestaurantInfoDetail = new DL_RestaurantInfoDetail();
                if (results.Count > 0)
                {
                    dL_RestaurantInfoDetail = results[0];
                }
                return dL_RestaurantInfoDetail;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_RestaurantInfoDetail> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_RestaurantInfoDetail dL_RestaurantInfoDetail)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_RestaurantInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Info;
                cmd.Parameters.Add("@Menu", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Menu;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Note;
                cmd.Parameters.Add("@MobiPhone", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.MobiPhone;
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.HomePhone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Email;
                cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Website;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_RestaurantInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_RestaurantInfoDetail dL_RestaurantInfoDetail, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_RestaurantInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Info;
                cmd.Parameters.Add("@Menu", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Menu;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Note;
                cmd.Parameters.Add("@MobiPhone", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.MobiPhone;
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.HomePhone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Email;
                cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Website;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_RestaurantInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: Insert"));
            }
        }
        public long Update(DL_RestaurantInfoDetail dL_RestaurantInfoDetail)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_RestaurantInfoDetail.ID;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_RestaurantInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Info;
                cmd.Parameters.Add("@Menu", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Menu;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Note;
                cmd.Parameters.Add("@MobiPhone", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.MobiPhone;
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.HomePhone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Email;
                cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Website;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_RestaurantInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_RestaurantInfoDetail dL_RestaurantInfoDetail, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_RestaurantInfoDetail.ID;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_RestaurantInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Info;
                cmd.Parameters.Add("@Menu", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Menu;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Note;
                cmd.Parameters.Add("@MobiPhone", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.MobiPhone;
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.HomePhone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Email;
                cmd.Parameters.Add("@Website", SqlDbType.NVarChar).Value = dL_RestaurantInfoDetail.Website;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_RestaurantInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetailDAL: Delete"));
            }
        }
        public DL_RestaurantInfoDetail GetByDLPlaceID(long DLPlaceID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_RestaurantInfoDetailProcedure.p_DL_RestaurantInfoDetail_Get_By_DL_PlaceId.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = DLPlaceID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_RestaurantInfoDetail> results = GetDataObject(dt);
                DL_RestaurantInfoDetail dL_RestaurantInfoDetail = new DL_RestaurantInfoDetail();
                if (results.Count > 0)
                {
                    dL_RestaurantInfoDetail = results[0];
                }
                return dL_RestaurantInfoDetail;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_RestaurantInfoDetail: GetByDLPlaceID"));
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}