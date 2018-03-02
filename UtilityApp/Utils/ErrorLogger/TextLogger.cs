using System;
using System.IO;
using System.Net;

namespace Utils.ErrorLogger
{
    /// <summary>
    /// For log error and information in file and in database.
    /// </summary>
    public class TextLogger
    {
        #region " [ Properties ] "
        
        /// <summary>
        /// The string log file path.
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
                string baseDir = AppDomain.CurrentDomain.BaseDirectory + AppDomain.CurrentDomain.RelativeSearchPath;

                baseDir = Path.Combine(baseDir, "Logs");
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
        /// This Is created in order to maintain Additional infomation in the seperate file path and for clear visibility
        /// </summary>
        /// <param name="logDescription">The log description.</param>
        /// <returns></returns>
        public static bool OutputLog(string logDescription)
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
        public static bool OutputLog(string AdditionInforDescription, Exception objException)
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

        #endregion

    }
}
