using Home_Work.DTO.Item;
using Home_Work.Helper;

namespace Home_Work.IRepository.Item
{
    public interface IItemService
    {
        public Task<MessageHelper> CreateItem(List<ItemDTO> obj);
        public Task<MessageHelper> CreateItemWithSQLJSON(List<ItemDTOWithSQLJSON> obj);
        public Task<MessageHelper> EditItem(ItemDTO item);
    }
}
