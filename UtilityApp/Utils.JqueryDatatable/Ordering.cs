
namespace Utils.JqueryDatatable
{
    /// <summary>
    /// Ordering data columns
    /// </summary>
    public class Ordering
    {
        /// <summary>
        /// order column on table
        /// </summary>
        public int Column { get; set; }
        /// <summary>
        /// Custom property
        /// Set column name for the current ordering column
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// Direction
        /// </summary>
        public SortingDirection Dir { get; set; }
    }
}
