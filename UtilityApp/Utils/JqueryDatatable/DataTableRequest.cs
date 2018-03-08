using System.Collections.Generic;

namespace Utils.JqueryDatatable
{
    /// <summary>
    /// Jquery datatable Request from client
    /// </summary>
    public class DataTableRequest
    {
        /// <summary>
        /// draw
        /// </summary>
        public int draw { get; set; }

        /// <summary>
        /// start
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// length
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// order
        /// </summary>
        public List<Ordering> order { get; set; }

        /// <summary>
        /// search
        /// </summary>
        public Search search { get; set; }

        /// <summary>
        /// columns
        /// </summary>
        public List<Column> columns { get; set; }
    }
}
