using System;
using System.Net;
using System.Text;
using Utils.Database;

namespace Utils.ErrorLogger
{
    /// <summary>
    /// Write log to database class
    /// </summary>
    public class DatabaseLogger
    {
        /// <summary>
        /// Table name
        /// Use for write log
        /// </summary>
        private static readonly string TABLE_NAME = "SYS_ERROR_LOGGING";
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
            StringBuilder query = new StringBuilder();
            query.Append("INSERT INTO [SYS_ERROR_LOGGING] ");
            query.Append("  ( ");
            query.Append("      [Id], ");
            query.Append("      [Controller], ");
            query.Append("      [Action], ");
            query.Append("      [FileName], ");
            query.Append("      [MethodName], ");
            query.Append("      [Description], ");
            query.Append("      [UserId], ");
            query.Append("      [CreatedDate] ");
            query.Append("  ) ");
            query.Append("VALUES ");
            query.Append("  ( ");
            query.Append("      '" + Guid.NewGuid() + "', ");
            query.Append("      '" + controller + "', ");
            query.Append("      '" + action + "', ");
            query.Append("      '" + fileName + "', ");
            query.Append("      '" + objException.Message + "', ");
            query.Append("      '" + DateTime.Now + "', ");
            query.Append("      '" + userId + "'");
            query.Append("  ) ");
            Database.ADOExecute.ExecuteNonquery(query.ToString());
            //IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            //using (var context = new StandardDataLibraryEntities())
            //{
            //    //App Type = Site type 1) web 2) WebAPI 3) WindowService
            //    var objXmlLog = new GMALog
            //    {
            //        SiteId = siteId,
            //        AppType = siteType,
            //        LogType = logType,
            //        FileSection = fileName,
            //        MethodName = methodName,
            //        LogDescription = logDescription + "<br /> " + objException,
            //        Status = (int)Status.Active,
            //        IPAddress = "IPv4 Address : " + ips[1],
            //        CreatedBy = userId,
            //        CreatedOnUtc = DateTime.Now
            //    };
            //    context.GMALogs.Add(objXmlLog);
            //    context.SaveChanges();
            //}
        }

    }
}
