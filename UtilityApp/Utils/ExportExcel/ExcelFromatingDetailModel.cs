
namespace Utils.ExportExcel
{
    /// <summary>
    /// Data formating
    /// </summary>
    public class ExcelFromatingDetailModel
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
        /// Format string. Default @
        /// </summary>
        public string Format { get; set; } = "@";
    }
}
