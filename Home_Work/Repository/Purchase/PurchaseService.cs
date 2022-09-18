﻿using Home_Work.DTO.Purchase;
using Home_Work.Helper;
using Home_Work.IRepository.Purchase;
using Home_Work.Models.Data;
using Home_Work.Models.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace Home_Work.Repository.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        private readonly HomeWorkDbContext _context;
        MessageHelper msg = new MessageHelper();
        public PurchaseService(HomeWorkDbContext _context)
        {
            this._context = _context;
        }
        public async Task<MessageHelper> CreatePurchase(PurchaseDTO obj)
        {
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                TblPurchase pur = new TblPurchase
                {
                    IntSupplierId = obj.IntSupplierId,
                    DtePurchaseDate = obj.DtePurchaseDate,
                    IsActive = true
                };
                await _context.TblPurchases.AddAsync(pur);
                await _context.SaveChangesAsync();

                List<TblPurchaseDetail> det = new List<TblPurchaseDetail>();
                foreach (var item in obj.PurchaseDetails)
                {
                    TblPurchaseDetail details = new TblPurchaseDetail
                    {
                        IntPurchaseId = pur.IntPurchaseId,
                        IntItemId = item.IntItemId,
                        NumQuantity = item.NumQuantity,
                        NumUnitPrice = item.NumUnitPrice,
                        IsActive = true
                    };
                    det.Add(details);

                    var stock = _context.TblItems.Where(x => x.IntItemId == item.IntItemId && x.IsActive == true).Select(x => x.NumStockQuantity).FirstOrDefault();
                    stock = stock + item.NumQuantity;
                    
                    TblItem? itm =_context.TblItems.Where(x=>x.IsActive==true && x.IntItemId==item.IntItemId).FirstOrDefault();
                    itm.NumStockQuantity = stock;
                    
                    _context.TblItems.Update(itm);
                    await _context.SaveChangesAsync();
                }
                await _context.TblPurchaseDetails.AddRangeAsync(det);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                msg.Message = "Created Successfully";
                return msg;
            }
            catch (Exception ex)
            {

                await transaction.RollbackAsync();
                throw ex;
            }
        }

        public async Task<MessageHelper> MultiplePurchaseCreate(List<PurchaseDTO> obj)
        {
            try
            {
                foreach (var item in obj)
                {
                    TblPurchase purchase = new TblPurchase
                    {
                        IntSupplierId = item.IntSupplierId,
                        DtePurchaseDate = DateTime.Now,
                        IsActive = true
                    };
                    await _context.TblPurchases.AddAsync(purchase);
                    await _context.SaveChangesAsync();

                    List<TblPurchaseDetail> detail = new List<TblPurchaseDetail>();
                    foreach (var data in item.PurchaseDetails)
                    {
                        TblPurchaseDetail det = new TblPurchaseDetail
                        {
                            IntItemId = data.IntItemId,
                            IntPurchaseId = purchase.IntPurchaseId,
                            NumQuantity = data.NumQuantity,
                            NumUnitPrice = data.NumUnitPrice,
                            IsActive = true
                        };
                        detail.Add(det);

                        //var stock = _context.TblItems.Where(x => x.IsActive == true && x.IntItemId == data.IntItemId).Select(x => x.NumStockQuantity).FirstOrDefault();
                        //stock = stock - data.NumQuantity;
                        
                        TblItem? itm = _context.TblItems.Where(x => x.IsActive == true && x.IntItemId == data.IntItemId).FirstOrDefault();
                        itm.NumStockQuantity = itm.NumStockQuantity + data.NumQuantity;
                        _context.TblItems.Update(itm);
                        await _context.SaveChangesAsync();
                    }
                    await _context.TblPurchaseDetails.AddRangeAsync(detail);
                    await _context.SaveChangesAsync();
                }
                msg.Message = "Created Successfully";
                return msg;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<List<ItemWiseDailyPurchaseReportDTO>> ItemWiseDailyPurchaseReport(DateTime purchaseDate)
        {
            try
            {
                var data =await (from itm in _context.TblItems
                                  join pur in _context.TblPurchaseDetails on itm.IntItemId equals pur.IntItemId
                                  join purd in _context.TblPurchases on pur.IntPurchaseId equals purd.IntPurchaseId
                                  where itm.IsActive == true
                                  && pur.IsActive == true
                                  && purd.DtePurchaseDate.Value.Date == purchaseDate.Date
                                  select new
                                  {
                                      itm.IntItemId,
                                      itm.StrItemName,
                                      pur.NumQuantity,
                                      purchaseDate = purd.DtePurchaseDate.Value.Date,
                                      pur.NumUnitPrice
                                  }).GroupBy(x => new
                                  {
                                      x.IntItemId,
                                      x.StrItemName,
                                      x.purchaseDate,
                                      x.NumUnitPrice
                                  }).Select(a => new ItemWiseDailyPurchaseReportDTO
                                  {
                                      ItemId = a.Key.IntItemId,
                                      ItemName = a.Key.StrItemName,
                                      PurchaseDate = a.Key.purchaseDate.ToString("dd MMM yyyy"),
                                      Quantity = a.Sum(x => x.NumQuantity),
                                      UnitPrice = a.Sum(x=>x.NumUnitPrice)
                                  }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<List<SupplierWiseDailyPurchaseReportDTO>> SupplierWiseDailyPurchaseReport(DateTime purchaseDate)
        {
            try
            {
                var data = await (from p in _context.TblPurchases
                                  join pd in _context.TblPurchaseDetails on p.IntPurchaseId equals pd.IntPurchaseId
                                  join prt in _context.TblPartners on p.IntSupplierId equals prt.IntPartnerId
                                  join i in _context.TblItems on pd.IntItemId equals i.IntItemId
                                  where p.DtePurchaseDate.Value.Date == purchaseDate.Date
                                  select new
                                  {
                                      i.IntItemId,
                                      i.StrItemName,
                                      p.IntSupplierId,
                                      prt.StrPartnerName,
                                      pd.NumQuantity,
                                      pd.NumUnitPrice,
                                      purchaseDate = p.DtePurchaseDate.Value.Date
                                  }).GroupBy(x => new
                                  {
                                      x.IntSupplierId,
                                      x.StrPartnerName,
                                      x.IntItemId,
                                      x.StrItemName,
                                      x.NumUnitPrice,
                                      x.purchaseDate
                                  }).Select(x => new SupplierWiseDailyPurchaseReportDTO
                                  {
                                      IntItemId = x.Key.IntItemId,
                                      StrItemName = x.Key.StrItemName,
                                      SupplierId = x.Key.IntSupplierId,
                                      SupplierName = x.Key.StrPartnerName,
                                      Quantity = x.Sum(x => x.NumQuantity),
                                      UnitPrice = x.Key.NumUnitPrice,
                                      SuppliedDate = x.Key.purchaseDate.ToString("dd MMM yyyy")
                                  }).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
