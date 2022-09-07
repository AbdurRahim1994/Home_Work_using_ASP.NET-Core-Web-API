namespace Home_Work.DTO.Partner
{
    public class PartnerDTO
    {
        public long IntPartnerId { get; set; }
        public string StrPartnerName { get; set; } = null!;
        public long IntPartnerTypeId { get; set; }
        public bool IsActive { get; set; }
    }
    public class PartnerTypeDTO
    {
        public long IntPartnerTypeId { get; set; }
        public string StrPartnerTypeName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
