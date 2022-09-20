using System.Collections.Generic;

namespace Home_Work.DTO.Purchase
{
    public class PurchaseOrderDTO
    {
    }
    public class PurchaseDTO
    {
        public long IntPurchaseId { get; set; }
        public long IntSupplierId { get; set; }
        public DateTime DtePurchaseDate { get; set; }
        public bool IsActive { get; set; }
        public List<PurchaseDetailsDTO> PurchaseDetails { get; set; }
    }
    public class PurchaseDetailsDTO
    {
        public long IntPurchaseDetailsId { get; set; }
        public long IntPurchaseId { get; set; }
        public long IntItemId { get; set; }
        public decimal NumQuantity { get; set; }
        public decimal NumUnitPrice { get; set; }
        public bool IsActive { get; set; }
    }
    public class ItemWiseDailyPurchaseReportDTO
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public string? PurchaseDate { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
    }
    public class SupplierWiseDailyPurchaseReportDTO
    {
        public long SupplierId { get; set; }
        public string SupplierName { get; set; }
        public long IntItemId { get; set; }
        public string StrItemName { get; set; }
        public string SuppliedDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public class ItemWiseDailyPurchaseVsSalesReportDTO
    {
        public decimal TotalPurchase { get; set; }
        public decimal TotalSales { get; set; }
    }
    public class MonthlyPurchaseVsSalesReportDTO 
    {
        public List<decimal> TotalPurchase { get; set; }
        public List<decimal> TotalSales { get; set; }
        public List<string> Date { get; set; }
    }

}
