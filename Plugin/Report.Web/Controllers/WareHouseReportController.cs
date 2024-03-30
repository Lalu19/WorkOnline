using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Services.WareHouses.SalesOrders;
using CloudVOffice.Services.WareHouses.States;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Web.Controllers
{
    [Area(AreaNames.Report)]
    public class WareHouseReportController : BasePluginController
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly ISectorService _sectorService;
        private readonly IItemService _itemService;
        private readonly IStateService _stateService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategory1Service _subCategory1Service;
        private readonly ISubCategory2Service _subCategory2Service;
        private readonly IWareHouseService _wareHouseService;
        private readonly ISalesOrderParentService _salesOrderParentService;
        private readonly ISalesOrderItemService _salesOrderItemService;

        public WareHouseReportController(IWebHostEnvironment hostEnvironment, ISectorService sectorService, IItemService itemService, ICategoryService categoryService, ISubCategory1Service subCategory1Service, ISubCategory2Service subCategory2Service, IWareHouseService wareHouseService, IStateService stateService, ISalesOrderParentService salesOrderParentService, ISalesOrderItemService salesOrderItemService)
        {
            _hostEnvironment = hostEnvironment;
            _sectorService = sectorService;
            _itemService = itemService;
            _categoryService = categoryService;
            _subCategory1Service = subCategory1Service;
            _subCategory2Service = subCategory2Service;
            _wareHouseService = wareHouseService;
            _stateService = stateService;
            _salesOrderParentService = salesOrderParentService;
            _salesOrderItemService = salesOrderItemService;
        }

        [HttpGet]
        public IActionResult SellerTotalOrderReprot(DateTime? FromDate, DateTime? ToDate)
        {



            return View("~/Plugins/Report.Web/Views/SellerOrders/SellerTotalOrderReprot.cshtml");
        }








    }
}
