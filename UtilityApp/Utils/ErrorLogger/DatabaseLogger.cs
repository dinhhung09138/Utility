using System;
using System.Net;

namespace Utils.ErrorLogger
{
    /// <summary>
    /// Write log to database class
    /// </summary>
    public class DatabaseLogger
    {
        /// <summary>
        /// Adds the log in Database.
        /// Not body function
        /// </summary>
        /// <param name="logDescription">The log description.</param>
        /// <param name="logType">Type of the log.</param>
        /// <param name="siteId">The site identifier.</param>
        /// <param name="siteType">Type of the site.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="objException">The object exception.</param>
        /// <param name="userId">The user identifier.</param>
        public static void OutputLog(string logDescription, string logType, int? siteId, string siteType, string fileName, string methodName, Exception objException, int userId)
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
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
