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
    public class DL_CommentPlaceDAL
    {
        private DL_CommentPlace ConvertOneRow(DataRow row)
        {
            try
            {
                DL_CommentPlace result = new DL_CommentPlace();
                result.ID = Utility.Utility.ObjectToLong(row[DL_CommentPlaceColumns.ID.ToString()].ToString());
                result.DL_PlaceID = Utility.Utility.ObjectToLong(row[DL_CommentPlaceColumns.DL_PlaceID.ToString()].ToString());
                result.UserId = Utility.Utility.ObjectToLong(row[DL_CommentPlaceColumns.UserId.ToString()].ToString());
                result.Content = Utility.Utility.ObjectToString(row[DL_CommentPlaceColumns.Content.ToString()].ToString());
                result.Rating = Utility.Utility.ObjectToInt(row[DL_CommentPlaceColumns.Rating.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_CommentPlaceColumns.CreatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_CommentPlaceColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: ConvertOneRow"));
            }
        }
        private List<DL_CommentPlace> GetDataObject(DataTable dt)
        {
            List<DL_CommentPlace> results = new List<DL_CommentPlace>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_CommentPlace GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentPlaceProcedure.p_DL_CommentPlace_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_CommentPlace> results = GetDataObject(dt);
                DL_CommentPlace dL_CommentPlace = new DL_CommentPlace();
                if (results.Count > 0)
                {
                    dL_CommentPlace = results[0];
                }
                return dL_CommentPlace;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_CommentPlace> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentPlaceProcedure.p_DL_CommentPlace_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_CommentPlace dL_CommentPlace)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentPlaceProcedure.p_DL_CommentPlace_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_CommentPlace.DL_PlaceID;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = dL_CommentPlace.UserId;
                cmd.Parameters.Add("@Content", SqlDbType.NText).Value = dL_CommentPlace.Content;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = dL_CommentPlace.Rating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CommentPlace.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_CommentPlace dL_CommentPlace, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_CommentPlaceProcedure.p_DL_CommentPlace_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_CommentPlace.DL_PlaceID;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = dL_CommentPlace.UserId;
                cmd.Parameters.Add("@Content", SqlDbType.NText).Value = dL_CommentPlace.Content;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = dL_CommentPlace.Rating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CommentPlace.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: Insert"));
            }
        }
        public long Update(DL_CommentPlace dL_CommentPlace)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentPlaceProcedure.p_DL_CommentPlace_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_CommentPlace.ID;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_CommentPlace.DL_PlaceID;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = dL_CommentPlace.UserId;
                cmd.Parameters.Add("@Content", SqlDbType.NText).Value = dL_CommentPlace.Content;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = dL_CommentPlace.Rating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CommentPlace.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_CommentPlace dL_CommentPlace, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_CommentPlaceProcedure.p_DL_CommentPlace_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_CommentPlace.ID;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_CommentPlace.DL_PlaceID;
                cmd.Parameters.Add("@UserId", SqlDbType.BigInt).Value = dL_CommentPlace.UserId;
                cmd.Parameters.Add("@Content", SqlDbType.NText).Value = dL_CommentPlace.Content;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = dL_CommentPlace.Rating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CommentPlace.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CommentPlaceProcedure.p_DL_CommentPlace_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_CommentPlaceProcedure.p_DL_CommentPlace_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CommentPlaceDAL: Delete"));
            }
        }
    }
}