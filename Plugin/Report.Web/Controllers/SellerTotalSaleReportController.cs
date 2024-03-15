using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CloudVOffice.Services.WareHouses.States;

namespace Report.Web.Controllers
{
	public class SellerTotalSaleReportController : BasePluginController
	{
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly ISectorService _sectorService;
		private readonly IItemService _itemService;
		private readonly IStateService _stateService;
		private readonly ICategoryService _categoryService;
		private readonly ISubCategory1Service _subCategory1Service;
		private readonly ISubCategory2Service _subCategory2Service;
		private readonly IWareHouseService _wareHouseService;

		public SellerTotalSaleReportController(IWebHostEnvironment hostEnvironment, ISectorService sectorService, IItemService itemService, ICategoryService categoryService, ISubCategory1Service subCategory1Service, ISubCategory2Service subCategory2Service, IWareHouseService wareHouseService, IStateService stateService)
		{
			_hostEnvironment = hostEnvironment;
			_sectorService = sectorService;
			_itemService = itemService;
			_categoryService = categoryService;
			_subCategory1Service = subCategory1Service;
			_subCategory2Service = subCategory2Service;
			_wareHouseService = wareHouseService;
			_stateService = stateService;
		}
		[HttpGet]
		public IActionResult SellerTotalOrderReprot(Int64 StateId, DateTime? FromDate, DateTime? ToDate)
		{
			
			if(FromDate !=null && ToDate != null && StateId != null || StateId !=0)
			{
				
				
			}
			
			


			return View("~/Plugins/Report.Web/Views/SellerOrders/SellerTotalOrderReprot.cshtml");
		}

	}
}
