using System.Collections.Generic;
namespace Utils.JqueryDatatable
{
    /// <summary>
    /// Jquery datatable Request from client
    /// </summary>
    public class DataTableRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public int draw { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int start { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Ordering> order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Search search { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Column> columns { get; set; }
    }
}
