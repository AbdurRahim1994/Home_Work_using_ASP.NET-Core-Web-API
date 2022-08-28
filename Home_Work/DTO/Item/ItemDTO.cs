namespace Home_Work.DTO.Item
{
    public class ItemDTO
    {
        public long IntItemId { get; set; }
        public string StrItemName { get; set; } = null!;
        public decimal NumStockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
