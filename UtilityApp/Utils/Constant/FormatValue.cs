using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Constant
{
    /// <summary>
    /// Constant Data format value
    /// </summary>
    public class FormatValue
    {
        /// <summary>
        /// Date and time format
        /// dd/MM/yyyy HH:mm:ss
        /// </summary>
        public static readonly string FULL_DATE_FORMAT = "dd/MM/yyyy HH:mm:ss";

        /// <summary>
        /// Date format
        /// dd/MM/yyyy
        /// </summary>
        public static readonly string DATE_FORMAT = "dd/MM/yyyy";

        /// <summary>
        ///  Number format
        ///  #,##0
        /// </summary>
        public static readonly string NUMBER_FORMAT = "#,##0";

        /// <summary>
        /// Price format
        /// #,##0.##
        /// </summary>
        public static readonly string PRICE_FORMAT = "#,##0.##";
    }
}
