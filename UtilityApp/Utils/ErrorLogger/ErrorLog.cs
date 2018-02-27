using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ErrorLogger
{
    /// <summary>
    /// For log error and information in file and in database.
    /// </summary>
    public class ErrorLog
    {
        #region " [ Properties ] "

        private static readonly string EVENT_LOG_NAME = "WebLog";

        /// <summary>
        /// The string log file path
        /// </summary>
        private static string _strLogFilePath = string.Empty;

        /// <summary>
        /// The sw
        /// </summary>
        private static StreamWriter _sw;

        /// <summary>
        /// Setting LogFile path. If the logfile path is null then it will update error info into LogFile.txt under
        /// application directory.
        /// </summary>
        /// <value>
        /// The log file path.
        /// </value>
        public static string LogFilePath
        {
            set
            {
                _strLogFilePath = value;
                string pathWithoutFilename = Path.GetDirectoryName(_strLogFilePath);
                if (!Directory.Exists(pathWithoutFilename))
                {
                    Directory.CreateDirectory(pathWithoutFilename);
                }
                if (!File.Exists(_strLogFilePath))
                {
                    File.Create(_strLogFilePath);
                }
            }
            get
            {
                return _strLogFilePath;
            }
        }

        #endregion

        #region " [ Private function ] "

        /// <summary>
        /// Check the log file in applcation directory. If it is not available, creae it
        /// </summary>
        /// <returns>
        /// Log file path
        /// </returns>
        private static string GetLogFilePath(bool infoLog = true)
        {
            try
            {
                // get the base directory
                //string baseDir = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.RelativeSearchPath;

                string baseDir = Path.Combine(LogFilePath, "Logs");
                // search the file below the current directory
                if (!Directory.Exists(baseDir))
                {
                    Directory.CreateDirectory(baseDir);
                }
                string retFilePath = "";
                if (infoLog)
                {
                    retFilePath = Path.Combine(baseDir, "InforLog.txt");
                }
                else
                {
                    retFilePath = Path.Combine(baseDir, "ErrorLog.txt");
                }

                // if exists, return the path
                if (File.Exists(retFilePath))
                    return retFilePath;
                //create a text file
                else
                {
                    if (!CheckDirectory(retFilePath))
                        return string.Empty;

                    FileStream fs = new FileStream(retFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Close();
                }

                return retFilePath;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Create a directory if not exists
        /// </summary>
        /// <param name="strLogPath">The string log path.</param>
        /// <returns></returns>
        private static bool CheckDirectory(string strLogPath)
        {
            try
            {
                int nFindSlashPos = strLogPath.Trim().LastIndexOf("\\", StringComparison.Ordinal);
                string strDirectoryname = strLogPath.Trim().Substring(0, nFindSlashPos);

                if (!Directory.Exists(strDirectoryname))
                    Directory.CreateDirectory(strDirectoryname);

                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        /// <summary>
        /// Writes the error log.
        /// </summary>
        /// <param name="strPathName">Name of the string path.</param>
        /// <param name="objException">The object exception.</param>
        /// <param name="additionalinfo">The additionalinfo.</param>
        /// <param name="isException">Exception or not.</param>
        /// <returns></returns>
        private static bool WriteErrorLog(string strPathName, Exception objException, string additionalinfo, bool isException)
        {
            bool bReturn;

            try
            {
                IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

                _sw = new StreamWriter(strPathName, true);
                if (isException)
                {
                    _sw.WriteLine("Source		: " + objException.Source.Trim());
                    _sw.WriteLine("Method		: " + objException.TargetSite.Name);
                    _sw.WriteLine("Date		: " + DateTime.Now.ToShortDateString());
                    _sw.WriteLine("Time		: " + DateTime.Now.ToLongTimeString());
                    _sw.WriteLine("Computer	: " + Dns.GetHostName());
                    _sw.WriteLine("Link-local IPv6 Address: " + ips[0] + " IPv4 Address : " + ips[1]);
                    _sw.WriteLine("Error		: " + objException.Message.Trim());
                    _sw.WriteLine("Stack Trace	: " + objException.StackTrace.Trim());
                    _sw.WriteLine("^^-------------------------------------------------------------------^^");
                }
                else
                {
                    _sw.WriteLine("Date		: " + DateTime.Now.ToShortDateString());
                    _sw.WriteLine("Time		: " + DateTime.Now.ToLongTimeString());
                    _sw.WriteLine("Computer	: " + Dns.GetHostName());
                    _sw.WriteLine("Link-local IPv6 Address: " + ips[0] + " IPv4 Address : " + ips[1]);
                    _sw.WriteLine("Additional Info		: " + additionalinfo.Trim());
                    _sw.WriteLine("^^-------------------------------------------------------------------^^");
                }
                _sw.Flush();
                _sw.Close();
                bReturn = true;
            }
            catch (Exception)
            {
                bReturn = false;
            }
            return bReturn;
        }


        #endregion

        #region " [ Publish ] "

        /// <summary>
        /// Adds the log to window event.
        /// Write error log entry for window event if the bLogType is true. Otherwise, write the log entry to
        /// customized text-based text file
        /// </summary>
        /// <param name="objException">The object exception.</param>
        /// <returns>
        /// false if the problem persists
        /// </returns>
        public static bool AddLogToWindowEvent(Exception objException)
        {
            try
            {
                //Write to Windows event log
                if (!EventLog.SourceExists(EVENT_LOG_NAME))
                    EventLog.CreateEventSource(objException.Message, EVENT_LOG_NAME);

                // Inserting into event log
                EventLog log = new EventLog { Source = EVENT_LOG_NAME };
                log.WriteEntry(objException.Message, EventLogEntryType.Error);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Adds the log to window event.
        /// </summary>
        /// <param name="objException">The object exception.</param>
        /// <param name="eventLogName">Name of the event log.</param>
        /// <param name="entryType">Type of the entry.</param>
        public static void AddLogToWindowEvent(Exception objException, string eventLogName, EventLogEntryType entryType)
        {
            var logName = eventLogName ?? "";
            EventLog log = new EventLog { Source = logName };
            try
            {
                if (!EventLog.SourceExists(logName))
                    EventLog.CreateEventSource(objException.Message, logName);

                // Inserting into event log
                log.WriteEntry(objException.Message, entryType);
            }
            catch (Exception ex)
            {
                log.Source = logName;
                log.WriteEntry(Convert.ToString("INFORMATION: ")
                                      + Convert.ToString(ex.Message),
                EventLogEntryType.Information);
            }
            finally
            {
                log.Dispose();
            }
        }

        /// <summary>
        /// This Is created in order to maintain Additional infomation in the seperate file path and for clear visibility
        /// </summary>
        /// <param name="logDescription">The log description.</param>
        /// <returns></returns>
        public static bool AddInfoLogToFile(string logDescription)
        {
            string strAddlogPathName;
            if (LogFilePath.Equals(string.Empty))
            {
                //Get Default log file path "LogFile.txt"
                strAddlogPathName = GetLogFilePath(true);
            }
            else
            {
                //If the log file path is not empty but the file is not available it will create it
                if (!File.Exists(LogFilePath))
                {
                    if (!CheckDirectory(LogFilePath))
                        return false;

                    FileStream fs = new FileStream(LogFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Close();
                }
                strAddlogPathName = LogFilePath;
            }

            Exception ex = new Exception();
            bool bReturn = WriteErrorLog(strAddlogPathName, ex, logDescription, false);
            return bReturn;
        }

        /// <summary>
        /// This Is created in order to maintain Additional infomation in the seperate file path and for clear visibility
        /// </summary>
        /// <param name="AdditionInforDescription">The log description. [User define]</param>
        /// <param name="objException"> Exception object </param>
        /// <returns></returns>
        public static bool AddErrorLogToFile(string AdditionInforDescription, Exception objException)
        {
            string strAddlogPathName;
            if (LogFilePath.Equals(string.Empty))
            {
                //Get Default log file path "LogFile.txt"
                strAddlogPathName = GetLogFilePath(true);
            }
            else
            {
                //If the log file path is not empty but the file is not available it will create it
                if (!File.Exists(LogFilePath))
                {
                    if (!CheckDirectory(LogFilePath))
                        return false;

                    FileStream fs = new FileStream(LogFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Close();
                }
                strAddlogPathName = LogFilePath;
            }

            bool bReturn = WriteErrorLog(strAddlogPathName, objException, AdditionInforDescription, false);
            return bReturn;
        }

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
        public static void AddLogToDb(string logDescription, string logType, int? siteId, string siteType, string fileName, string methodName, Exception objException, int userId)
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

        #endregion

    }
}
