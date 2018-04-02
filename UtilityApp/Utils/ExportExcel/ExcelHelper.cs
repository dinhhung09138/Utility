using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils.ExportExcel
{
    /// <summary>
    /// Excel helper
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// Create excel file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <param name="model">list of data excel content model</param>
        /// <returns>true: success, false: error</returns>
        public static bool CreateExcelFile(string filePath, List<ExcelContentModel> model)
        {
            try
            {
                ExcelPackage _excelPkg = new ExcelPackage();
                foreach (var item in model)
                {
                    CreateSheet(_excelPkg, item);
                }
                _excelPkg.SaveAs(new FileInfo(filePath));
                return true;
            }
            catch(Exception ex)
            {
                ErrorLogger.TextLoggerHelper.OutputLog("", ex);
            }
            return false;
            
        }

        /// <summary>
        /// Create sheet
        /// </summary>
        /// <param name="excelPackage">excel package library</param>
        /// <param name="excelModel">data sheet model</param>
        /// <returns>ExcelWorksheet</returns>
        private static ExcelWorksheet CreateSheet(ExcelPackage excelPackage, ExcelContentModel excelModel)
        {
            ExcelWorksheet _sheet = excelPackage.Workbook.Worksheets.Add(excelModel.SheetName);
            //Data content
            foreach (var item in excelModel.Data)
            {
                _sheet.Cells[item.Row, item.Col].Value = item.Value;
                if (item.Bold)
                {
                    _sheet.Cells[item.Row, item.Col].Style.Font.Bold = item.Bold;
                }
            }
            //Horizontal formating
            foreach (var item in excelModel.Horizontals)
            {
                using (ExcelRange range = _sheet.Cells[item.FromRow, item.FromColumn, item.ToRow, item.ToColumn])
                {
                    range.Style.HorizontalAlignment = item.Horizontal;
                }
            }
            //Vertical formating
            foreach (var item in excelModel.Verticals)
            {
                using (ExcelRange range = _sheet.Cells[item.FromRow, item.FromColumn, item.ToRow, item.ToColumn])
                {
                    range.Style.VerticalAlignment = item.Vertical;
                }
            }
            //Merge
            foreach (var item in excelModel.Merges)
            {
                using (ExcelRange range = _sheet.Cells[item.FromRow, item.FromColumn, item.ToRow, item.ToColumn])
                {
                    range.Merge = true;
                }
            }
            //Border
            foreach (var item in excelModel.Borders)
            {
                using (ExcelRange range = _sheet.Cells[item.FromRow, item.FromColumn, item.ToRow, item.ToColumn])
                {
                    range.Style.Border.Top.Style = item.Border;
                    range.Style.Border.Right.Style = item.Border;
                    range.Style.Border.Bottom.Style = item.Border;
                    range.Style.Border.Left.Style = item.Border;
                }
            }
            //Set format text for all sheet
            //            _sheet.Cells.Style.Numberformat.Format = "@";
            //Format specific cell
            foreach (var item in excelModel.Formatings)
            {
                _sheet.Cells[item.FromRow, item.FromColumn, item.ToRow, item.ToColumn].Style.Numberformat.Format = item.Format;
            }
            //
            _sheet.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            _sheet.Cells.AutoFitColumns();
            _sheet.View.ShowGridLines = excelModel.ShowGridLines;
            _sheet.Protection.IsProtected = excelModel.IsProtected;
            _sheet.Protection.AllowSelectLockedCells = excelModel.AllowSelectLockedCells;
            return _sheet;
        }

    }
}
