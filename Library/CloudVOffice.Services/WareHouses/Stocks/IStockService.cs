using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.ViewModel;
using CloudVOffice.Data.DTO.WareHouses.ViewModel.StockManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Stocks
{
    public interface IStockService
    {
        public MessageEnum StockCreate(StockDTO stockDTO);
        public Stock GetStockByStockId(Int64 stockId);
        public List<Stock> GetStockList();
        public MessageEnum StockUpdate(StockDTO stockDTO);
        public MessageEnum StockDelete(Int64 stockId, Int64 DeletedBy);
        public double? TotalStock();
        public double TotalValue();
        //public List<(string SectorName, double Quantity)> SectorViewPage();

        public List<StockManagementSectorWise> SectorViewPage();
        public List<StockManagementSkuWise> GetStockDetailsByBrandId(int brandId);
        public List<StockManagementSkuWise> GetStockDetailsByBrandIdsList(List<Int64> brandIdList);
        //public List<StockManagementCategoryWise> CategoryViewPage();

        public List<StockManagementCategoryWise> CategoryViewPage(List<Int64> categoryIds);
        public List<Stock> GetStockListBySectorId(Int64 sectorId);
        public List<StockManagementBrandWise> BrandsViewPage(List<Int64> brandIds);

        public Dictionary<string, double?> TotalStockByShortName();


        public Task<double?> CalculateOpeningStockAsync( Int64 itemId);
        public Task<double?> CalculateClosingStockAsync(Int64 itemId);
        


    }
}
