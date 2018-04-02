
namespace Utils.ExportExcel
{
    /// <summary>
    /// Range horizontal formating
    /// </summary>
    public class ExcelHorizontalDetailModel
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
        /// Horizontal alignment. Default is left
        /// </summary>
        public OfficeOpenXml.Style.ExcelHorizontalAlignment Horizontal { get; set; } = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
    }
}
