using Home_Work.DTO.Sales;
using Home_Work.Helper;

namespace Home_Work.IRepository.Sales
{
    public interface ISalesService
    {
        public Task<MessageHelper> CreateSales(SalesDTO obj);
        public Task<List<ItemWiseMonthlySalesReportDTO>> ItemWiseMonthlySalesReport(DateTime fromDate, DateTime toDate);
        public Task<List<CustomerWiseMonthlySalesReportDTO>> CustomerWiseMonthlySalesReport(DateTime fromDate, DateTime toDate);
    }
}
