using Home_Work.DTO.Partner;
using Home_Work.Helper;

namespace Home_Work.IRepository.Partner
{
    public interface IPartnerService
    {
        public Task<MessageHelper> CreatePartnerType(PartnerTypeDTO obj);
    }
}
