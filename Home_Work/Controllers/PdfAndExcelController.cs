using DinkToPdf;
using DinkToPdf.Contracts;
using Home_Work.DTO.Item;
using Home_Work.DTO.Purchase;
using Home_Work.IRepository.Purchase;
using Home_Work.IRepository.Report;
using Home_Work.Models.Data;
using Home_Work.Repository.Report;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Home_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfAndExcelController : ControllerBase
    {
        private readonly HomeWorkDbContext context;
        private readonly IConverter converter;
        private readonly IPdfAndExcelService pdfAndExcelService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPurchaseService purchaseService;
        public PdfAndExcelController(HomeWorkDbContext context, IConverter converter, IPdfAndExcelService pdfAndExcelService, IWebHostEnvironment webHostEnvironment, IPurchaseService purchaseService)
        {
            this.context = context;
            this.pdfAndExcelService= pdfAndExcelService;
            this.converter = converter;
            this.webHostEnvironment = webHostEnvironment;
            this.purchaseService = purchaseService;
        }

        #region -- PDF --
        [HttpGet]
        [Route("ItemListPdf")]
        public async Task<IActionResult> ItemListPdf()
        {
            List<ItemDTO> itemlist = await (from i in context.TblItems
                                            where i.IsActive == true
                                            select new ItemDTO
                                            {
                                                IntItemId = i.IntItemId,
                                                StrItemName = i.StrItemName,
                                                NumStockQuantity = i.NumStockQuantity,
                                                IsActive = i.IsActive
                                            }).ToListAsync();
            HtmlToPdfDocument pdf = await pdfAndExcelService.ItemListPdf(itemlist);
            var file = converter.Convert(pdf);
            return File(file, "application/pdf");
        }
        
        [HttpGet]
        [Route("ItemWiseDailyPurchaseReportPdf")]
        public async Task<IActionResult> ItemWiseDailyPurchaseReportPdf(DateTime purchaseDate)
        {
            var data = await purchaseService.ItemWiseDailyPurchaseReport(purchaseDate);
            if (data.Count() == 0)
            {
                throw new Exception("Data Not Found");
            }

            HtmlToPdfDocument pdf= await pdfAndExcelService.ItemWiseDailyPurchaseReportPdf(data);
            var file = converter.Convert(pdf);
            return File(file, "application/pdf");
        }
        #endregion

        #region -- Excel --
        [HttpGet]
        [Route("ItemWiseDailyPurchaseReportExcel")]
        public async Task<IActionResult> ItemWiseDailyPurchaseReportExcel(DateTime purchaseDate, bool isDownload)
        {
            var data =await purchaseService.ItemWiseDailyPurchaseReport(purchaseDate);
            if (isDownload == true)
            {
                return await DownloadExcel.ItemWiseDailyPurchaseReportExcel(data);
            }
            else
            {
                return Ok(data);
            }
        }
        #endregion
    }
}
