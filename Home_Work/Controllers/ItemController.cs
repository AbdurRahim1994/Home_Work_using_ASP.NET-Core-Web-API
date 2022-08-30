using Home_Work.DTO.Item;
using Home_Work.IRepository.Item;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Home_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService _itemService)
        {
            this._itemService = _itemService;
        }
        [HttpPost]
        [Route("CreateItem")]
        public async Task<IActionResult> CreateItem(List<ItemDTO> obj)
        {
            var dt = await _itemService.CreateItem(obj);
            return Ok(dt);
        }
        [HttpPost]
        [Route("CreateItemWithSQLJSON")]
        public async Task<IActionResult> CreateItemWithSQLJSON(List<ItemDTOWithSQLJSON> obj)
        {
            var dt = await _itemService.CreateItemWithSQLJSON(obj);
            return Ok(dt);
        }
        [HttpPost]
        [Route("EditItem")]
        public async Task<IActionResult> EditItem(ItemDTO item)
        {
            var dt = await _itemService.EditItem(item);
            return Ok(dt);
        }
    }
}
