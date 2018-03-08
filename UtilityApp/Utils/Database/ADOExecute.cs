using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Utils.ErrorLogger;

namespace Utils.Database
{
    public class ADOExecute
    {
        /// <summary>
        /// Connection string
        /// </summary>
        public static string SqlConnectionStr = "";

        /// <summary>
        /// Open sql connection
        /// </summary>
        /// <returns>SqlConnection</returns>
        private static SqlConnection GetConnectionString()
        {
            SqlConnection myConn = new SqlConnection(SqlConnectionStr);
            if (myConn.State == ConnectionState.Open)
                myConn.Close();
            myConn.Open();
            return myConn;
        }

        /// <summary>
        /// Execute query return only a value.
        /// Query must be return one value
        /// If query not return any, please return a default value
        /// Return null when get error
        /// </summary>
        /// <param name="strQuery"></param>
        /// <returns></returns>
        public static string ExecuteScalar(string strQuery)
        {
            try
            {
                using (SqlConnection myconn = GetConnectionString())
                {
                    SqlCommand mycommand = new SqlCommand(strQuery, myconn);
                    mycommand.CommandType = CommandType.Text;
                    return Convert.ToString(mycommand.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                TextLogger.OutputLog(DatabaseConstant.Erorr.SCALA_ERROR, ex);
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strQuery"></param>
        /// <param name="strTable"></param>
        /// <returns></returns>
        public static DataSet ReturnDataset(string strQuery, string strTable)
        {
            using (SqlConnection myconn = GetConnectionString())
            {
                SqlDataAdapter adp = new SqlDataAdapter(strQuery, myconn);
                DataSet ds = new DataSet();
                adp.Fill(ds, strTable);
                return ds;
            }
        }

        /// <summary>
        /// Execute store to return a datable.
        /// Return null if not found or error
        /// </summary>
        /// <param name="strStore">Store procedure name</param>
        /// <returns>Datatable</returns>
        public static DataTable ReturnDataTable(string strStore)
        {
            try
            {
                using (SqlConnection myconn = GetConnectionString())
                {
                    SqlDataAdapter adp = new SqlDataAdapter(strStore, myconn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables.Count > 0)
                        return ds.Tables[0];
                    else
                        return null;
                }
            }
            catch(Exception ex)
            {
                TextLogger.OutputLog("TODO", ex);
                return null;
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="strStore"></param>
        /// <param name="tableName"></param>
        /// <param name="columnSelected"></param>
        /// <param name="whereCondition"></param>
        /// <returns></returns>
        public static DataTable ReturnDataTable(string strStore, string tableName, List<string> columnSelected, List<KeyValuePair<string, SqlParameter>> whereCondition)
        {
            try
            {
                using (SqlConnection myconn = GetConnectionString())
                {
                    SqlDataAdapter adp = new SqlDataAdapter(strStore, myconn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables.Count > 0)
                        return ds.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                TextLogger.OutputLog("TODO", ex);
                return null;
            }
        }

        public static DataTable ReturnDataTable(string strStore, SqlParameter[] prams)
        {
            using (SqlConnection myconn = GetConnectionString())
            {
                SqlCommand mycommand = CreateCommand(strStore, myconn, prams);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                SqlDataAdapter adp = new SqlDataAdapter(mycommand);
                adp.Fill(dt);
                return dt;
            }
        }
        
        private static SqlCommand CreateCommand(string strStore, SqlConnection myconn, SqlParameter[] param)
        {
            SqlCommand mycommand = new SqlCommand(strStore, myconn);
            mycommand.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    mycommand.Parameters.Add(p);
                }
            }
            return mycommand;
        }
        
        public static SqlParameter AddParameter(string ParamName, SqlDbType SqlDbType, int Size, ParameterDirection direction, object value)
        {
            SqlParameter param;
            if (Size > 0)
                param = new SqlParameter(ParamName, SqlDbType, Size);
            else
                param = new SqlParameter(ParamName, SqlDbType);
            param.Direction = direction;
            if (!(direction == ParameterDirection.Output && value == null))
                param.Value = value;

            return param;
        }
        
    }
}
