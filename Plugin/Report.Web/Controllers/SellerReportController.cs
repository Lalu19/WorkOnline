using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Report.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Report.Web.Controllers
{
	[Area(AreaNames.Report)]
	public class SellerReportController : BasePluginController
	{
		private readonly IWebHostEnvironment _hostEnvironment;
		private readonly ISectorService _sectorService;
		private readonly IItemService _itemService;
		private readonly IPurchaseOrderService _purchaseOrderService;
		private readonly IPurchaseOrderParentService _purchaseOrderParentService;
		private readonly ICategoryService _categoryService;
		private readonly ISubCategory1Service _subCategory1Service;
		private readonly ISubCategory2Service _subCategory2Service;
		private readonly IWareHouseService _wareHouseService;

		public SellerReportController(IWebHostEnvironment hostEnvironment, ISectorService sectorService, IItemService itemService, IPurchaseOrderService purchaseOrderService, IPurchaseOrderParentService purchaseOrderParentService, ICategoryService categoryService, ISubCategory1Service subCategory1Service, ISubCategory2Service subCategory2Service, IWareHouseService wareHouseService)
		{
			_hostEnvironment = hostEnvironment;
			_sectorService = sectorService;
			_itemService = itemService;
			_purchaseOrderService = purchaseOrderService;
			_purchaseOrderParentService = purchaseOrderParentService;
			_categoryService = categoryService;	
			_subCategory1Service = subCategory1Service;
			_subCategory2Service = subCategory2Service;
			_wareHouseService = wareHouseService;
		}
		[HttpGet]
		public IActionResult SellerTotalOrderReprot(DateTime? FromDate, DateTime? ToDate)
		{
			
			if(FromDate !=null && ToDate != null)
			{
				var PurchaseParentOrder = _purchaseOrderParentService.GetPurchaseOrderParentsByDate(FromDate.Value, ToDate.Value);

				List<SellerOrderModel> sellerOrderModels = new List<SellerOrderModel>();

				for (int i = 0; i < PurchaseParentOrder.Count; i++)
				{
					DateTime orderdate = PurchaseParentOrder[i].CreatedDate;
					string invoicenumber = PurchaseParentOrder[i].POPUniqueNumber;
					var purchaseorderId = PurchaseParentOrder[i].PurchaseOrderParentId;
					var sellerId = PurchaseParentOrder[i].SellerRegistrationId;
					var getpurchaseorderby = _purchaseOrderService.GetPurchaseOrderByPurchaseOrderParentId(purchaseorderId);

					for (int j = 0; j < getpurchaseorderby.Count; j++)
					{
						Int64 ItemId = (long)getpurchaseorderby[j].ItemId;
						var amount = getpurchaseorderby[j].Value;
						var qty = getpurchaseorderby[j].Quantity;

						var getItemdetailsbypurchaseorder = _itemService.GetItemBytailsByPurchaseOrder(ItemId);
						string Itemname = getItemdetailsbypurchaseorder.ItemName;

						var sectorid = getItemdetailsbypurchaseorder.SectorId;
						var sectordetailsbyId = _sectorService.GetSectorById((int)sectorid);
						string sectorname = sectordetailsbyId.SectorName;

						var categoryid = getItemdetailsbypurchaseorder.CategoryId;
						var CategoryDetailsbyid = _categoryService.GetCategoryById((int)categoryid);
						string CategoryName = CategoryDetailsbyid.CategoryName;

						var subcategoryId = getItemdetailsbypurchaseorder.SubCategory1Id;
						var subcategorydetailsid = _subCategory1Service.GetSubCategory1ById((int)subcategoryId);
						string subcategoryname = subcategorydetailsid.SubCategory1Name;

						var SubcategoryDetailId = getItemdetailsbypurchaseorder.SubCategory2Id;
						var SubcategoryDetailsById = _subCategory2Service.GetSubCategory2ById((int)SubcategoryDetailId);
						string subcategorydetailsname = SubcategoryDetailsById.SubCategory2Name;

						var Warehouseid = getItemdetailsbypurchaseorder.WareHuoseId;
						var WareHouseDetailsById = _wareHouseService.GetWareHousebyWareHuoseId((int)Warehouseid);
						string WarehouseName = WareHouseDetailsById.WareHouseName;

						string brandname = getItemdetailsbypurchaseorder.BrandName;

						sellerOrderModels.Add(new SellerOrderModel
						{
							SellerId = (long)sellerId,
							WareHuoseName = WarehouseName,
							SectorName = sectorname,
							DateTime = orderdate.ToString("dd-MM-yyyy"),
							InvoiceNumber = invoicenumber,
							Quantity = (double)qty,
							Amount = (double)amount,
							ItemName = Itemname,
							CategoryName = CategoryName,
							SubCategoryName = subcategoryname,
							subCategoryDetailsName = subcategorydetailsname,
							BrandName = brandname,

						});
					}

				}

				var reprot = sellerOrderModels;
				ViewBag.SellerOrderDetails = reprot;
			}
			
			


			return View("~/Plugins/Report.Web/Views/SellerOrders/SellerTotalOrderReprot.cshtml");
		}


	}
}
