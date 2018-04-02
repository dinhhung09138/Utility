using System.Collections.Generic;

namespace Utils.ExportExcel
{
    /// <summary>
    /// Excel content model
    /// </summary>
    public class ExcelContentModel
    {
        /// <summary>
        /// Sheet name
        /// </summary>
        public string SheetName { get; set; } = "";

        /// <summary>
        /// Show gridline. Default is false
        /// </summary>
        public bool ShowGridLines { get; set; } = false;

        /// <summary>
        /// Is protection sheet
        /// Default is false
        /// </summary>
        public bool IsProtected { get; set; } = false;

        /// <summary>
        /// Allow select locked cells
        /// Default false
        /// </summary>
        public bool AllowSelectLockedCells { get; set; } = false;

        /// <summary>
        /// List of data content in sheet
        /// </summary>
        public List<ExcelDataDetailModel> Data { get; set; } = new List<ExcelDataDetailModel>();

        /// <summary>
        /// Horizontal formating
        /// </summary>
        public List<ExcelHorizontalDetailModel> Horizontals { get; set; } = new List<ExcelHorizontalDetailModel>();

        /// <summary>
        /// Vertical formating
        /// </summary>
        public List<ExcelVerticalDetailModel> Verticals { get; set; } = new List<ExcelVerticalDetailModel>();

        /// <summary>
        /// Merge cells list
        /// </summary>
        public List<ExcelMergeDetailModel> Merges { get; set; } = new List<ExcelMergeDetailModel>();

        /// <summary>
        /// Border cells list
        /// </summary>
        public List<ExcelBorderDetailModel> Borders { get; set; } = new List<ExcelBorderDetailModel>();

        /// <summary>
        /// Format data content
        /// </summary>
        public List<ExcelFromatingDetailModel> Formatings { get; set; } = new List<ExcelFromatingDetailModel>();

    }
}
