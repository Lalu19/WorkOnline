using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Data.DTO.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.ViewModel;
using CloudVOffice.Data.DTO.WareHouses.ViewModel.StockManagement;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.WareHouses.Stocks;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OfficeOpenXml.FormulaParsing.Excel.Functions;
using Warehouse.Management.ViewModel;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class StockManagementController : BasePluginController
    {

        private readonly IItemService _itemService;
        private readonly IStockService _stockService;
        private readonly ISectorService _sectorService;
        private readonly IBrandService _brandService;

        public StockManagementController(IItemService itemService, IStockService stockService, ISectorService sectorService, IBrandService brandService)
        {
            _itemService = itemService;
            _stockService = stockService;
            _sectorService = sectorService;
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult LeftBar()
        {
            ViewBag.Sectors = _sectorService.GetSectorList();
            return View("~/Plugins/Warehouse.Management/Views/StockManagement/StockManagement.cshtml");
        }

        //public double TotalStockLeft()
        //{
        //    var a = _stockService.TotalStockByShortName() ?? 0.0;
        //    return a;
        //}

        public Dictionary<string, double?> TotalStockLeft()
        {
            var totalStockByShortName = _stockService.TotalStockByShortName();

            // Process the dictionary based on your requirements
            //double totalQuantity = totalStockByShortName.Values.Sum() ?? 0.0;

            //return totalQuantity;

            return totalStockByShortName;
        }


        public double TotalPrice()
        {
            var a = _stockService.TotalValue();
            return a;
        }

        public List<StockManagementSectorWise> SectorViewPage()
        {
            var a = _stockService.SectorViewPage();
            return a;
        }


        [HttpPost]
        public List<StockManagementSkuWise> GetStockDetailsByBrandIdsList([FromBody] List<Int64> brandIds)
        {
            //var a = _stockService.GetStockDetailsByBrandIdsList(brandIds.BrandIds);
            var a = _stockService.GetStockDetailsByBrandIdsList(brandIds);
            return a;
        }

        [HttpPost]
        public List<StockManagementCategoryWise> CategoryViewPage([FromBody] List<Int64> categoryIds)
        {
            var a = _stockService.CategoryViewPage(categoryIds);
            return a;
        }


        //[HttpPost]
        //public List<StockManagementSkuWise> GetCategoryDetailsByBrandIdsList([FromBody] List<Int64> brandIds)
        //{
        //    //var a = _stockService.GetStockDetailsByBrandIdsList(brandIds.BrandIds);
        //    var a = _stockService.GetStockDetailsByBrandIdsList(brandIds);
        //    return a;
        //}

        [HttpGet]
        public List<Stock> GetBrandsInStockBySectorId(Int64 sectorId)
        {
            var a = _stockService.GetStockListBySectorId(sectorId);
            return a;
        }


        [HttpPost]
        public List<StockManagementBrandWise> BrandViewPage([FromBody] List<Int64> brandIds)
        {
            var a = _stockService.BrandsViewPage(brandIds);
            return a;
        }


    }
}
