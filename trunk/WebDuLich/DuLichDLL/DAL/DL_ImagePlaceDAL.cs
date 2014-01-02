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
    public class DL_ImagePlaceDAL
    {
        private DL_ImagePlace ConvertOneRow(DataRow row)
        {
            try
            {
                DL_ImagePlace result = new DL_ImagePlace();
                result.ID = Utility.Utility.ObjectToLong(row[DL_ImagePlaceColumns.ID.ToString()].ToString());
                result.DL_PlaceID = Utility.Utility.ObjectToLong(row[DL_ImagePlaceColumns.DL_PlaceID.ToString()].ToString());
                result.LinkImage = Utility.Utility.ObjectToString(row[DL_ImagePlaceColumns.LinkImage.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_ImagePlaceColumns.CreatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_ImagePlaceColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: ConvertOneRow"));
            }
        }
        private List<DL_ImagePlace> GetDataObject(DataTable dt)
        {
            List<DL_ImagePlace> results = new List<DL_ImagePlace>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_ImagePlace GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_ImagePlace> results = GetDataObject(dt);
                DL_ImagePlace dL_ImagePlace = new DL_ImagePlace();
                if (results.Count > 0)
                {
                    dL_ImagePlace = results[0];
                }
                return dL_ImagePlace;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_ImagePlace> GetByDLPlaceID(long DLPlaceID)
        {
            SqlConnection cnn = null;
            try
            {
              
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Get_ByDL_PlaceID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = DLPlaceID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_ImagePlace> results = GetDataObject(dt);
                DL_ImagePlace dL_ImagePlace = new DL_ImagePlace();
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_ImagePlace> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_ImagePlace dL_ImagePlace)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_ImagePlace.DL_PlaceID;
                cmd.Parameters.Add("@LinkImage", SqlDbType.NVarChar).Value = dL_ImagePlace.LinkImage;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_ImagePlace.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }        
        public long Insert(DL_ImagePlace dL_ImagePlace, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_ImagePlace.DL_PlaceID;
                cmd.Parameters.Add("@LinkImage", SqlDbType.NVarChar).Value = dL_ImagePlace.LinkImage;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_ImagePlace.Status;
                SqlParameterCollection parameterValues = cmd.Parameters;
                foreach (SqlParameter parameter in parameterValues)
                {
                    if ((parameter.Direction != ParameterDirection.Output) && (parameter.Direction != ParameterDirection.ReturnValue))
                    {
                        if (parameter.Value == null)
                            parameter.Value = DBNull.Value;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: Insert"));
            }
        }
        public long Update(DL_ImagePlace dL_ImagePlace)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_ImagePlace.ID;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_ImagePlace.DL_PlaceID;
                cmd.Parameters.Add("@LinkImage", SqlDbType.NVarChar).Value = dL_ImagePlace.LinkImage;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_ImagePlace.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_ImagePlace dL_ImagePlace, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_ImagePlace.ID;
                cmd.Parameters.Add("@DL_PlaceID", SqlDbType.BigInt).Value = dL_ImagePlace.DL_PlaceID;
                cmd.Parameters.Add("@LinkImage", SqlDbType.NVarChar).Value = dL_ImagePlace.LinkImage;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_ImagePlace.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: Update"));
            }
        }
        public long Delete(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Delete.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_ImagePlaceProcedure.p_DL_ImagePlace_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_ImagePlaceDAL: Delete"));
            }
        }
    }
}