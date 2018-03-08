using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    /// <summary>
    /// Response status code
    /// </summary>
    public enum ResponseStatusCode
    {

        /// <summary>
        /// Return success when execute action is success
        /// </summary>
        Success,
        /// <summary>
        /// Return error when execute action is error
        /// </summary>
        Error,

        /// <summary>
        /// Whan to tell user know have some notification or something
        /// </summary>
        Warning
    }
}
