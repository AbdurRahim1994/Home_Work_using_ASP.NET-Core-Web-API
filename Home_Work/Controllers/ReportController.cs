using Home_Work.Models.Data;
using Home_Work.Repository.Report;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAllItem(bool isActive)
        {
            var dt = await report.GetItemList(isActive);
            return await DownloadExcel.GetItemList(dt);
        }
        
    }
}
