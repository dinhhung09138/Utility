using System;
using System.Diagnostics;
namespace Utils.ErrorLogger
{
    /// <summary>
    /// Window logger
    /// </summary>
    public class WindowsLoggerHelper
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
                ////Write to Windows event log
                if (!EventLog.SourceExists(EVENT_LOG_NAME))
                    EventLog.CreateEventSource(objException.Message, EVENT_LOG_NAME);

                //// Inserting into event log
                EventLog _log = new EventLog { Source = EVENT_LOG_NAME };
                _log.WriteEntry(objException.Message, EventLogEntryType.Error);

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
            var _logName = eventLogName ?? string.Empty;
            EventLog _log = new EventLog { Source = _logName };
            try
            {
                if (!EventLog.SourceExists(_logName))
                    EventLog.CreateEventSource(objException.Message, _logName);

                // Inserting into event log
                _log.WriteEntry(objException.Message, entryType);
            }
            catch (Exception ex)
            {
                _log.Source = _logName;
                _log.WriteEntry(Convert.ToString("INFORMATION: ") + Convert.ToString(ex.Message),
                EventLogEntryType.Information);
            }
            finally
            {
                _log.Dispose();
            }
        }

    }
}
