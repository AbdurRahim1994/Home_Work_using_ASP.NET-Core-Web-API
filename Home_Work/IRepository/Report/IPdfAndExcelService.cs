using DinkToPdf;
using Home_Work.DTO.Item;
using Home_Work.DTO.Purchase;

namespace Home_Work.IRepository.Report
{
    public interface IPdfAndExcelService
    {
        public Task<HtmlToPdfDocument> ItemListPdf(List<ItemDTO> obj);
        public Task<HtmlToPdfDocument> ItemWiseDailyPurchaseReportPdf(List<ItemWiseDailyPurchaseReportDTO> obj);
    }
}
