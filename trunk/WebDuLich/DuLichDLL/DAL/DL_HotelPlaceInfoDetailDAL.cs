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
    public class DL_HotelPlaceInfoDetailDAL
    {
        private DL_HotelPlaceInfoDetail ConvertOneRow(DataRow row)
        {
            try
            {
                DL_HotelPlaceInfoDetail result = new DL_HotelPlaceInfoDetail();
                result.ID = Utility.Utility.ObjectToLong(row[DL_HotelPlaceInfoDetailColumns.ID.ToString()].ToString());
                result.DL_PlaceId = Utility.Utility.ObjectToLong(row[DL_HotelPlaceInfoDetailColumns.DL_PlaceId.ToString()].ToString());
                result.Info = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.Info.ToString()].ToString());
                result.Service = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.Service.ToString()].ToString());
                result.RoomType = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.RoomType.ToString()].ToString());
                result.OpenCloseTime = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.OpenCloseTime.ToString()].ToString());
                result.Price = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.Price.ToString()].ToString());
                result.PayType = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.PayType.ToString()].ToString());
                result.Note = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.Note.ToString()].ToString());
                result.MobiPhone = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.MobiPhone.ToString()].ToString());
                result.HomePhone = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.HomePhone.ToString()].ToString());
                result.Fax = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.Fax.ToString()].ToString());
                result.Email = Utility.Utility.ObjectToString(row[DL_HotelPlaceInfoDetailColumns.Email.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_HotelPlaceInfoDetailColumns.CreatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_HotelPlaceInfoDetailColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: ConvertOneRow"));
            }
        }
        private List<DL_HotelPlaceInfoDetail> GetDataObject(DataTable dt)
        {
            List<DL_HotelPlaceInfoDetail> results = new List<DL_HotelPlaceInfoDetail>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_HotelPlaceInfoDetail GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_HotelPlaceInfoDetail> results = GetDataObject(dt);
                DL_HotelPlaceInfoDetail dL_HotelPlaceInfoDetail = new DL_HotelPlaceInfoDetail();
                if (results.Count > 0)
                {
                    dL_HotelPlaceInfoDetail = results[0];
                }
                return dL_HotelPlaceInfoDetail;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public DL_HotelPlaceInfoDetail GetByDLPlaceID(long DLPlaceID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Get_By_DL_PlaceId.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = DLPlaceID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_HotelPlaceInfoDetail> results = GetDataObject(dt);
                DL_HotelPlaceInfoDetail dL_HotelPlaceInfoDetail = new DL_HotelPlaceInfoDetail();
                if (results.Count > 0)
                {
                    dL_HotelPlaceInfoDetail = results[0];
                }
                return dL_HotelPlaceInfoDetail;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: GetByDLPlaceID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_HotelPlaceInfoDetail> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_HotelPlaceInfoDetail dL_HotelPlaceInfoDetail)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_HotelPlaceInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Info;
                cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Service;
                cmd.Parameters.Add("@RoomType", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.RoomType;
                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.OpenCloseTime;
                cmd.Parameters.Add("@Price", SqlDbType.Char).Value = dL_HotelPlaceInfoDetail.Price;
                cmd.Parameters.Add("@PayType", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.PayType;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Note;
                cmd.Parameters.Add("@MobiPhone", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.MobiPhone;
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.HomePhone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Email;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_HotelPlaceInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_HotelPlaceInfoDetail dL_HotelPlaceInfoDetail, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_HotelPlaceInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Info;
                cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Service;
                cmd.Parameters.Add("@RoomType", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.RoomType;
                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.OpenCloseTime;
                cmd.Parameters.Add("@Price", SqlDbType.Char).Value = dL_HotelPlaceInfoDetail.Price;
                cmd.Parameters.Add("@PayType", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.PayType;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Note;
                cmd.Parameters.Add("@MobiPhone", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.MobiPhone;
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.HomePhone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Email;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_HotelPlaceInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: Insert"));
            }
        }
        public long Update(DL_HotelPlaceInfoDetail dL_HotelPlaceInfoDetail)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_HotelPlaceInfoDetail.ID;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_HotelPlaceInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Info;
                cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Service;
                cmd.Parameters.Add("@RoomType", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.RoomType;
                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.OpenCloseTime;
                cmd.Parameters.Add("@Price", SqlDbType.Char).Value = dL_HotelPlaceInfoDetail.Price;
                cmd.Parameters.Add("@PayType", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.PayType;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Note;
                cmd.Parameters.Add("@MobiPhone", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.MobiPhone;
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.HomePhone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Email;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_HotelPlaceInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_HotelPlaceInfoDetail dL_HotelPlaceInfoDetail, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_HotelPlaceInfoDetail.ID;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_HotelPlaceInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Info;
                cmd.Parameters.Add("@Service", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Service;
                cmd.Parameters.Add("@RoomType", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.RoomType;
                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.OpenCloseTime;
                cmd.Parameters.Add("@Price", SqlDbType.Char).Value = dL_HotelPlaceInfoDetail.Price;
                cmd.Parameters.Add("@PayType", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.PayType;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Note;
                cmd.Parameters.Add("@MobiPhone", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.MobiPhone;
                cmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.HomePhone;
                cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Fax;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = dL_HotelPlaceInfoDetail.Email;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_HotelPlaceInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_HotelPlaceInfoDetailProcedure.p_DL_HotelPlaceInfoDetail_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_HotelPlaceInfoDetailDAL: Delete"));
            }
        }
    }
}