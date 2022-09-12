using Home_Work.DTO.Item;

namespace Home_Work.IRepository.Report
{
    public interface ITemplateGeneratorService
    {
        public Task<string> ItemListPdf(List<ItemDTO> obj);
    }
}
