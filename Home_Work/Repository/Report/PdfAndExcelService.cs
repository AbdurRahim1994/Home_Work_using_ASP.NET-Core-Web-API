using DinkToPdf;
using Home_Work.DTO.Item;
using Home_Work.IRepository.Report;

namespace Home_Work.Repository.Report
{
    public class PdfAndExcelService : IPdfAndExcelService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string ItemListCSSUrl;
        public PdfAndExcelService(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.ItemListCSSUrl = webHostEnvironment.ContentRootPath + "/wwwroot/item_list.css";
        }
        public async Task<HtmlToPdfDocument> ItemListPdf(ItemDTO obj)
        {
            try
            {
                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    DocumentTitle = "Item List Report"
                };

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HeaderSettings = { Line = false },
                    HtmlContent="",
                    WebSettings = { DefaultEncoding = "UTF-8", UserStyleSheet = ItemListCSSUrl },
                    FooterSettings = { FontName = "Arial", FontSize = 6, Line = false, Right = "Page [page] of [toPage]", Center = "System Generated Report. Pinted On" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm tt") }
                };

                HtmlToPdfDocument pdf = new HtmlToPdfDocument
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                return pdf;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
