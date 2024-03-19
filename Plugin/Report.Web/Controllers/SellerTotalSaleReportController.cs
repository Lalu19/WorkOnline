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
using CloudVOffice.Services.WareHouses.SalesOrders;
using Report.Web.ViewModel;
using CloudVOffice.Web.Framework;

namespace Report.Web.Controllers
{
	[Area(AreaNames.Report)]
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
		private readonly ISalesOrderParentService _salesOrderParentService;
		private readonly ISalesOrderItemService _salesOrderItemService;

		public SellerTotalSaleReportController(IWebHostEnvironment hostEnvironment, ISectorService sectorService, IItemService itemService, ICategoryService categoryService, ISubCategory1Service subCategory1Service, ISubCategory2Service subCategory2Service, IWareHouseService wareHouseService, IStateService stateService, ISalesOrderParentService salesOrderParentService, ISalesOrderItemService salesOrderItemService)
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
		public IActionResult SellerTotalSaleReprot(Int64 StateId, DateTime? FromDate, DateTime? ToDate)
		{
			
			if(FromDate !=null && ToDate != null && StateId != null || StateId !=0)
			{
				var SaleOrder = _salesOrderParentService.GetSaleOrderListByDateAndStateId(StateId, FromDate.Value, ToDate.Value);

				List<SellerTotalSaleModel> sellerTotalSaleModels = new List<SellerTotalSaleModel>();

				for(int i = 0; i < SaleOrder.Count; i++)
				{
					var datetime = SaleOrder[i].CreatedDate;
					var SaleorderParentId = SaleOrder[i].SalesOrderParentId;

					var WareHouseId = SaleOrder[i].WareHuoseId;
					var WareHouseDetails = _wareHouseService.GetWareHousebyWareHuoseId(WareHouseId);
					string WareHouseName = WareHouseDetails.WareHouseName;
			
					var SstateId = WareHouseDetails.StateId;
					var StateDetails = _stateService.GetStateById(SstateId);
					string StateName = StateDetails.StateName;

					var SaleOrderItems = _salesOrderItemService.GetSalesOrderItemByParentId(SaleorderParentId);
				
					var TotalAmount = 0.00;
					var Qty = 0.00;
					string ItemName = "";
					string brand = "";
					string SectorName = "";
					string CategoryName = "";
					string subcategoryName = "";
					string subcategoryDetailsName = "";


					for (int j = 0; j< SaleOrderItems.Count; j++)
					{
						var ItemId = SaleOrderItems[j].ItemId;
						 TotalAmount = SaleOrderItems[j].Amount;
						 Qty = SaleOrderItems[j].Quantity;

						var ItemDetails = _itemService.GetItemByItemId(ItemId);
						 ItemName = ItemDetails.ItemName;
						 brand = ItemDetails.BrandName;

						var SectorId = ItemDetails.SectorId;
						var SectorDetails = _sectorService.GetSectorById((int)SectorId);
						 SectorName = SectorDetails.SectorName;

						var Categoryid = ItemDetails.CategoryId;
						var CategoryDetails = _categoryService.GetCategoryById((int)Categoryid);
						 CategoryName = CategoryDetails.CategoryName;

						var SubcategoryId = ItemDetails.SubCategory1Id;
						var SubcategoryDetails = _subCategory1Service.GetSubCategory1ById((int)SubcategoryId);
						 subcategoryName = SubcategoryDetails.SubCategory1Name;

						var SubcategoryDetailsId = ItemDetails.SubCategory2Id;
						var SubcategoryDetailsD = _subCategory2Service.GetSubCategory2ById((int)SubcategoryDetailsId);
						 subcategoryDetailsName = SubcategoryDetails.SubCategory1Name;

						sellerTotalSaleModels.Add(new SellerTotalSaleModel
						{
							WareHuoseName = WareHouseName,
							SectorName = SectorName,
							StateName = StateName,
							DateTime = datetime.ToString("dd-MM-yyyy"),
							ItemName = ItemName,
							CategoryName = CategoryName,
							SubCategoryName = subcategoryName,
							subCategoryDetailsName = subcategoryDetailsName,
							TotalAmount = TotalAmount,
							Quantity = Qty,
							BrandName = brand,

						});
					}
					
				}
				ViewBag.SellerSaleReport = sellerTotalSaleModels;
			}
			ViewBag.StateList = _stateService.GetStateList();
			return View("~/Plugins/Report.Web/Views/SellerOrders/SellerTotalSaleReprot.cshtml");
		}

	}
}
