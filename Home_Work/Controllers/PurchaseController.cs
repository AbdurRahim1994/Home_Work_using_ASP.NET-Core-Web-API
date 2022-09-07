using Home_Work.DTO.Purchase;
using Home_Work.IRepository.Purchase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Home_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        public PurchaseController(IPurchaseService _purchaseService)
        {
            this._purchaseService = _purchaseService;
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
    }
}
