using Home_Work.DTO.Report;
using Home_Work.Models.Data;
using Home_Work.Repository.Report;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Home_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly HomeWorkDbContext _context;
        readonly ReportService report;
        public ReportController(HomeWorkDbContext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        [Route("GetAllItem")]
        public async Task<IActionResult> GetAllItem(bool isActive, bool isDownload)
        {
            var data = await (from i in _context.TblItems
                              where i.IsActive == true
                              select new GetItemListDTO
                              {
                                  IntItemId = i.IntItemId,
                                  StrItemName = i.StrItemName,
                                  NumStockQuantity = i.NumStockQuantity,
                                  IsActive = i.IsActive
                              }).ToListAsync();
            if (isDownload == true)
            {
                return await DownloadExcel.GetItemList(data);
            }
            else
            {
                return Ok(data);
            }           
        }
        
    }
}
