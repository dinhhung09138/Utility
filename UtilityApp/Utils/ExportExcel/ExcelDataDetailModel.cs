namespace Utils.ExportExcel
{
    /// <summary>
    /// Value data model
    /// </summary>
    public class ExcelDataDetailModel
    {
        /// <summary>
        /// Row of cell
        /// </summary>
        public int Row { get; set; } = 0;

        /// <summary>
        /// Column of cell
        /// </summary>
        public int Col { get; set; } = 0;

        /// <summary>
        /// Value in a cell
        /// </summary>
        public object Value { get; set; } = string.Empty;

        /// <summary>
        /// Bold
        /// </summary>
        public bool Bold { get; set; } = false;
    }
}
