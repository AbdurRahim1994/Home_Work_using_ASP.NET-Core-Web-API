namespace Home_Work.DTO.Sales
{
    public class SalesOrderDTO
    {
    }
    public class SalesDTO
    {
        public long IntSalesId { get; set; }
        public long IntCustomerId { get; set; }
        public DateTime DteSalesDate { get; set; }
        public string? IsActive { get; set; }
        public List<SalesDetailsDTO> salesDetails { get; set; }
    }
    public class SalesDetailsDTO
    {
        public long IntSalesDetailsId { get; set; }
        public long IntSalesId { get; set; }
        public long IntItemId { get; set; }
        public decimal NumQuantity { get; set; }
        public decimal NumUnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
}
