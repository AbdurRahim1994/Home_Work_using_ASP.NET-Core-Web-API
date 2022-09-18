using Home_Work.DTO.Sales;
using Home_Work.IRepository.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Home_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        public SalesController(ISalesService _salesService)
        {
            this._salesService = _salesService;
        }
        [HttpPost]
        [Route("CreateSales")]
        public async Task<IActionResult> CreateSales(SalesDTO obj)
        {
            return Ok(await _salesService.CreateSales(obj));
        }

        [HttpGet]
        [Route("ItemWiseMonthlySalesReport")]
        public async Task<IActionResult> ItemWiseMonthlySalesReport(DateTime fromDate, DateTime toDate)
        {
            return Ok(await _salesService.ItemWiseMonthlySalesReport(fromDate, toDate));
        }

        [HttpGet]
        [Route("CustomerWiseMonthlySalesReport")]
        public async Task<IActionResult> CustomerWiseMonthlySalesReport(DateTime fromDate, DateTime toDate)
        {
            return Ok(await _salesService.CustomerWiseMonthlySalesReport(fromDate, toDate));
        }
    }
}
