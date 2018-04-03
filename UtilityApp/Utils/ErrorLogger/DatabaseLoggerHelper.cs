using System;
using System.Net;
using System.Text;
using Utils.Database;

namespace Utils.ErrorLogger
{
    /// <summary>
    /// Write log to database class
    /// </summary>
    public class DatabaseLoggerHelper
    {
        /// <summary>
        /// Table name
        /// Use for write log
        /// </summary>
        ///private static readonly string TABLE_NAME = "SYS_ERROR_LOGGING";

        /// <summary>
        /// Write log to Database
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="fileName"></param>
        /// <param name="methodName"></param>
        /// <param name="objException"></param>
        /// <param name="userId"></param>
        public static void OutputLog(string controller, string action, string fileName, string methodName, Exception objException, string userId)
        {
            StringBuilder _query = new StringBuilder();
            _query.Append("INSERT INTO [SYS_ERROR_LOGGING] ");
            _query.Append("  ( ");
            _query.Append("      [Id], ");
            _query.Append("      [Controller], ");
            _query.Append("      [Action], ");
            _query.Append("      [FileName], ");
            _query.Append("      [MethodName], ");
            _query.Append("      [Description], ");
            _query.Append("      [UserId], ");
            _query.Append("      [CreatedDate] ");
            _query.Append("  ) ");
            _query.Append("VALUES ");
            _query.Append("  ( ");
            _query.Append("      '" + Guid.NewGuid() + "', ");
            _query.Append("      '" + controller + "', ");
            _query.Append("      '" + action + "', ");
            _query.Append("      '" + fileName + "', ");
            _query.Append("      '" + objException.Message + "', ");
            _query.Append("      '" + DateTime.Now + "', ");
            _query.Append("      '" + userId + "'");
            _query.Append("  ) ");
            ADOExecuteHelper.ExecuteNonquery(_query.ToString());
        }

    }
}
