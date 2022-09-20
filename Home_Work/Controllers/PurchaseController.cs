using Home_Work.DTO.Purchase;
using Home_Work.IRepository.Purchase;
using Home_Work.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Home_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        private readonly HomeWorkDbContext _context;
        public PurchaseController(IPurchaseService _purchaseService, HomeWorkDbContext _context)
        {
            this._purchaseService = _purchaseService;
            this._context = _context;
        }
        [HttpPost]
        [Route("CreatePurchase")]
        public async Task<IActionResult> CreatePurchase(PurchaseDTO obj)
        {
            var dt = await _purchaseService.CreatePurchase(obj);
            return Ok(dt);
        }
        [HttpPost]
        [Route("MultiplePurchaseCreate")]
        public async Task<IActionResult> MultiplePurchaseCreate(List<PurchaseDTO> obj)
        {
            var dt = await _purchaseService.MultiplePurchaseCreate(obj);
            return Ok(dt);
        }
        [HttpGet]
        [Route("ItemWiseDailyPurchaseReport")]
        public async Task<IActionResult> ItemWiseDailyPurchaseReport(DateTime purchaseDate)
        {
            return Ok(await _purchaseService.ItemWiseDailyPurchaseReport(purchaseDate));
        }

        [HttpGet]
        [Route("SupplierWiseDailyPurchaseReport")]
        public async Task<IActionResult> SupplierWiseDailyPurchaseReport(DateTime purchaseDate)
        {
            return Ok(await _purchaseService.SupplierWiseDailyPurchaseReport(purchaseDate));
        }

        [HttpGet]
        [Route("ItemWiseDailyPurchaseVsSalesReport")]
        public async Task<IActionResult> ItemWiseDailyPurchaseVsSalesReport(DateTime date, long intItemId)
        {
            return Ok(await _purchaseService.ItemWiseDailyPurchaseVsSalesReport(date,intItemId));
        }

        [HttpGet]
        [Route("MonthlyPurchaseVsSalesReport")]
        public async Task<IActionResult> MonthlyPurchaseVsSalesReport()
        {
            return Ok(await _purchaseService.MonthlyPurchaseVsSalesReport());
        }

        [HttpGet]
        [Route("SalesVsPurchase")]
        public async Task<IActionResult> SalesVsPurchase()
        {
            return Ok(await _purchaseService.SalesVsPurchase());
        }
    }
}
