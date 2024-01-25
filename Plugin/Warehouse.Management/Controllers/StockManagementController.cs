using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.ViewModel;
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

        public StockManagementController(IItemService itemService, IStockService stockService)
        {
            _itemService = itemService;
            _stockService = stockService;
        }




        [HttpGet]
        public IActionResult LeftBar()
        {
            //ViewBag.POlist = _itemService.GetPurchaseOrderParentList();

            //SODTO sODTO = new SODTO();

            //if (SOId != null)
            //{

            //	SO d = _purchaseOrderParentService.GetPurchaseOrderParentList();

            //	SODTO.BrandName = d.BrandName;
            //	SODTO.BrandImage = d.BrandImage;
            //}
            return View("~/Plugins/Warehouse.Management/Views/StockManagement/StockManagement.cshtml");

        }

        public double TotalStockLeft()
        {
            var a = _stockService.TotalStock() ?? 0.0;
            return a;
        }

        public double TotalPrice()
        {
            var a = _stockService.TotalValue();
            return a;
        } 

        //public List<StockManagementSectorWise> SectorViewPage()
        //{

        //}

    }
}
