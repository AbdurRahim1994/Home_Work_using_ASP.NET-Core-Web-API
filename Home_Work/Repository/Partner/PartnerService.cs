using Home_Work.DTO.Partner;
using Home_Work.Helper;
using Home_Work.IRepository.Partner;
using Home_Work.Models.Data;
using Home_Work.Models.Data.Entity;

namespace Home_Work.Repository.Partner
{
    public class PartnerService:IPartnerService
    {
        private readonly HomeWorkDbContext _context;
        MessageHelper msg = new MessageHelper();
        public PartnerService(HomeWorkDbContext _context)
        {
            this._context = _context;
        }

        public async Task<MessageHelper> CreatePartnerType(PartnerTypeDTO obj)
        {
            try
            {
                var isExist = _context.TblPartnerTypes.Where(x => x.StrPartnerTypeName == obj.StrPartnerTypeName && x.IsActive == true).FirstOrDefault();
                if(isExist != null)
                {
                    throw new Exception($"Partner Type {isExist.StrPartnerTypeName} Already Exists ");
                }
                else
                {
                    TblPartnerType partner = new TblPartnerType();
                    partner.StrPartnerTypeName = obj.StrPartnerTypeName;
                    partner.IsActive = true;

                    await _context.TblPartnerTypes.AddAsync(partner);
                    await _context.SaveChangesAsync();

                    msg.Message = "Created Successfully";
                    msg.StatusCode = 200;
                }
                return msg;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
