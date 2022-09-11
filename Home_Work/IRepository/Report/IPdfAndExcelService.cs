using DinkToPdf;
using Home_Work.DTO.Item;

namespace Home_Work.IRepository.Report
{
    public interface IPdfAndExcelService
    {
        public Task<HtmlToPdfDocument> ItemListPdf(ItemDTO obj);
    }
}
