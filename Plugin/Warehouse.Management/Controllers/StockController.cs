using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.ViewModel;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Services.WareHouses.Stocks;
using CloudVOffice.Services.WareHouses.UOMs;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class StockController : BasePluginController
    {
        private readonly IStockService _stockService;
        private readonly ISectorService _sectorService;
        private readonly IItemService _itemService;
        private readonly IWareHouseService _wareHouseService;
        private readonly IUnit _unit;
        private readonly IBrandService _brandService;

        public StockController(IStockService stockService,
                               IItemService itemService,
                               IWareHouseService wareHouseService,
                               IUnit unit,
                               ISectorService sectorService,
                               IBrandService brandService
                              )
        {
            _stockService = stockService;
            _itemService = itemService;
            _wareHouseService = wareHouseService;
            _unit = unit;
            _sectorService = sectorService;
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult StockCreate(int? stockId)
        {
            ViewBag.ItemList = _itemService.GetItemList();
            ViewBag.WareHouseList = _wareHouseService.GetWareHouseList();
            ViewBag.UnitList = _unit.GetUnit();
            ViewBag.Sectors = _sectorService.GetSectorList();

            StockDTO stockDTO = new StockDTO();

            if (stockId != null)
            {
                Stock d = _stockService.GetStockByStockId(int.Parse(stockId.ToString()));

                stockDTO.SectorId = d.SectorId;
                stockDTO.CategoryId = d.CategoryId;
                stockDTO.BrandId = d.BrandId;
                stockDTO.ItemId = d.ItemId;
                stockDTO.WareHuoseId = d.WareHuoseId;
                stockDTO.UnitId = d.UnitId;
                stockDTO.Quantity = d.Quantity;

            }

            return View("~/Plugins/Warehouse.Management/Views/Stocks/StockCreate.cshtml", stockDTO);

        }


        [HttpPost]
        public IActionResult StockCreate(StockDTO stockDTO)
        {
            stockDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


            if (ModelState.IsValid)
            {
                if (stockDTO.StockId == null)
                {
                    var a = _stockService.StockCreate(stockDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/Stock/StockView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Stock Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _stockService.StockUpdate(stockDTO);

                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/Stock/StockView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Stock Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

			ViewBag.ItemList = _itemService.GetItemList();
			ViewBag.WareHouseList = _wareHouseService.GetWareHouseList();
			ViewBag.UnitList = _unit.GetUnit();

			return View("~/Plugins/Warehouse.Management/Views/Stocks/StockCreate.cshtml", stockDTO);
        }

        //public IActionResult StockView()
        //{

        //    ViewBag.Stocks = _stockService.GetStockList();

        //    return View("~/Plugins/Warehouse.Management/Views/Stocks/StockView.cshtml");
        //}


        [HttpGet]
        public IActionResult DeleteStock(Int64 stockId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _stockService.StockDelete(stockId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/Stock/StockView");
        }

        
        public List<Item> GetItemsByCategoryId(int categoryId)
        {
            var a = _itemService.ItemListByCategoryId(categoryId);
            return a;
        }

        public List<Brand> GetBrandsByCategoryId(int categoryId)
        {
            var brandsAll = _brandService.GetBrandListByCategoryId(categoryId);

            var brands = brandsAll.GroupBy(b => b.BrandId).Select(g => g.First()).ToList();
            return brands;
        }


        public List<StockManagementSkuWise> GetStockDetailsByBrandId(int brandId)
        {
            var items = _stockService.GetStockDetailsByBrandId(brandId);
            return items;
        }

        //[HttpGet]
        //public  ActionResult StockView(Int64 itemId)
        //{
        //    var items = itemId;
        //    var openingStock =  _stockService.CalculateOpeningStockAsync(itemId);
        //    var closingStock =  _stockService.CalculateClosingStockAsync(itemId);
        //    ViewBag.ItemList = _itemService.GetItemList();
        //    ViewBag.Stocks = _stockService.GetStockList();
        //    ViewBag.OpeningStock = openingStock;
        //    ViewBag.ClosingStock = closingStock;
        //    return View("~/Plugins/Warehouse.Management/Views/Stocks/StockView.cshtml");
        //}

       
        public async Task<ActionResult> StockView(Int64 itemId)
        {
            ViewBag.ItemList = _itemService.GetItemList();
            ViewBag.Stocks = _stockService.GetStockList();
            var openingStock = await _stockService.CalculateOpeningStockAsync(itemId);
            var closingStock = await _stockService.CalculateClosingStockAsync(itemId);
            if(closingStock == null)
            {
                closingStock = openingStock;
            }
            else
            {
                closingStock = closingStock;
            }

            ViewBag.OpeningStock = openingStock;
            ViewBag.ClosingStock = closingStock;


            return View("~/Plugins/Warehouse.Management/Views/Stocks/StockView.cshtml");
        }

      

    }
}
