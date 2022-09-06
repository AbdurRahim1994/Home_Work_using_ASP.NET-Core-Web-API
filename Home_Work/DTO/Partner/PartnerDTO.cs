namespace Home_Work.DTO.Partner
{
    public class PartnerDTO
    {
    }
    public class PartnerTypeDTO
    {
        public long IntPartnerTypeId { get; set; }
        public string StrPartnerTypeName { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
