using Home_Work.DTO.Sales;
using Home_Work.Helper;
using Home_Work.IRepository.Sales;
using Home_Work.Models.Data;
using Home_Work.Models.Data.Entity;

namespace Home_Work.Repository.Sales
{
    public class SalesService:ISalesService
    {
        private readonly HomeWorkDbContext _context;
        MessageHelper msg = new MessageHelper();
        public SalesService(HomeWorkDbContext _context)
        {
            this._context = _context;
        }

        public async Task<MessageHelper> CreateSales(SalesDTO obj)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                TblSale sales = new TblSale();
                sales.IntCustomerId = obj.IntCustomerId;
                sales.DteSalesDate = DateTime.Now;
                sales.IsActive = true;

                await _context.TblSales.AddAsync(sales);
                await _context.SaveChangesAsync();

                List<TblSalesDetail> detail = new List<TblSalesDetail>();
                foreach (var item in obj.salesDetails)
                {
                    TblSalesDetail det = new TblSalesDetail();
                    det.IntSalesId = sales.IntSalesId;
                    det.IntItemId = item.IntItemId;
                    det.NumQuantity = item.NumQuantity;
                    det.NumUnitPrice = item.NumUnitPrice;
                    det.IsActive = true;

                    detail.Add(det);

                    var stock = _context.TblItems.Where(x => x.IntItemId == item.IntItemId && x.IsActive == true).Select(x => x.NumStockQuantity).FirstOrDefault();
                    if (stock < item.NumQuantity)
                    {
                        throw new Exception($"Insufficient Stock of {item.IntItemId}");
                    }
                    else
                    {
                        stock = stock - item.NumQuantity;

                        TblItem? itm = _context.TblItems.Where(x => x.IsActive == true && x.IntItemId == item.IntItemId).FirstOrDefault();
                        itm.NumStockQuantity = stock;
                        _context.TblItems.Update(itm);
                        await _context.SaveChangesAsync();
                    }  
                }
                await _context.TblSalesDetails.AddRangeAsync(detail);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                msg.Message = "Created Successfully";
                return msg;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}
