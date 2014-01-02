using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Configuration;

namespace DuLichDLL.TOOLS
{
    public class DataProvider
    {
        protected SqlDataAdapter sa = null;
        public static SqlConnection cnn;

        public static SqlConnection OpenConnection()
        {
            try
            {
                string strconnect = ConfigurationManager.ConnectionStrings["coConnect"].ToString();
                cnn = new SqlConnection(strconnect);
                cnn.Open();
                return cnn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void closeConnection()
        {
            if (cnn != null)
            {
                cnn.Close();
            }
        }

        public static void closeConnection(SqlConnection con)
        {
            if (con != null)
            {
                con.Close();
            }
        }

        public static bool DoesUserHavePermission()
        {
            try
            {
                SqlClientPermission clientPermission = new SqlClientPermission(PermissionState.Unrestricted);

                // will throw an error if user does not have permissions
                clientPermission.Demand();

                return true;
            }
            catch
            {
                return false;
            }
        }

        //ham dung cho cau truy van SELECT
        public static DataTable ExecuteQuery(String query)
        {
            try
            {
                OpenConnection();
                DataTable result = new DataTable();
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(query, cnn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(result);
                closeConnection();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ham dung cho cac cau truy van: INSERT, UPDATE, DELETE
        public static bool ExecuteNonQuery(String query)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand(query, cnn);
                bool check = false;
                if (cmd.ExecuteReader().HasRows)
                {
                    check = true;
                }
                closeConnection();
                return check;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Dung Cho Cau Sto Select Do Len Bang
        public DataTable StoexecuteQuery(String sqlString)
        {
            try
            {
                OpenConnection();
                DataSet ds = new DataSet();
                sa = new SqlDataAdapter(sqlString, cnn);
                sa.Fill(ds);
                closeConnection();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
