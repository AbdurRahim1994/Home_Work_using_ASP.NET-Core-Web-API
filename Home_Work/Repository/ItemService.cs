using Home_Work.DTO.Item;
using Home_Work.Helper;
using Home_Work.IRepository.Item;
using Home_Work.Models.Data;
using Home_Work.Models.Data.Entity;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;

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
        public async Task<MessageHelper> CreateItemWithSQLJSON(List<ItemDTOWithSQLJSON> obj)
        {
            try
            {
                DataTable dt = new DataTable();
                using(SqlConnection con=new SqlConnection(Connection.Home_Work))
                {
                    string json=JsonSerializer.Serialize(obj);
                    string sql = "dbo.sprItem";
                    using(SqlCommand cmd=new SqlCommand(sql, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@jsonString", json);

                        con.Open();
                        using(SqlDataAdapter adapter =new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                        con.Close();
                    }
                    msg.Message = Convert.ToString(dt.Rows[0]["strMessage"]);
                    msg.StatusCode = Convert.ToUInt32(dt.Rows[0]["StatusCode"]);
                    return msg;
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<MessageHelper> EditItem(ItemDTO item)
        {
            try
            {
                TblItem? data=_context.TblItems.Where(x=>x.IntItemId==item.IntItemId).FirstOrDefault();
                if (data != null)
                {
                    data.StrItemName = item.StrItemName;
                    data.NumStockQuantity = item.NumStockQuantity;
                    data.IsActive = item.IsActive;

                    _context.TblItems.Update(data);
                    await _context.SaveChangesAsync();
                    msg.Message = "Edited Successfully";
                }
                else
                {
                    msg.Message = "Data not found";
                }
                return msg;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
