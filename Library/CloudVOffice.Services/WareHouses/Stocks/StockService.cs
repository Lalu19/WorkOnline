using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Stocks;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Stocks
{
    public class StockService : IStockService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<Stock> _stockRepo;

        public StockService(ApplicationDBContext dbContext, ISqlRepository<Stock> stockRepo)
        {
            _dbContext = dbContext;
            _stockRepo = stockRepo;
        }   

        public MessageEnum StockCreate(StockDTO stockDTO)
        {
            try
            {
                var stocks = _dbContext.Stocks.Where(x => x.StockId == stockDTO.StockId && x.Deleted == false).FirstOrDefault();
                if (stocks == null)
                {
                    Stock stock = new Stock();

                    stock.ItemId = stockDTO.ItemId;
                    stock.WareHuoseId= stockDTO.WareHuoseId;
                    stock.UnitId=stockDTO.UnitId;
                    stock.Quantity = stockDTO.Quantity;

                    stock.CreatedBy = stockDTO.CreatedBy;
                    var obj = _stockRepo.Insert(stock);

                    return MessageEnum.Success;
                }
                else
                {
                    return MessageEnum.Duplicate;
                }

            }
            catch
            {
                throw;
            }
        }
        public MessageEnum StockUpdate(StockDTO stockDTO)
        {
            try
            {
                //var stocks = _dbContext.Stocks.Where(x => x.StockId != stockDTO.StockId && x.Deleted == false).FirstOrDefault();
                //if (stocks == null)
                //{
                    var a = _dbContext.Stocks.Where(x => x.StockId == stockDTO.StockId).FirstOrDefault();
                    if (a != null)
                    {
                        a.ItemId = stockDTO.ItemId;
                        a.WareHuoseId = stockDTO.WareHuoseId;
                        a.UnitId = stockDTO.UnitId;
                        a.Quantity = stockDTO.Quantity;
                        
                        a.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();
                        return MessageEnum.Updated;
                    }
                    else
                        return MessageEnum.Invalid;
                //}
                //else
                //{
                //    return MessageEnum.Duplicate;
                //}

            }
            catch
            {
                throw;
            }
        }
        public Stock GetStockByStockId(Int64 stockId)
        {
            try
            {
                return _dbContext.Stocks.Where(x => x.StockId == stockId && x.Deleted == false).SingleOrDefault();

            }
            catch
            {
                throw;
            }
        }

        public List<Stock> GetStockList()
        {
            //try
            //{
            //    return _dbContext.Stocks.Where(x => x.Deleted == false).ToList();
            //}
            //catch
            //{
            //    throw;
            //}

            var a = _dbContext.Stocks
              .Include(s => s.Item)
              .Include(s => s.WareHuose)
              .Include(s => s.Unit)
              .Where(x => x.Deleted == false).ToList();

            return a;

        }
        public MessageEnum StockDelete(Int64 stockId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.Stocks.Where(x => x.StockId == stockId).FirstOrDefault();
                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    return MessageEnum.Deleted;
                }
                else
                    return MessageEnum.Invalid;
            }
            catch
            {
                throw;
            }
        }

    }
}
