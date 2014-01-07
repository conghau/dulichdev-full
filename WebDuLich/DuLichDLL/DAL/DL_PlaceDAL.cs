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
    public class DL_PlaceDAL
    {
        private DL_Place ConvertOneRow(DataRow row, int type)
        {
            try
            {
                DL_Place result = new DL_Place();
                result.ID = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.ID.ToString()].ToString());
                result.DL_CityId = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.DL_CityId.ToString()].ToString());
                result.DL_PlaceTypeId = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.DL_PlaceTypeId.ToString()].ToString());
                result.Name = Utility.Utility.ObjectToString(row[DL_PlaceColumns.Name.ToString()].ToString());
                result.Address = Utility.Utility.ObjectToString(row[DL_PlaceColumns.Address.ToString()].ToString());
                result.Co_ordinate = Utility.Utility.ObjectToString(row[DL_PlaceColumns.Co_ordinate.ToString()].ToString());
                result.Avatar = Utility.Utility.ObjectToString(row[DL_PlaceColumns.Avatar.ToString()].ToString());
                result.AvgRating = Utility.Utility.ObjectToInt(row[DL_PlaceColumns.AvgRating.ToString()].ToString());
                result.TotalUserRating = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.TotalUserRating.ToString()].ToString());
                result.TotalPointRating = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.TotalPointRating.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_PlaceColumns.CreatedDate.ToString()].ToString());
                result.CreatedBy = Utility.Utility.ObjectToLong(row[DL_PlaceColumns.CreatedBy.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_PlaceColumns.Status.ToString()].ToString());
                if(type ==(int) DL_PlaceTypeConvert.HasFirstChar )
                    result.FirstChar = Utility.Utility.ObjectToString(row[DL_PlaceColumns.FirstChar.ToString()].ToString());
         
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: ConvertOneRow"));
            }
        }


        private List<DL_Place> GetDataObject(DataTable dt, int typeConvert)
        {
            List<DL_Place> results = new List<DL_Place>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item,typeConvert));
            }
            return results;
        }
        public DL_Place GetByID(long ID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_ByID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_Place> results = GetDataObject(dt,(int)DL_PlaceTypeConvert.Default);
                DL_Place dL_Place = new DL_Place();
                if (results.Count > 0)
                {
                    dL_Place = results[0];
                }
                return dL_Place;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetByID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_Place> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_List.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt, (int)DL_PlaceTypeConvert.Default);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<DL_Place> GetListWithFilter(long cityId, string placeName,string address, long placeType, int page, int pageSize, string orderBy, string orderDirection, out long totalRecords)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_List_WithFilter.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                cmd.Parameters.Add("@PlaceName", SqlDbType.NVarChar).Value = placeName;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
                cmd.Parameters.Add("@PlaceType", SqlDbType.BigInt).Value = placeType;
                cmd.Parameters.Add("@OrderBy", SqlDbType.NVarChar).Value = orderBy ?? string.Empty;
                cmd.Parameters.Add("@OrderDirection", SqlDbType.NVarChar).Value = orderDirection ?? string.Empty;
                cmd.Parameters.Add("@Page", SqlDbType.BigInt).Value = page;
                cmd.Parameters.Add("@PageSize", SqlDbType.BigInt).Value = pageSize;
                SqlParameter totalRecord = cmd.Parameters.Add("@TotalRecords", SqlDbType.BigInt);
                totalRecord.Direction = ParameterDirection.Output;

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt, (int)DL_PlaceTypeConvert.Default);
                totalRecords = Utility.Utility.ObjectToLong(totalRecord.Value);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListWithFilter"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<DL_Place> GetListByCity(long cityId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_ByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt, (int)DL_PlaceTypeConvert.Default);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListByCity"));
            }
            finally
            {
                cnn.Close();
            }
        }

        public List<DL_Place> GetListNicePlaceByCity(long cityId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_NicePlaceByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt, (int)DL_PlaceTypeConvert.HasFirstChar);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListNicePlaceByCity"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_Place> GetListRestautantsByCity(long cityId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_RestaurantByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt, (int)DL_PlaceTypeConvert.HasFirstChar);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListRestautantsByCity"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_Place> GetListHotelByCity(long cityId)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Get_HotelByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CityID", SqlDbType.BigInt).Value = cityId;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                var results = GetDataObject(dt, (int)DL_PlaceTypeConvert.HasFirstChar);
                return results;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: GetListHotelByCity"));
            }
            finally
            {
                cnn.Close();
            }
        }


        public long Insert(DL_Place dL_Place)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Co_ordinate", SqlDbType.NChar).Value = dL_Place.Co_ordinate;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Int).Value = dL_Place.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.BigInt).Value = dL_Place.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.BigInt).Value = dL_Place.TotalPointRating;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = dL_Place.CreatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_Place.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_Place dL_Place, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Co_ordinate", SqlDbType.NChar).Value = dL_Place.Co_ordinate;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Int).Value = dL_Place.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.BigInt).Value = dL_Place.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.BigInt).Value = dL_Place.TotalPointRating;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt).Value = dL_Place.CreatedBy;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_Place.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Insert"));
            }
        }
        public long Update(DL_Place dL_Place)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_Place.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Co_ordinate", SqlDbType.NChar).Value = dL_Place.Co_ordinate;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Int).Value = dL_Place.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.BigInt).Value = dL_Place.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.BigInt).Value = dL_Place.TotalPointRating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_Place.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_Place dL_Place, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_Place.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Co_ordinate", SqlDbType.NChar).Value = dL_Place.Co_ordinate;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
                cmd.Parameters.Add("@AvgRating", SqlDbType.Int).Value = dL_Place.AvgRating;
                cmd.Parameters.Add("@TotalUserRating", SqlDbType.BigInt).Value = dL_Place.TotalUserRating;
                cmd.Parameters.Add("@TotalPointRating", SqlDbType.BigInt).Value = dL_Place.TotalPointRating;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_Place.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Delete"));
            }
        }

        public bool InsertNicePlace(DL_Place dlPlace, DL_NicePlaceInfoDetail dlNicePlaceDetail, List<DL_ImagePlace> dlImagePlace)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {
                DL_NicePlaceInfoDetailDAL dlNicePlaceDetailDAL = new DL_NicePlaceInfoDetailDAL();
                DL_ImagePlaceDAL dlImageDAL = new DL_ImagePlaceDAL();
                long placeId = 0;
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();

                //insert Place
                placeId = Insert(dlPlace, cnn, tran);

                //set DLPlaceID for NicePlaceInfo
                dlNicePlaceDetail.DL_PlaceId = placeId;
                dlNicePlaceDetail.Staus = 0;
                //insert NicePlaceInfo
                dlNicePlaceDetailDAL.Insert(dlNicePlaceDetail, cnn, tran);

                //insert ImagePlace
                if (null != dlImagePlace)
                {
                    for (int index = 0; index < dlImagePlace.Count; index++)
                    {
                        dlImagePlace[index].DL_PlaceID = placeId;
                        dlImagePlace[index].Status = 0;
                        dlImageDAL.Insert(dlImagePlace[index], cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: InsertNicePlace"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }
        public long Update_Hotel(DL_Place dL_Place, SqlConnection cnn, SqlTransaction tran)
        {

            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Update_Hotel.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_Place.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Update_Hotel"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update_SomeValue(DL_Place dL_Place, SqlConnection cnn, SqlTransaction tran)
        {

            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Update_SomeValue.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_Place.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Co_ordinate", SqlDbType.NChar).Value = dL_Place.Co_ordinate;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Update_SomeValue"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update_Hotel(DL_Place dL_Place)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Update_Hotel.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = dL_Place.ID;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_Place.DL_CityId;
                cmd.Parameters.Add("@DL_PlaceTypeId", SqlDbType.BigInt).Value = dL_Place.DL_PlaceTypeId;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dL_Place.Name;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dL_Place.Address;
                cmd.Parameters.Add("@Avatar", SqlDbType.NVarChar).Value = dL_Place.Avatar;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: Update_Hotel"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public bool UpdateHotel(DL_Place dlPlace, DL_HotelPlaceInfoDetail dlHotelPlaceInfoDetail, List<DL_ImagePlace> dlImagePlace)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {
                DL_HotelPlaceInfoDetailDAL dlHotelPlaceInfoDetailDAL = new DL_HotelPlaceInfoDetailDAL();
                DL_ImagePlaceDAL dlImageDAL = new DL_ImagePlaceDAL();
                long placeId = 0;
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();

                //update Place
                placeId = Update_Hotel(dlPlace, cnn, tran);
                
                //set DLPlaceID for NicePlaceInfo
               // dlHotelPlaceInfoDetail.DL_PlaceId = dlPlace.ID;
                //dlDHotelPlaceInfoDetail.Staus = 0;
                //updapte NicePlaceInfo
                dlHotelPlaceInfoDetailDAL.Update(dlHotelPlaceInfoDetail, cnn, tran);

                //update ImagePlace
                if (null != dlImagePlace)
                {
                    for (int index = 0; index < dlImagePlace.Count; index++)
                    {
                        dlImagePlace[index].DL_PlaceID = dlPlace.ID;
                        dlImagePlace[index].Status = 0;
                        dlImageDAL.Insert(dlImagePlace[index], cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: UpdateHotel 3 parameter"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }
        public bool InsertHotel(DL_Place dlPlace, DL_HotelPlaceInfoDetail dlHotelPlaceInfoDetail, List<DL_ImagePlace> dlImagePlace)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {
                DL_HotelPlaceInfoDetailDAL dlHotelPlaceInfoDetailDAL = new DL_HotelPlaceInfoDetailDAL();
                DL_ImagePlaceDAL dlImageDAL = new DL_ImagePlaceDAL();
                long placeId = 0;
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();

                //update Place
                placeId = Insert(dlPlace, cnn, tran);

                //set DLPlaceID for NicePlaceInfo
                dlHotelPlaceInfoDetail.DL_PlaceId = placeId;
                //dlDHotelPlaceInfoDetail.Staus = 0;
                //updapte NicePlaceInfo
                dlHotelPlaceInfoDetailDAL.Insert(dlHotelPlaceInfoDetail, cnn, tran);

                //update ImagePlace
                if (null != dlImagePlace)
                {
                    for (int index = 0; index < dlImagePlace.Count; index++)
                    {
                        dlImagePlace[index].DL_PlaceID = placeId;
                        dlImagePlace[index].Status = 0;
                        dlImageDAL.Insert(dlImagePlace[index], cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: InsertHotel 3 parameter"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }

        public bool UpdateNicePlace(DL_Place dlPlace, DL_NicePlaceInfoDetail dlNicePlaceInfoDetail, List<DL_ImagePlace> dlImagePlace)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {
                DL_NicePlaceInfoDetailDAL dlNicePlaceInfoDetailDAL = new DL_NicePlaceInfoDetailDAL();
                DL_ImagePlaceDAL dlImageDAL = new DL_ImagePlaceDAL();
                long placeId = 0;
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();

                //update Place
                placeId = Update_SomeValue(dlPlace, cnn, tran);

                dlNicePlaceInfoDetail.DL_PlaceId = dlPlace.ID;
                dlNicePlaceInfoDetailDAL.Update(dlNicePlaceInfoDetail, cnn, tran);

                //update ImagePlace
                if (null != dlImagePlace)
                {
                    for (int index = 0; index < dlImagePlace.Count; index++)
                    {
                        //dlImagePlace[index].DL_PlaceID = placeId;
                        dlImagePlace[index].Status = 0;
                        dlImageDAL.Insert(dlImagePlace[index], cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: UpdateNicePlace"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }
        public bool UpdateRestaurant(DL_Place dlPlace, DL_RestaurantInfoDetail dlRestaurantInfoDetail, List<DL_ImagePlace> dlImagePlace)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {
                DL_RestaurantInfoDetailDAL dlRestaurantInfoDetailDAL = new DL_RestaurantInfoDetailDAL();
                DL_ImagePlaceDAL dlImageDAL = new DL_ImagePlaceDAL();
                long placeId = 0;
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();

                //update Place: Use the same control by Hotel
                placeId = Update_Hotel(dlPlace, cnn, tran);

                //set DLPlaceID for NicePlaceInfo
                // dlHotelPlaceInfoDetail.DL_PlaceId = dlPlace.ID;
                //dlDHotelPlaceInfoDetail.Staus = 0;
                //updapte NicePlaceInfo
                dlRestaurantInfoDetailDAL.Update(dlRestaurantInfoDetail, cnn, tran);

                //update ImagePlace
                if (null != dlImagePlace)
                {
                    for (int index = 0; index < dlImagePlace.Count; index++)
                    {
                        dlImagePlace[index].DL_PlaceID = dlPlace.ID;
                        dlImagePlace[index].Status = 0;
                        dlImageDAL.Insert(dlImagePlace[index], cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: UpdateRestaurant 3 parameter"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }
        public bool InsertRestaurant(DL_Place dlPlace, DL_RestaurantInfoDetail dlRestaurantInfoDetail, List<DL_ImagePlace> dlImagePlace)
        {
            SqlConnection cnn = null;
            SqlTransaction tran = null;
            bool result = false;
            try
            {
                DL_RestaurantInfoDetailDAL dlRestaurantInfoDetailDAL = new DL_RestaurantInfoDetailDAL();
                DL_ImagePlaceDAL dlImageDAL = new DL_ImagePlaceDAL();
                long placeId = 0;
                cnn = DataProvider.OpenConnection();
                tran = cnn.BeginTransaction();

                //Insert Place
                placeId = Insert(dlPlace, cnn, tran);

                //set DLPlaceID for NicePlaceInfo
                dlRestaurantInfoDetail.DL_PlaceId = placeId;
                //dlDHotelPlaceInfoDetail.Staus = 0;
                //updapte NicePlaceInfo
                dlRestaurantInfoDetailDAL.Insert(dlRestaurantInfoDetail, cnn, tran);

                //update ImagePlace
                if (null != dlImagePlace)
                {
                    for (int index = 0; index < dlImagePlace.Count; index++)
                    {
                        dlImagePlace[index].DL_PlaceID = placeId;
                        dlImagePlace[index].Status = 0;
                        dlImageDAL.Insert(dlImagePlace[index], cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: InsertRestaurant 3 parameter"));
            }
            finally
            {
                tran.Dispose();
                cnn.Close();
            }
        }
        public bool UpdateStatusById(long ID, int status)
        {
            SqlConnection cnn = null;
            try
            {
                bool result = false;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_PlaceProcedure.p_DL_Place_Update_Status.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = ID;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = status;
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
                cmd.ExecuteScalar();
                result = true;
                return result;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_PlaceDAL: UpdateStatusById"));
            }
            finally
            {
                cnn.Close();
            }
        }

    }
}