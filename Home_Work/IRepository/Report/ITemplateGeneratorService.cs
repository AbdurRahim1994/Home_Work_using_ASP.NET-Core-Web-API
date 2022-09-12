using Home_Work.DTO.Item;
using Home_Work.DTO.Purchase;

namespace Home_Work.IRepository.Report
{
    public interface ITemplateGeneratorService
    {
        public Task<string> ItemListPdf(List<ItemDTO> obj);
        public Task<string> ItemWiseDailyPurchaseReportPdf(List<ItemWiseDailyPurchaseReportDTO> obj);
    }
}
