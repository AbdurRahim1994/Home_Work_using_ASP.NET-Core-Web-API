using Home_Work.DTO.Partner;
using Home_Work.IRepository.Partner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Home_Work.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerService _partnerService;
        public PartnerController(IPartnerService _partnerService)
        {
            this._partnerService = _partnerService;
        }
        [HttpPost]
        [Route("CreatePartnerType")]
        public async Task<IActionResult> CreatePartnerType(PartnerTypeDTO obj)
        {
            return Ok(await _partnerService.CreatePartnerType(obj));
        }
        [HttpPost]
        [Route("CreatePartner")]
        public async Task<IActionResult> CreatePartner(List<PartnerDTO> obj)
        {
            return Ok(await _partnerService.CreatePartner(obj));
        }
    }
}
