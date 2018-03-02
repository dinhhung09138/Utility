using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ErrorLogger
{
    public class WindowsLogger
    {
        #region " [ Properties ] "

        private static readonly string EVENT_LOG_NAME = "WebLog";
        
        #endregion

        /// <summary>
        /// Adds the log to window event.
        /// Write error log entry for window event if the bLogType is true. Otherwise, write the log entry to
        /// customized text-based text file
        /// </summary>
        /// <param name="objException">The object exception.</param>
        /// <returns>
        /// false if the problem persists
        /// </returns>
        public static bool OutputLog(Exception objException)
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
        public static void OutputLog(Exception objException, string eventLogName, EventLogEntryType entryType)
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
