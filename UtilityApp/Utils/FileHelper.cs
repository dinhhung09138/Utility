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
    public static class FileHelper
    {
        /// <summary>
        /// Read content from file path
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns></returns>
        public static string ReadTextFile(this string filePath)
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

        /// <summary>
        /// Save text file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <param name="content">content (byte)</param>
        public static void SaveFile(this string filePath, byte[] content)
        {
            string directoryName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryName))
            {
                if (!string.IsNullOrWhiteSpace(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
            }
            using (FileStream str = File.Create(filePath))
            {
                str.Write(content, 0, content.Length);
            }
        }
    }
}
