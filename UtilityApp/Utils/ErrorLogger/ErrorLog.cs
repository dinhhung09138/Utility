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

        /// <summary>
        /// Write error log entry for window event if the bLogType is true. Otherwise, write the log entry to
        /// customized text-based text file
        /// </summary>
        /// <param name="bLogType">if set to <c>true</c> [b log type].</param>
        /// <param name="objException">The object exception.</param>
        /// <returns>
        /// false if the problem persists
        /// </returns>
        public static bool ErrorRoutine(bool bLogType, Exception objException)
        {
            try
            {
                //Write to Windows event log
                if (bLogType)
                {
                    const string eventLogName = "ErrorSample";

                    if (!EventLog.SourceExists(eventLogName))
                        EventLog.CreateEventSource(objException.Message, eventLogName);

                    // Inserting into event log
                    EventLog log = new EventLog { Source = eventLogName };
                    log.WriteEntry(objException.Message, EventLogEntryType.Error);
                }
                //Custom text-based event log
                else
                {
                    //if (!CustomErrorRoutine(objException))
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// If the LogFile path is empty then, it will write the log entry to LogFile.txt under application directory.
        /// If the LogFile.txt is not availble it will create it
        /// If the Log File path is not empty but the file is not availble it will create it.
        /// </summary>
        /// <param name="objException">The object exception.</param>
        /// <param name="siteId">The site identifier.</param>
        /// <returns>
        /// false if the problem persists
        /// </returns>
        private static bool CustomErrorRoutine(Exception objException, int? siteId)
        {
            string strPathName;
            if (_strLogFilePath.Equals(string.Empty))
            {
                //Get Default log file path "LogFile.txt"
                strPathName = GetLogFilePath(0, siteId);
            }
            else
            {

                //If the log file path is not empty but the file is not available it will create it
                if (!File.Exists(_strLogFilePath))
                {
                    if (!CheckDirectory(_strLogFilePath))
                        return false;

                    FileStream fs = new FileStream(_strLogFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Close();
                }
                strPathName = _strLogFilePath;
            }

            bool bReturn = WriteErrorLog(strPathName, objException, "", 0);

            return bReturn;
        }

        /// <summary>
        /// Writes the error log.
        /// </summary>
        /// <param name="strPathName">Name of the string path.</param>
        /// <param name="objException">The object exception.</param>
        /// <param name="additionalinfo">The additionalinfo.</param>
        /// <param name="getvalue">The getvalue.</param>
        /// <returns></returns>
        private static bool WriteErrorLog(string strPathName, Exception objException, string additionalinfo, int getvalue)
        {
            bool bReturn;

            try
            {
                IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

                _sw = new StreamWriter(strPathName, true);
                if (getvalue == 0)
                {
                    _sw.WriteLine("Source		: " + objException.Source.Trim());
                    _sw.WriteLine("Method		: " + objException.TargetSite.Name);
                    _sw.WriteLine("Date		: " + DateTime.UtcNow.ToShortDateString());
                    _sw.WriteLine("Time		: " + DateTime.UtcNow.ToLongTimeString());
                    _sw.WriteLine("Computer	: " + Dns.GetHostName());
                    _sw.WriteLine("Link-local IPv6 Address: " + ips[0] + " IPv4 Address : " + ips[1]);
                    _sw.WriteLine("Error		: " + objException.Message.Trim());
                    _sw.WriteLine("Stack Trace	: " + objException.StackTrace.Trim());
                    _sw.WriteLine("^^-------------------------------------------------------------------^^");
                }
                else if (getvalue == 1)
                {
                    _sw.WriteLine("Date		: " + DateTime.UtcNow.ToShortDateString());
                    _sw.WriteLine("Time		: " + DateTime.UtcNow.ToLongTimeString());
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

        /// <summary>
        /// Check the log file in applcation directory. If it is not available, creae it
        /// </summary>
        /// <param name="getvalue">The getvalue.</param>
        /// <param name="siteId">The site identifier.</param>
        /// <returns>
        /// Log file path
        /// </returns>
        private static string GetLogFilePath(int getvalue, int? siteId)
        {
            try
            {
                // get the base directory
                //string baseDir = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.RelativeSearchPath;

                string baseDir = AppDomain.CurrentDomain.BaseDirectory + "//Logs//" + (siteId ?? 0);
                // search the file below the current directory
                if (!Directory.Exists(baseDir))
                {
                    Directory.CreateDirectory(baseDir);
                }
                string retFilePath = string.Empty;
                if (getvalue == 0)
                {
                    retFilePath = baseDir + "//" + "LogFile.txt";
                }
                else if (getvalue == 1)
                {
                    retFilePath = baseDir + "//" + "AdditionalInfoLogFile.txt";
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
        /// Gets the application path.
        /// </summary>
        /// <returns>
        /// System.String.
        /// </returns>
        private static string GetApplicationPath()
        {
            try
            {
                string strBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                int nFirstSlashPos = strBaseDirectory.LastIndexOf("\\", StringComparison.Ordinal);
                string strTemp = string.Empty;

                if (0 < nFirstSlashPos)
                    strTemp = strBaseDirectory.Substring(0, nFirstSlashPos);

                int nSecondSlashPos = strTemp.LastIndexOf("\\", StringComparison.Ordinal);
                string strTempAppPath = string.Empty;
                if (0 < nSecondSlashPos)
                    strTempAppPath = strTemp.Substring(0, nSecondSlashPos);

                string strAppPath = strTempAppPath.Replace("bin", "");
                return strAppPath;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// This Is created in order to maintain Additional infomation in the seperate file path and for clear visibility
        /// </summary>
        /// <param name="logDescription">The log description.</param>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        private static bool AddLogToFile(string logDescription, int? siteId)
        {
            string strAddlogPathName;
            if (LogFilePath.Equals(string.Empty))
            {
                //Get Default log file path "LogFile.txt"
                strAddlogPathName = GetLogFilePath(1, siteId);
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
            bool bReturn = WriteErrorLog(strAddlogPathName, ex, logDescription, 1);
            return bReturn;
        }

        /// <summary>
        /// Adds the log in Database.
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
            //        CreatedOnUtc = DateTime.UtcNow
            //    };
            //    context.GMALogs.Add(objXmlLog);
            //    context.SaveChanges();
            //}
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

    }
}
