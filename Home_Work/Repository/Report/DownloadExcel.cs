using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Home_Work.Repository.Report
{
    public class DownloadExcel
    {
        public static async Task<IActionResult> GetItemList(DataTable dt)
        {
            XLWorkbook xLWorkbook = new XLWorkbook();
            IXLWorksheet xLWorksheet = xLWorkbook.Worksheets.Add("Item List");

            // Title
            var title = xLWorksheet.Range(7, 8, 7, 11).SetValue("Item List");
            title.Merge().Style.Font.SetBold().Font.FontSize = 16;
            title.Style.Font.SetFontColor(XLColor.CoolBlack);
            title.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            title.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            // Header
            var header = xLWorksheet.Range(8, 8, 8, 11);
            header.Style.Font.SetBold();
            header.Style.Font.SetFontColor(XLColor.White);
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            header.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            header.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            header.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            header.Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            int hsl = 1;
            header.Cell(1, hsl++).SetValue("Item ID");
            header.Cell(1, hsl++).SetValue("Item Name");
            header.Cell(1, hsl++).SetValue("Quantity");
            header.Cell(1, hsl++).SetValue("Activity");

            MemoryStream MS = new MemoryStream();
            xLWorkbook.SaveAs(MS);
            MS.Position = 0;

            return new FileStreamResult(MS, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet") { FileDownloadName = "Overall Status.xlsx" };
        }
    }
}
