using DinkToPdf;
using DinkToPdf.Contracts;
using Home_Work.DTO.Item;
using Home_Work.IRepository.Report;
using Home_Work.Models.Data;
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
        public PdfAndExcelController(HomeWorkDbContext context, IConverter converter, IPdfAndExcelService pdfAndExcelService, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.pdfAndExcelService= pdfAndExcelService;
            this.converter = converter;
            this.webHostEnvironment = webHostEnvironment;
        }

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
    }
}
