using System;
using System.Net;
using System.Net.Mail;
using Utils.ErrorLogger;

namespace Utils.Email
{
    /// <summary>
    /// Email
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// INit error message
        /// </summary>
        private class Error
        {
            /// <summary>
            /// Error message for SendMail function 01
            /// </summary>
            public static string E01 = "Sendemail function with default configuration";

            /// <summary>
            /// Error message for SendMail function 02
            /// </summary>
            public static string E02 = "Sendemail function with input configuration";
        }

        /// <summary>
        /// Host name
        /// Default: smtp.gmail.com
        /// </summary>
        public static string HOST = "smtp.gmail.com";

        /// <summary>
        /// Email port
        /// Default: 578
        /// </summary>
        public static int PORT = 578;

        /// <summary>
        /// Enable ssl 
        /// Defaule: false
        /// </summary>
        public static bool ENABLE_SSL = false;

        /// <summary>
        /// Use default credentials
        /// Default: false
        /// </summary>
        public static bool USE_DEFAULT_CREDENTIALS = false;

        /// <summary>
        /// Send an email
        /// Use default config.
        /// You can custom default value
        /// </summary>
        /// <param name="email">Send from email</param>
        /// <param name="password">Password of send from email</param>
        /// <param name="emailTo">Sent to</param>
        /// <param name="mailsubject">subject</param>
        /// <param name="mailBody">body</param>
        /// <returns>return 1/0</returns>
        public static int Sendemail(string email, string password, string emailTo, string mailsubject, string mailBody)
        {
            try
            {
                using (MailMessage mail = new MailMessage(email, emailTo))
                {
                    mail.Subject = mailsubject;
                    mail.Body = mailBody;
                    mail.IsBodyHtml = true;
                    SmtpClient _smtp = new SmtpClient
                    {
                        Host = HOST,
                        EnableSsl = ENABLE_SSL
                    };
                    NetworkCredential _networkCredential = new NetworkCredential(email, password);
                    _smtp.UseDefaultCredentials = USE_DEFAULT_CREDENTIALS;
                    _smtp.Credentials = _networkCredential;
                    _smtp.Port = PORT;
                    _smtp.Send(mail);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
            return 0;
        }

        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="host">Host name, Ex: smtp.gmail.com</param>
        /// <param name="port">Port, Ex: 587</param>
        /// <param name="enableSSL">true/false</param>
        /// <param name="useDefaultCredentials">True/False</param>
        /// <param name="email">Send from email</param>
        /// <param name="password">Password of send from email</param>
        /// <param name="emailTo">Sent to</param>
        /// <param name="mailsubject">subject</param>
        /// <param name="mailBody">body</param>
        /// <returns>1/0</returns>
        public static int Sendemail(string host, int port, bool enableSSL, bool useDefaultCredentials, string email, string password, string emailTo, string mailsubject, string mailBody)
        {
            try
            {
                using (MailMessage mail = new MailMessage(email, emailTo))
                {
                    mail.Subject = mailsubject;
                    mail.Body = mailBody;
                    mail.IsBodyHtml = true;
                    SmtpClient _smtp = new SmtpClient
                    {
                        Host = host,
                        EnableSsl = enableSSL
                    };
                    NetworkCredential _networkCredential = new NetworkCredential(email, password);
                    _smtp.UseDefaultCredentials = useDefaultCredentials;
                    _smtp.Credentials = _networkCredential;
                    _smtp.Port = port;
                    _smtp.Send(mail);
                    return 1;
                }
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
                return 0;
            }
        }
    }
}
