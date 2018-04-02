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
    /// <summary>
    /// SQL Execute using ado.net
    /// </summary>
    public class ADOExecuteHelper
    {
        /// <summary>
        /// Connection string
        /// </summary>
        private static string SqlConnectionStr = "";

        /// <summary>
        /// Set connect string
        /// </summary>
        /// <param name="connectionStr">connect string</param>
        public void SetConnectionString(string connectionStr)
        {
            SqlConnectionStr = connectionStr;
        }

        /// <summary>
        /// Open sql connection
        /// </summary>
        /// <returns>SqlConnection</returns>
        private static SqlConnection GetConnectionString()
        {
            SqlConnection _myConn = new SqlConnection(SqlConnectionStr);
            if (_myConn.State == ConnectionState.Open)
                _myConn.Close();
            _myConn.Open();
            return _myConn;
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
                    SqlCommand _mycommand = new SqlCommand(strQuery, myconn);
                    _mycommand.CommandType = CommandType.Text;
                    return Convert.ToString(_mycommand.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                TextLoggerHelper.OutputLog(DatabaseConstant.Erorr.SCALA_ERROR, ex);
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
                SqlDataAdapter _adp = new SqlDataAdapter(strQuery, myconn);
                DataSet _ds = new DataSet();
                _adp.Fill(_ds, strTable);
                return _ds;
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
                    SqlDataAdapter _adp = new SqlDataAdapter(strStore, myconn);
                    DataSet _ds = new DataSet();
                    _adp.Fill(_ds);
                    if (_ds.Tables.Count > 0)
                        return _ds.Tables[0];
                    else
                        return null;
                }
            }
            catch(Exception ex)
            {
                TextLoggerHelper.OutputLog("TODO", ex);
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
                    SqlDataAdapter _adp = new SqlDataAdapter(strStore, myconn);
                    DataSet _ds = new DataSet();
                    _adp.Fill(_ds);
                    if (_ds.Tables.Count > 0)
                        return _ds.Tables[0];
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog("TODO", ex);
                return null;
            }
        }

        /// <summary>
        /// Get data from database using store. Return a datatable
        /// </summary>
        /// <param name="strStore">Store name</param>
        /// <param name="prams">List of Sql parameters</param>
        /// <returns>Datatable</returns>
        public static DataTable ReturnDataTable(string strStore, SqlParameter[] prams)
        {
            using (SqlConnection myconn = GetConnectionString())
            {
                SqlCommand _mycommand = CreateCommand(strStore, myconn, prams);
                DataTable _dt = new DataTable();
                DataSet _ds = new DataSet();
                SqlDataAdapter _adp = new SqlDataAdapter(_mycommand);
                _adp.Fill(_dt);
                return _dt;
            }
        }
        
        /// <summary>
        /// Create command
        /// </summary>
        /// <param name="strStore">store name</param>
        /// <param name="myconn">SQL connect</param>
        /// <param name="param">List of sql parameters</param>
        /// <returns>SqlCommand</returns>
        private static SqlCommand CreateCommand(string strStore, SqlConnection myconn, SqlParameter[] param)
        {
            SqlCommand _mycommand = new SqlCommand(strStore, myconn);
            _mycommand.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                foreach (SqlParameter p in param)
                {
                    _mycommand.Parameters.Add(p);
                }
            }
            return _mycommand;
        }
        
        /// <summary>
        /// Create a Sql Parameter
        /// </summary>
        /// <param name="ParamName">Parameter's name</param>
        /// <param name="SqlDbType">Type</param>
        /// <param name="Size">Size of value</param>
        /// <param name="direction">Direction, input or output</param>
        /// <param name="value">Value of parameter</param>
        /// <returns>SqlParamter</returns>
        public static SqlParameter AddParameter(string ParamName, SqlDbType SqlDbType, int Size, ParameterDirection direction, object value)
        {
            SqlParameter _param;
            if (Size > 0)
                _param = new SqlParameter(ParamName, SqlDbType, Size);
            else
                _param = new SqlParameter(ParamName, SqlDbType);
            _param.Direction = direction;
            if (!(direction == ParameterDirection.Output && value == null))
                _param.Value = value;

            return _param;
        }
        
        /// <summary>
        /// Execute a query string
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static int ExecuteNonquery(string queryString)
        {
            try
            {
                using (SqlConnection myconn = GetConnectionString())
                {
                    SqlCommand _cmd = new SqlCommand(queryString, myconn);
                    _cmd.CommandType = CommandType.Text;
                    return _cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                TextLoggerHelper.OutputLog("ExecuteNonquery", ex);
            }
            return -1;
        }
    }
}
