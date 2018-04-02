
namespace Utils.ExportExcel
{
    /// <summary>
    /// Range border formating
    /// </summary>
    public class ExcelBorderDetailModel
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
        /// Border value. Default thin
        /// </summary>
        public OfficeOpenXml.Style.ExcelBorderStyle Border { get; set; } = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
    }
}
