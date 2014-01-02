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
    public class DL_CityInfoDetailDAL
    {
        private DL_CityInfoDetail ConvertOneRow(DataRow row)
        {
            try
            {
                DL_CityInfoDetail result = new DL_CityInfoDetail();
                result.Id = Utility.Utility.ObjectToLong(row[DL_CityInfoDetailColumns.Id.ToString()].ToString());
                result.DL_CityId = Utility.Utility.ObjectToLong(row[DL_CityInfoDetailColumns.DL_CityId.ToString()].ToString());
                result.History = Utility.Utility.ObjectToString(row[DL_CityInfoDetailColumns.History.ToString()].ToString());
                result.Nature = Utility.Utility.ObjectToString(row[DL_CityInfoDetailColumns.Nature.ToString()].ToString());
                result.Social = Utility.Utility.ObjectToString(row[DL_CityInfoDetailColumns.Social.ToString()].ToString());
                result.Administrative = Utility.Utility.ObjectToString(row[DL_CityInfoDetailColumns.Administrative.ToString()].ToString());
                result.Economy = Utility.Utility.ObjectToString(row[DL_CityInfoDetailColumns.Economy.ToString()].ToString());
                result.Travel = Utility.Utility.ObjectToString(row[DL_CityInfoDetailColumns.Travel.ToString()].ToString());
                result.CreatedDate = Utility.Utility.ObjectToDateTime(row[DL_CityInfoDetailColumns.CreatedDate.ToString()].ToString());
                result.Status = Utility.Utility.ObjectToInt(row[DL_CityInfoDetailColumns.Status.ToString()].ToString());
                return result;
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: ConvertOneRow"));
            }
        }
        private List<DL_CityInfoDetail> GetDataObject(DataTable dt)
        {
            List<DL_CityInfoDetail> results = new List<DL_CityInfoDetail>();
            foreach (DataRow item in dt.Rows)
            {
                results.Add(ConvertOneRow(item));
            }
            return results;
        }
        public DL_CityInfoDetail GetByCityID(long cityID)
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityInfoDetailProcedure.p_DL_CityInfoDetail_Get_ByCityID.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = cityID;
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                List<DL_CityInfoDetail> results = GetDataObject(dt);
                DL_CityInfoDetail dL_CityInfoDetail = new DL_CityInfoDetail();
                if (results.Count > 0)
                {
                    dL_CityInfoDetail = results[0];
                }
                return dL_CityInfoDetail;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: GetByCityID"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public List<DL_CityInfoDetail> GetList()
        {
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityInfoDetailProcedure.p_DL_CityInfoDetail_Get_List.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: GetList"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_CityInfoDetail dL_CityInfoDetail)
        {
            long id = 0;
            SqlConnection cnn = null;
            try
            {
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityInfoDetailProcedure.p_DL_CityInfoDetail_Insert.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_CityInfoDetail.DL_CityId;
                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_CityInfoDetail.History;
                cmd.Parameters.Add("@Nature", SqlDbType.NText).Value = dL_CityInfoDetail.Nature;
                cmd.Parameters.Add("@Social", SqlDbType.NText).Value = dL_CityInfoDetail.Social;
                cmd.Parameters.Add("@Administrative", SqlDbType.NText).Value = dL_CityInfoDetail.Administrative;
                cmd.Parameters.Add("@Economy", SqlDbType.NText).Value = dL_CityInfoDetail.Economy;
                cmd.Parameters.Add("@Travel", SqlDbType.NText).Value = dL_CityInfoDetail.Travel;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CityInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: Insert"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Insert(DL_CityInfoDetail dL_CityInfoDetail, SqlConnection cnn, SqlTransaction tran)
        {
            long id = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(DL_CityInfoDetailProcedure.p_DL_CityInfoDetail_Insert.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_CityInfoDetail.DL_CityId;
                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_CityInfoDetail.History;
                cmd.Parameters.Add("@Nature", SqlDbType.NText).Value = dL_CityInfoDetail.Nature;
                cmd.Parameters.Add("@Social", SqlDbType.NText).Value = dL_CityInfoDetail.Social;
                cmd.Parameters.Add("@Administrative", SqlDbType.NText).Value = dL_CityInfoDetail.Administrative;
                cmd.Parameters.Add("@Economy", SqlDbType.NText).Value = dL_CityInfoDetail.Economy;
                cmd.Parameters.Add("@Travel", SqlDbType.NText).Value = dL_CityInfoDetail.Travel;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CityInfoDetail.Status;
                id = Utility.Utility.ObjectToLong(cmd.ExecuteScalar());
                return id;
            }
            catch (DataAccessException ex)
            {
                throw new DataAccessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: Insert"));
            }
        }
        public long Update(DL_CityInfoDetail dL_CityInfoDetail)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityInfoDetailProcedure.p_DL_CityInfoDetail_Update.ToString(), cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = dL_CityInfoDetail.Id;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_CityInfoDetail.DL_CityId;
                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_CityInfoDetail.History;
                cmd.Parameters.Add("@Nature", SqlDbType.NText).Value = dL_CityInfoDetail.Nature;
                cmd.Parameters.Add("@Social", SqlDbType.NText).Value = dL_CityInfoDetail.Social;
                cmd.Parameters.Add("@Administrative", SqlDbType.NText).Value = dL_CityInfoDetail.Administrative;
                cmd.Parameters.Add("@Economy", SqlDbType.NText).Value = dL_CityInfoDetail.Economy;
                cmd.Parameters.Add("@Travel", SqlDbType.NText).Value = dL_CityInfoDetail.Travel;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CityInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: Update"));
            }
            finally
            {
                cnn.Close();
            }
        }
        public long Update(DL_CityInfoDetail dL_CityInfoDetail, SqlConnection cnn, SqlTransaction tran)
        {
            try
            {
                long id = 0;
                SqlCommand cmd = new SqlCommand(DL_CityInfoDetailProcedure.p_DL_CityInfoDetail_Update.ToString(), cnn, tran);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Id", SqlDbType.BigInt).Value = dL_CityInfoDetail.Id;
                cmd.Parameters.Add("@DL_CityId", SqlDbType.BigInt).Value = dL_CityInfoDetail.DL_CityId;
                cmd.Parameters.Add("@History", SqlDbType.NText).Value = dL_CityInfoDetail.History;
                cmd.Parameters.Add("@Nature", SqlDbType.NText).Value = dL_CityInfoDetail.Nature;
                cmd.Parameters.Add("@Social", SqlDbType.NText).Value = dL_CityInfoDetail.Social;
                cmd.Parameters.Add("@Administrative", SqlDbType.NText).Value = dL_CityInfoDetail.Administrative;
                cmd.Parameters.Add("@Economy", SqlDbType.NText).Value = dL_CityInfoDetail.Economy;
                cmd.Parameters.Add("@Travel", SqlDbType.NText).Value = dL_CityInfoDetail.Travel;
                cmd.Parameters.Add("@Status", SqlDbType.Int).Value = dL_CityInfoDetail.Status;
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: Update"));
            }
        }
        public long Delete(long ID, long userID)
        {
            SqlConnection cnn = null;
            try
            {
                long id = 0;
                cnn = DataProvider.OpenConnection();
                SqlCommand cmd = new SqlCommand(DL_CityInfoDetailProcedure.p_DL_CityInfoDetail_Delete.ToString(), cnn);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: Delete"));
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
                SqlCommand cmd = new SqlCommand(DL_CityInfoDetailProcedure.p_DL_CityInfoDetail_Delete.ToString(), cnn, tran);
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
                throw new DataAccessException(ExceptionMessage.throwEx(ex, "ERROR_DL_CityInfoDetailDAL: Delete"));
            }
        }
    }
}