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
    public class DL_NicePlaceInfoDetailDAL
    {
        private DL_NicePlaceInfoDetail ConvertOneRow(DataRow row)
        {
            try
            {
                DL_NicePlaceInfoDetail result = new DL_NicePlaceInfoDetail();
                result.ID = Utility.Utility.ObjectToLong(row[DL_NicePlaceInfoDetailColumns.ID.ToString()].ToString());
                result.DL_PlaceId = Utility.Utility.ObjectToLong(row[DL_NicePlaceInfoDetailColumns.DL_PlaceId.ToString()].ToString());
                result.Info = Utility.Utility.ObjectToString(row[DL_NicePlaceInfoDetailColumns.Info.ToString()].ToString());
                result.History = Utility.Utility.ObjectToString(row[DL_NicePlaceInfoDetailColumns.History.ToString()].ToString());
                result.OpenCloseTime = Utility.Utility.ObjectToString(row[DL_NicePlaceInfoDetailColumns.OpenCloseTime.ToString()].ToString());
                result.Note = Utility.Utility.ObjectToString(row[DL_NicePlaceInfoDetailColumns.Note.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_NicePlaceInfoDetailColumns.CreatedDate.ToString()].ToString());
                result.Staus = Utility.Utility.ObjectToInt(row[DL_NicePlaceInfoDetailColumns.Staus.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: ConvertOneRow"));
            }
        }
        private List<DL_NicePlaceInfoDetail> GetDataObject(DataTable dt)
        {
            List<DL_NicePlaceInfoDetail> results = new List<DL_NicePlaceInfoDetail>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_NicePlaceInfoDetail GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_NicePlaceInfoDetail> results = GetDataObject(dt);
                DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail = new DL_NicePlaceInfoDetail();
                if (results.Count > 0)
                {
                    dL_NicePlaceInfoDetail = results[0];
                }
                return dL_NicePlaceInfoDetail;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public DL_NicePlaceInfoDetail GetByPlaceID(long placeID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Get_ByPlaceID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = placeID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_NicePlaceInfoDetail> results = GetDataObject(dt);
                DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail = new DL_NicePlaceInfoDetail();
                if (results.Count > 0)
                {
                    dL_NicePlaceInfoDetail = results[0];
                }
                return dL_NicePlaceInfoDetail;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: GetByPlaceID"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<DL_NicePlaceInfoDetail> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.Info;
                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.History;
                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.OpenCloseTime;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.Note;
                cmd.Parameters.Add("@Staus", SqlDbType.Int).Value = dL_NicePlaceInfoDetail.Staus;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.Info;
                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.History;
                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.OpenCloseTime;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.Note;
                cmd.Parameters.Add("@Staus", SqlDbType.Int).Value = dL_NicePlaceInfoDetail.Staus;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Insert"));
            }
        }
        public long Update(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.ID;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.Info;
                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.History;
                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.OpenCloseTime;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.Note;
                cmd.Parameters.Add("@Staus", SqlDbType.Int).Value = dL_NicePlaceInfoDetail.Staus;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.ID;
                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.DL_PlaceId;
                cmd.Parameters.Add("@Info", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.Info;
                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.History;
                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.OpenCloseTime;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.Note;
                cmd.Parameters.Add("@Staus", SqlDbType.Int).Value = dL_NicePlaceInfoDetail.Staus;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Delete"));
            }
        }
    }
//=======
//    public class DL_NicePlaceInfoDetailDAL
//    {
//        private DL_NicePlaceInfoDetail ConvertOneRow(DataRow row)
//        {
//            try
//            {
//                DL_NicePlaceInfoDetail result = new DL_NicePlaceInfoDetail();
//                result.ID = Utility.Utility.ObjectToLong(row[DL_NicePlaceInfoDetailColumns.ID.ToString()].ToString());
//                result.DL_PlaceId = Utility.Utility.ObjectToLong(row[DL_NicePlaceInfoDetailColumns.DL_PlaceId.ToString()].ToString());
//                result.Info = Utility.Utility.ObjectToString(row[DL_NicePlaceInfoDetailColumns.Info.ToString()].ToString());
//                result.History = Utility.Utility.ObjectToString(row[DL_NicePlaceInfoDetailColumns.History.ToString()].ToString());
//                result.OpenCloseTime = Utility.Utility.ObjectToString(row[DL_NicePlaceInfoDetailColumns.OpenCloseTime.ToString()].ToString());
//                result.Note = Utility.Utility.ObjectToString(row[DL_NicePlaceInfoDetailColumns.Note.ToString()].ToString());
//                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_NicePlaceInfoDetailColumns.CreatedDate.ToString()].ToString());
//                result.Staus = Utility.Utility.ObjectToInt(row[DL_NicePlaceInfoDetailColumns.Staus.ToString()].ToString());
//                return result;
//            }
//            catch (Exception ex)
//            {
//                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: ConvertOneRow"));
//            }
//        }
//        private List<DL_NicePlaceInfoDetail> GetDataObject(DataTable dt)
//        {
//            List<DL_NicePlaceInfoDetail> results = new List<DL_NicePlaceInfoDetail>();
//            foreach (DataRow item in dt.Rows)
//            {
//                results.Add(ConvertOneRow(item));
//            }
//            return results;
//        }
//        public DL_NicePlaceInfoDetail GetByID(long ID)
//        {
//            SqlConnection cnn = null;
//            try
//            {
//                cnn = DataProvider.OpenConnection();
//                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Get_ByID.ToString(), cnn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
//                DataTable dt = new DataTable();
//                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//                adapter.Fill(dt);
//                List<DL_NicePlaceInfoDetail> results = GetDataObject(dt);
//                DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail = new DL_NicePlaceInfoDetail();
//                if (results.Count > 0)
//                {
//                    dL_NicePlaceInfoDetail = results[0];
//                }
//                return dL_NicePlaceInfoDetail;
//            }
//            catch (DataAccessException ex)
//            {
//                throw new DataAccessException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: GetByID"));
//            }
//            finally
//            {
//                cnn.Close();
//            }
//        }
//        public List<DL_NicePlaceInfoDetail> GetList()
//        {
//            SqlConnection cnn = null;
//            try
//            {
//                cnn = DataProvider.OpenConnection();
//                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Get_List.ToString(), cnn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                DataTable dt = new DataTable();
//                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//                adapter.Fill(dt);
//                var results = GetDataObject(dt);
//                return results;
//            }
//            catch (DataAccessException ex)
//            {
//                throw new DataAccessException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: GetList"));
//            }
//            finally
//            {
//                cnn.Close();
//            }
//        }
//        public long Insert(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail)
//        {
//            long id = 0;
//            SqlConnection cnn = null;
//            try
//            {
//                cnn = DataProvider.OpenConnection();
//                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Insert.ToString(), cnn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.DL_PlaceId;
//                cmd.Parameters.Add("@Info", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.Info;
//                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.History;
//                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.OpenCloseTime;
//                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.Note;
//                cmd.Parameters.Add("@Staus", SqlDbType.Int).Value = dL_NicePlaceInfoDetail.Staus;
//                SqlParameterCollection parameterValues = cmd.Parameters;
//                int i = 0;
//                foreach (SqlParameter parameter in parameterValues)
//                {
//                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
//                    {
//                        if (parameter.Value == null)
//                            parameter.Value = DBNull.Value;
//                        i++;
//                    }
//                }
//                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
//                return id;
//            }
//            catch (DataAccessException ex)
//            {
//                throw new DataAccessException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Insert"));
//            }
//            finally
//            {
//                cnn.Close();
//            }
//        }
//        public long Insert(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail, SqlConnection cnn, SqlTransaction tran)
//        {
//            long id = 0;
//            try
//            {
//                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Insert.ToString(), cnn, tran);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.DL_PlaceId;
//                cmd.Parameters.Add("@Info", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.Info;
//                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.History;
//                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.OpenCloseTime;
//                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.Note;
//                cmd.Parameters.Add("@Staus", SqlDbType.Int).Value = dL_NicePlaceInfoDetail.Staus;
//                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
//                return id;
//            }
//            catch (DataAccessException ex)
//            {
//                throw new DataAccessException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Insert"));
//            }
//        }
//        public long Update(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail)
//        {
//            SqlConnection cnn = null;
//            try
//            {
//                long id = 0;
//                cnn = DataProvider.OpenConnection();
//                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Update.ToString(), cnn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.ID;
//                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.DL_PlaceId;
//                cmd.Parameters.Add("@Info", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.Info;
//                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.History;
//                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.OpenCloseTime;
//                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.Note;
//                cmd.Parameters.Add("@Staus", SqlDbType.Int).Value = dL_NicePlaceInfoDetail.Staus;
//                SqlParameterCollection parameterValues = cmd.Parameters;
//                int i = 0;
//                foreach (SqlParameter parameter in parameterValues)
//                {
//                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
//                    {
//                        if (parameter.Value == null)
//                            parameter.Value = DBNull.Value;
//                        i++;
//                    }
//                }
//                object result = cmd.ExecuteScalar();
//                if (result != null)
//                    id = Utility.Utility.ObjectToLong(result.ToString());
//                return id;
//            }
//            catch (DataAccessException ex)
//            {
//                throw new DataAccessException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Update"));
//            }
//            finally
//            {
//                cnn.Close();
//            }
//        }
//        public long Update(DL_NicePlaceInfoDetail dL_NicePlaceInfoDetail, SqlConnection cnn, SqlTransaction tran)
//        {
//            try
//            {
//                long id = 0;
//                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Update.ToString(), cnn, tran);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.ID;
//                cmd.Parameters.Add("@DL_PlaceId", SqlDbType.BigInt).Value = dL_NicePlaceInfoDetail.DL_PlaceId;
//                cmd.Parameters.Add("@Info", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.Info;
//                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_NicePlaceInfoDetail.History;
//                cmd.Parameters.Add("@OpenCloseTime", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.OpenCloseTime;
//                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = dL_NicePlaceInfoDetail.Note;
//                cmd.Parameters.Add("@Staus", SqlDbType.Int).Value = dL_NicePlaceInfoDetail.Staus;
//                SqlParameterCollection parameterValues = cmd.Parameters;
//                int i = 0;
//                foreach (SqlParameter parameter in parameterValues)
//                {
//                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
//                    {
//                        if (parameter.Value == null)
//                            parameter.Value = DBNull.Value;
//                        i++;
//                    }
//                }
//                object result = cmd.ExecuteScalar();
//                if (result != null)
//                    id = Utility.Utility.ObjectToLong(result.ToString());
//                return id;
//            }
//            catch (DataAccessException ex)
//            {
//                throw new DataAccessException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Update"));
//            }
//        }
//        public long Delete(long ID, long userID)
//        {
//            SqlConnection cnn = null;
//            try
//            {
//                long id = 0;
//                cnn = DataProvider.OpenConnection();
//                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Delete.ToString(), cnn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
//                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = userID;
//                SqlParameterCollection parameterValues = cmd.Parameters;
//                int i = 0;
//                foreach (SqlParameter parameter in parameterValues)
//                {
//                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
//                    {
//                        if (parameter.Value == null)
//                            parameter.Value = DBNull.Value;
//                        i++;
//                    }
//                }
//                object result = cmd.ExecuteScalar();
//                if (result != null)
//                    id = Utility.Utility.ObjectToLong(result.ToString());
//                return id;
//            }
//            catch (DataAccessException ex)
//            {
//                throw new DataAccessException(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Delete"));
//            }
//            finally
//            {
//                cnn.Close();
//            }
//        }
//        public long Delete(long ID, long userID, SqlConnection cnn, SqlTransaction tran)
//        {
//            try
//            {
//                long id = 0;
//                SqlCommand cmd = new SqlCommand(DL_NicePlaceInfoDetailProcedure.p_DL_NicePlaceInfoDetail_Delete.ToString(), cnn, tran);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
//                cmd.Parameters.Add("@UpdatedBy", SqlDbType.BigInt).Value = userID;
//                SqlParameterCollection parameterValues = cmd.Parameters;
//                int i = 0;
//                foreach (SqlParameter parameter in parameterValues)
//                {
//                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
//                    {
//                        if (parameter.Value == null)
//                            parameter.Value = DBNull.Value;
//                        i++;
//                    }
//                }
//                object result = cmd.ExecuteScalar();
//                if (result != null)
//                    id = Utility.Utility.ObjectToLong(result.ToString());
//                return id;
//            }
//            catch (DataAccessException ex)
//            {
//                throw new DataAccessException(ex.Message);
//            }
//            catch (Exception ex)
//            {      
//    throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_NicePlaceInfoDetailDAL: Delete"));
//            }
//        }
//    }
//>>>>>>> .r47
}