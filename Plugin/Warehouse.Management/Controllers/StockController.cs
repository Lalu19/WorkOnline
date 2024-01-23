using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Stocks;
using CloudVOffice.Services.WareHouses;
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
        private readonly IItemService _itemService;
        private readonly IWareHouseService _wareHouseService;
        private readonly IUnit _unit;

        public StockController(IStockService stockService,
                               IItemService itemService,
                               IWareHouseService wareHouseService,
                               IUnit unit
                              )
        {
            _stockService = stockService;
            _itemService = itemService;
            _wareHouseService = wareHouseService;
            _unit = unit;
        }

        [HttpGet]
        public IActionResult StockCreate(int? stockId)
        {
            ViewBag.ItemList = _itemService.GetItemList();
            ViewBag.WareHouseList = _wareHouseService.GetWareHouseList();
            ViewBag.UnitList = _unit.GetUnit();

            StockDTO stockDTO = new StockDTO();

            if (stockId != null)
            {
                Stock d = _stockService.GetStockByStockId(int.Parse(stockId.ToString()));

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

        public IActionResult StockView()
        {
            ViewBag.Stocks = _stockService.GetStockList();

            return View("~/Plugins/Warehouse.Management/Views/Stocks/StockView.cshtml");
        }


        [HttpGet]
        public IActionResult DeleteStock(Int64 stockId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _stockService.StockDelete(stockId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/Stock/StockView");
        }

    }
}
