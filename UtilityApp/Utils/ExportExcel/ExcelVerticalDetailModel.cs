namespace Utils.ExportExcel
{
    /// <summary>
    /// Range vertical formating
    /// </summary>
    public class ExcelVerticalDetailModel
    {
        /// <summary>
        /// Column of begin cell
        /// </summary>
        public int FromColumn { get; set; } = 0;

        /// <summary>
        /// Row of begin cell
        /// </summary>
        public int FromRow { get; set; } = 0;

        /// <summary>
        /// Column of end cell
        /// </summary>
        public int ToColumn { get; set; } = 0;

        /// <summary>
        /// Row of end cell
        /// </summary>
        public int ToRow { get; set; } = 0;

        /// <summary>
        /// Vertical alignment. Default center
        /// </summary>
        public OfficeOpenXml.Style.ExcelVerticalAlignment Vertical { get; set; } = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
    }
}
