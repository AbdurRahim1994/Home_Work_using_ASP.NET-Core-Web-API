using Home_Work.DTO.Purchase;
using Home_Work.Helper;

namespace Home_Work.IRepository.Purchase
{
    public interface IPurchaseService
    {
        public Task<MessageHelper> CreatePurchase(PurchaseDTO obj);
        public Task<MessageHelper> MultiplePurchaseCreate(List<PurchaseDTO> obj);
        public Task<List<ItemWiseDailyPurchaseReportDTO>> ItemWiseDailyPurchaseReport(DateTime purchaseDate);
        public Task<List<SupplierWiseDailyPurchaseReportDTO>> SupplierWiseDailyPurchaseReport(DateTime purchaseDate);
        public Task<ItemWiseDailyPurchaseVsSalesReportDTO> ItemWiseDailyPurchaseVsSalesReport(DateTime date, long intItemId);
        public Task<MonthlyPurchaseVsSalesReportDTO> MonthlyPurchaseVsSalesReport();
        public Task<MonthlyPurchaseVsSalesReportDTO> SalesVsPurchase();
    }
}
