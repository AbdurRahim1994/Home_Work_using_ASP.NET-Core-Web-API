using Home_Work.DTO.Item;
using Home_Work.Helper;
using Home_Work.IRepository.Item;
using Home_Work.Models.Data;
using Home_Work.Models.Data.Entity;

namespace Home_Work.Repository
{
    public class ItemService:IItemService
    {
        private readonly HomeWorkDbContext _context;
        MessageHelper msg = new MessageHelper();
        public ItemService(HomeWorkDbContext _context)
        {
            this._context = _context;
        }

        public async Task<MessageHelper> CreateItem(List<ItemDTO> obj)
        {
            try
            {
                var isExist = (from i in _context.TblItems
                               where i.IsActive == true
                               && obj.Select(x => x.StrItemName).ToList().Contains(i.StrItemName)
                               select i.StrItemName).ToList();
                
                //var Exist = _context.TblItems.Where(x => x.IsActive == true && obj.Select(a => a.StrItemName).ToList().Contains(x.StrItemName)).ToList();
                if (isExist.Count() > 0)
                {
                    //throw new Exception($"{String.Join(", ", isExist)} - Already Exists");
                    msg.Message = $"Item Name : {String.Join(", ", isExist)} - Already Exists";
                }
                else
                {
                    List<TblItem> createItem = new List<TblItem>();
                    foreach (var item in obj)
                    {
                        var Exist = _context.TblItems.Where(x => x.IsActive == true && x.StrItemName == item.StrItemName).FirstOrDefault();
                        if (Exist == null)
                        {
                            TblItem data = new TblItem
                            {
                                StrItemName = item.StrItemName,
                                NumStockQuantity = item.NumStockQuantity,
                                IsActive = true
                            };
                            createItem.Add(data);
                        }
                        else
                        {
                            msg.Message = $"Item Name : {String.Join(", ", Exist)} - Already Exists";
                        }
                    }
                    await _context.TblItems.AddRangeAsync(createItem);
                    await _context.SaveChangesAsync();
                    msg.Message = "Created Successfully";
                    msg.StatusCode = 200; 
                }
                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
