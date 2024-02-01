using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.ViewModel;
using CloudVOffice.Data.DTO.WareHouses.ViewModel.StockManagement;
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

                    stock.SectorId = stockDTO.SectorId;
                    stock.BrandId = stockDTO.BrandId;
                    stock.CategoryId = stockDTO.CategoryId;
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
                        a.CategoryId = stockDTO.CategoryId;
                        a.BrandId = stockDTO.BrandId;
                        a.WareHuoseId = stockDTO.WareHuoseId;
                        a.UnitId = stockDTO.UnitId;
                        a.Quantity = stockDTO.Quantity;
                        a.SectorId = stockDTO.SectorId;
                        
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
              .Include(s => s.Category)
              .Include(s => s.Sector)
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

        public double? TotalStock()
        {
            var a = _dbContext.Stocks.Where(i => i.Deleted == false).ToList();
            double? totalQuantity = 0;

            foreach (var x in a)
            {
                totalQuantity = totalQuantity + x.Quantity;
            }
            return totalQuantity;
        }


        public Dictionary<string, double?> TotalStockByShortName()
        {
            var stocks = _dbContext.Stocks
                .Include(s => s.Item)
                .Where(i => i.Deleted == false)
                .ToList();

            Dictionary<string, double?> totalStockByShortName = new Dictionary<string, double?>();

            foreach (var stock in stocks)
            {
                var shortName = stock.Item?.ShortName;
                if (!string.IsNullOrEmpty(shortName))
                {
                    if (totalStockByShortName.ContainsKey(shortName))
                    {
                        totalStockByShortName[shortName] += stock.Quantity;
                    }
                    else
                    {
                        totalStockByShortName[shortName] = stock.Quantity;
                    }
                }
            }

            return totalStockByShortName;
        }


        public double TotalValue()
        {
            try
            {
                var stocks = _dbContext.Stocks.Where(i => !i.Deleted).ToList();
                double TotalAmount = 0.0;

                foreach (var stock in stocks)
                {
                    var quantity = (double)stock.Quantity;  // Convert quantity to double

                    var mrp = _dbContext.Items
                        .Where(q => q.ItemId == stock.ItemId && !q.Deleted)
                        .Select(z => z.MRP)
                        .FirstOrDefault();


                    if (mrp != null)
                    {
                        var product = quantity * mrp;
                        TotalAmount += product;
                    }
                }

                return TotalAmount;
            }
            catch
            {
                throw;
            }
        }



        public List<StockManagementSectorWise> SectorViewPage1()
        {
            var stocks = _dbContext.Stocks
                .Where(s => s.Deleted == false)
                .ToList();

            Dictionary<(int SectorId, int ItemId), StockManagementSectorWise> sectorData =
                new Dictionary<(int, int), StockManagementSectorWise>();

            foreach (var stock in stocks)
            {
                if (stock.SectorId.HasValue && stock.ItemId.HasValue)
                {
                    (int SectorId, int ItemId) key = (stock.SectorId.Value, (int)stock.ItemId.Value);

                    if (sectorData.ContainsKey(key))
                    {
                        // Accumulate quantity and amount for the same SectorId and ItemId
                        sectorData[key].Quantity.Add(stock.Quantity ?? 0);
                        sectorData[key].Amount.Add(stock.Quantity ?? 0);
                    }
                    else
                    {
                        // Add a new entry for the SectorId and ItemId
                        var sectorName = _dbContext.Sectors
                            .Where(s => s.SectorId == stock.SectorId)
                            .Select(s => s.SectorName)
                            .FirstOrDefault();

                        var shortName = _dbContext.Items
                            .Where(i => i.ItemId == stock.ItemId)
                            .Select(i => i.ShortName)
                            .FirstOrDefault();

                        var mrp = _dbContext.Items
                            .Where(i => i.ItemId == stock.ItemId)
                            .Select(i => i.MRP)
                            .FirstOrDefault();


                        var newSectorData = new StockManagementSectorWise
                        {
                            Sectors = sectorName,
                            Quantity = new List<double> { stock.Quantity ?? 0 },
                            Amount = new List<double> { (stock.Quantity ?? 0) * mrp },
                            ShortName = new List<string> { shortName }
                        };
                        sectorData[key] = newSectorData;
                    }
                }
            }

            // Create a list of StockManagementSectorWise
            List<StockManagementSectorWise> result = sectorData.Values.ToList();

            return result;
        }


        //public List<StockManagementSectorWise> SectorViewPage1()
        //{
        //    var stocks = _dbContext.Stocks
        //        .Where(s => s.Deleted == false)
        //        .ToList();

        //    Dictionary<(int SectorId, int ItemId), StockManagementSectorWise> sectorData =
        //        new Dictionary<(int, int), StockManagementSectorWise>();

        //    foreach (var stock in stocks)
        //    {
        //        if (stock.SectorId.HasValue && stock.ItemId.HasValue)
        //        {
        //            (int SectorId, int ItemId) key = (stock.SectorId.Value, (int)stock.ItemId.Value);

        //            if (sectorData.ContainsKey(key))
        //            {
        //                // Accumulate quantity and amount for the same SectorId and ItemId
        //                sectorData[key].Quantity.Add(stock.Quantity ?? 0);
        //                sectorData[key].Amount.Add(stock.Quantity ?? 0);
        //            }
        //            else
        //            {
        //                // Add a new entry for the SectorId and ItemId
        //                var sectorName = _dbContext.Sectors
        //                    .Where(s => s.SectorId == stock.SectorId)
        //                    .Select(s => s.SectorName)
        //                    .FirstOrDefault();

        //                var shortName = _dbContext.Items
        //                    .Where(i => i.ItemId == stock.ItemId)
        //                    .Select(i => i.ShortName)
        //                    .FirstOrDefault();

        //                var mrp = _dbContext.Items
        //                    .Where(i => i.ItemId == stock.ItemId)
        //                    .Select(i => i.MRP)
        //                    .FirstOrDefault();


        //                (string secName, string srtName) key = (sectorName, shortName);

        //                if (sectorData.ContainsKey(key))
        //                {
        //                    // Accumulate quantity and amount for the same SectorId and ShortName
        //                    sectorData[key].Quantity[0] += stock.Quantity ?? 0;
        //                    sectorData[key].Amount[0] += (stock.Quantity ?? 0) * stock.MRP ?? 0;
        //                }






        //                var newSectorData = new StockManagementSectorWise
        //                {
        //                    Sectors = sectorName,
        //                    Quantity = new List<double> { stock.Quantity ?? 0 },
        //                    Amount = new List<double> { (stock.Quantity ?? 0) * mrp },
        //                    ShortName = new List<string> { shortName }
        //                };
        //                sectorData[key] = newSectorData;
        //            }
        //        }
        //    }

        //    // Create a list of StockManagementSectorWise
        //    List<StockManagementSectorWise> result = sectorData.Values.ToList();

        //    return result;
        //}


        public List<StockManagementSectorWise> SectorViewPage2()
        {
            var stocks = _dbContext.Stocks
                .Where(s => s.Deleted == false)
                .ToList();

            Dictionary<(string SectorName, string ShortName), StockManagementSectorWise> sectorData =
                new Dictionary<(string, string), StockManagementSectorWise>();

            foreach (var stock in stocks)
            {
                if (stock.SectorId.HasValue && stock.ItemId.HasValue)
                {
                    var sectorName = _dbContext.Sectors
                        .Where(s => s.SectorId == stock.SectorId)
                        .Select(s => s.SectorName)
                        .FirstOrDefault();

                    var shortName = _dbContext.Items
                        .Where(i => i.ItemId == stock.ItemId)
                        .Select(i => i.ShortName)
                        .FirstOrDefault();

                    var mrp = _dbContext.Items
                        .Where(i => i.ItemId == stock.ItemId)
                        .Select(i => i.MRP)
                        .FirstOrDefault();

                    (string SectorName, string ShortName) key = (sectorName, shortName);

                    if (sectorData.ContainsKey(key))
                    {
                        sectorData[key].Quantity[0] += stock.Quantity ?? 0;
                        sectorData[key].Amount[0] += (stock.Quantity ?? 0) * mrp;
                    }
                    else if (sectorData.Keys.Any(k => k.SectorName == sectorName))
                    {
                        var existingKey = sectorData.Keys.First(k => k.SectorName == sectorName);

                        sectorData[existingKey].Quantity.Add(stock.Quantity ?? 0);
                        sectorData[existingKey].Amount.Add((stock.Quantity ?? 0) * mrp);
                        sectorData[existingKey].ShortName.Add(shortName);
                    }
                    else
                    {
                        var newSectorData = new StockManagementSectorWise
                        {
                            Sectors = sectorName,
                            Quantity = new List<double> { stock.Quantity ?? 0 },
                            Amount = new List<double> { (stock.Quantity ?? 0) * mrp },
                            ShortName = new List<string> { shortName }
                        };
                        sectorData[key] = newSectorData;
                    }
                }
            }

            List<StockManagementSectorWise> result = sectorData.Values.ToList();

            return result;
        }

        public List<StockManagementSectorWise> SectorViewPage()
        {
            var stocks = _dbContext.Stocks
                .Where(s => s.Deleted == false)
                .ToList();

            List<StockManagementSectorWise> sectorDataList = new List<StockManagementSectorWise>();

            foreach (var stock in stocks)
            {
                if (stock.SectorId.HasValue && stock.ItemId.HasValue)
                {
                    var sectorName = _dbContext.Sectors
                        .Where(s => s.SectorId == stock.SectorId)
                        .Select(s => s.SectorName)
                        .FirstOrDefault();

                    var shortName = _dbContext.Items
                        .Where(i => i.ItemId == stock.ItemId)
                        .Select(i => i.ShortName)
                        .FirstOrDefault();

                    var mrp = _dbContext.Items
                        .Where(i => i.ItemId == stock.ItemId)
                        .Select(i => i.MRP)
                        .FirstOrDefault();

                    var existingSectorData = sectorDataList.FirstOrDefault(s => s.Sectors == sectorName);

                    if (existingSectorData != null)
                    {
                        var existingPair = existingSectorData.ShortName.FindIndex(s => s == shortName);

                        if (existingPair != -1)
                        {
                            existingSectorData.Quantity[existingPair] += stock.Quantity ?? 0;
                            existingSectorData.Amount[existingPair] += (stock.Quantity ?? 0) * mrp;
                        }
                        else
                        {
                            existingSectorData.ShortName.Add(shortName);
                            existingSectorData.Quantity.Add(stock.Quantity ?? 0);
                            existingSectorData.Amount.Add((stock.Quantity ?? 0) * mrp);
                        }
                    }
                    else
                    {
                        // If the Sector name is new, create a new entry
                        var newSectorData = new StockManagementSectorWise
                        {
                            Sectors = sectorName,
                            Quantity = new List<double> { stock.Quantity ?? 0 },
                            Amount = new List<double> { (stock.Quantity ?? 0) * mrp },
                            ShortName = new List<string> { shortName }
                        };
                        sectorDataList.Add(newSectorData);
                    }
                }
            }

            return sectorDataList;
        }


        public List<StockManagementSkuWise> GetStockDetailsByBrandId(int brandId)
        {

            List<StockManagementSkuWise> list = new List<StockManagementSkuWise>();

            var stocks = _dbContext.Stocks
                .Include(s=> s.Item)
                .Where(s => s.BrandId ==  brandId && s.Deleted == false).ToList();


            foreach (var stock in stocks)
            {
                StockManagementSkuWise obj = new StockManagementSkuWise();

                obj.ProductName = stock.Item.ItemName;
                obj.ShortName = stock.Item.ShortName;
                obj.UnitPerCase = stock.Item.UnitPerCase;
                obj.StockLeft = stock.Quantity;
                obj.GST = stock.Item.CGST;
                obj.ManufacturingDate = stock.Item.ManufactureDate;
                obj.ExpiryDate = stock.Item.ExpiryDate;
                obj.DaysLeft = (stock.Item.ExpiryDate.Value - DateTime.Now).Days;

                list.Add(obj);
            }

            return list;
        }

        public List<StockManagementSkuWise> GetStockDetailsByBrandIdsList (List<Int64> brandIdList)
        {

            List<StockManagementSkuWise> list = new List<StockManagementSkuWise>();

            foreach (var brand in brandIdList)
            {
                var stocks = _dbContext.Stocks
                .Include(s => s.Item)
                .Where(s => s.BrandId == brand && s.Deleted == false).ToList();


                foreach (var stock in stocks)
                {
                    StockManagementSkuWise obj = new StockManagementSkuWise();

                    obj.ProductName = stock.Item.ItemName;
                    obj.ShortName = stock.Item.ShortName;
                    obj.UnitPerCase = stock.Item.UnitPerCase;
                    obj.StockLeft = stock.Quantity;
                    obj.GST = stock.Item.CGST;
                    obj.ManufacturingDate = stock.Item.ManufactureDate;
                    obj.ExpiryDate = stock.Item.ExpiryDate;
                    obj.DaysLeft = (stock.Item.ExpiryDate.Value - DateTime.Now).Days;

                    list.Add(obj);
                }

            }

            return list;
        }

        public List<StockManagementCategoryWise> CategoryViewPage(List<Int64> categoryIds)
        {
            List<StockManagementCategoryWise> categoryDataList = new List<StockManagementCategoryWise>();

            foreach (var category in categoryIds)
            {

                var stocks = _dbContext.Stocks
                .Include(s => s.Item)
                .Include(s => s.Category)
                .Include(s => s.Sector)
                .Where(s => s.CategoryId == category && s.Deleted == false)
                .ToList();

                //List<StockManagementCategoryWise> categoryDataList = new List<StockManagementCategoryWise>();

                foreach (var stock in stocks)
                {
                    if (stock.CategoryId.HasValue && stock.ItemId.HasValue)
                    {
                        //var sectorName = _dbContext.Sectors
                        //    .Where(s => s.SectorId == stock.SectorId)
                        //    .Select(s => s.SectorName)
                        //    .FirstOrDefault();

                        //var shortName = _dbContext.Items
                        //    .Where(i => i.ItemId == stock.ItemId)
                        //    .Select(i => i.ShortName)
                        //    .FirstOrDefault();

                        //var mrp = _dbContext.Items
                        //    .Where(i => i.ItemId == stock.ItemId)
                        //    .Select(i => i.MRP)
                        //    .FirstOrDefault();

                        var categoryName = stock.Category.CategoryName;
                        var shortName = stock.Item.ShortName;
                        var mrp = stock.Item.MRP;

                        var existingSectorData = categoryDataList.FirstOrDefault(s => s.Categories == categoryName);

                        if (existingSectorData != null)
                        {
                            var existingPair = existingSectorData.ShortName.FindIndex(s => s == shortName);

                            if (existingPair != -1)
                            {
                                existingSectorData.Quantity[existingPair] += stock.Quantity ?? 0;
                                existingSectorData.Amount[existingPair] += (stock.Quantity ?? 0) * mrp;
                            }
                            else
                            {
                                existingSectorData.ShortName.Add(shortName);
                                existingSectorData.Quantity.Add(stock.Quantity ?? 0);
                                existingSectorData.Amount.Add((stock.Quantity ?? 0) * mrp);
                            }
                        }
                        else
                        {
                            // If the Sector name is new, create a new entry
                            var newSectorData = new StockManagementCategoryWise
                            {
                                Categories = categoryName,
                                Quantity = new List<double> { stock.Quantity ?? 0 },
                                Amount = new List<double> { (stock.Quantity ?? 0) * mrp },
                                ShortName = new List<string> { shortName }
                            };
                            categoryDataList.Add(newSectorData);
                        }
                    }
                }
            }
            return categoryDataList;
        }


        public List<Stock> GetStockListBySectorId(Int64 sectorId)
        {
            var stocks = _dbContext.Stocks.Where(s => s.SectorId == sectorId && s.Deleted == false && s.BrandId != null).ToList();
            return stocks;
        }

        public List<StockManagementBrandWise> BrandsViewPage(List<Int64> brandIds)
        {
            List<StockManagementBrandWise> brandDataList = new List<StockManagementBrandWise>();

            foreach (var brandId in brandIds)
            {
                var stocks = _dbContext.Stocks
                .Include(s => s.Item)
                .Include(s => s.Category)
                .Include(s => s.Sector)
                .Where(s => s.BrandId == brandId && s.Deleted == false)
                .ToList();

                //List<StockManagementCategoryWise> categoryDataList = new List<StockManagementCategoryWise>();

                foreach (var stock in stocks)
                {
                    if (stock.CategoryId.HasValue && stock.ItemId.HasValue)
                    {
                        //var brandName = stock.Category.CategoryName;

                        var brandName = _dbContext.Items.Where(i => i.BrandId == stock.BrandId).Select(s=> s.BrandName).FirstOrDefault();
                        var shortName = stock.Item.ShortName;
                        var mrp = stock.Item.MRP;

                        var existingSectorData = brandDataList.FirstOrDefault(s => s.Brands == brandName);

                        if (existingSectorData != null)
                        {
                            var existingPair = existingSectorData.ShortName.FindIndex(s => s == shortName);

                            if (existingPair != -1)
                            {
                                existingSectorData.Quantity[existingPair] += stock.Quantity ?? 0;
                                existingSectorData.Amount[existingPair] += (stock.Quantity ?? 0) * mrp;
                            }
                            else
                            {
                                existingSectorData.ShortName.Add(shortName);
                                existingSectorData.Quantity.Add(stock.Quantity ?? 0);
                                existingSectorData.Amount.Add((stock.Quantity ?? 0) * mrp);
                            }
                        }
                        else
                        {
                            // If the Sector name is new, create a new entry
                            var newSectorData = new StockManagementBrandWise
                            {
                                Brands = brandName,
                                Quantity = new List<double> { stock.Quantity ?? 0 },
                                Amount = new List<double> { (stock.Quantity ?? 0) * mrp },
                                ShortName = new List<string> { shortName }
                            };
                            brandDataList.Add(newSectorData);
                        }
                    }
                }
            }
            return brandDataList;
        }

    }
}
