namespace Home_Work.DTO.Report
{
    public class GetItemListDTO
    {
        public long IntItemId { get; set; }
        public string StrItemName { get; set; } = null!;
        public decimal NumStockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
