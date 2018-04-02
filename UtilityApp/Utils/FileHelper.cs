using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// File helper class
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// Read content from file path
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        public static string ReadTextFile(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    String line = sr.ReadToEnd();
                    return line.ToString();
                }
            }
            catch (Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog("", ex);
            }
            finally
            {
            }
            return "";
        }

    }
}
