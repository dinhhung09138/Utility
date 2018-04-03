using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Utils.Validation
{
    /// <summary>
    /// Regular validation function class
    /// </summary>
    public static class RegularValidationHelper
    {
        /// <summary>
        /// Invalid state
        /// </summary>
        private static bool invalid = false;

        /// <summary>
        /// Check isvalid email
        /// </summary>
        /// <param name="strIn">Email string input</param>
        /// <returns>true/false</returns>
        public static bool IsValidEmail(this string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Check domain
        /// Not use Now
        /// </summary>
        /// <param name="match"></param>
        /// <returns></returns>
        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping _idn = new IdnMapping();

            string _domainName = match.Groups[2].Value;
            try
            {
                _domainName = _idn.GetAscii(_domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + _domainName;
        }
    }
}
