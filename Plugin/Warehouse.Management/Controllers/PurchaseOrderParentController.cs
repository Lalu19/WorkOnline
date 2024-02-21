using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
//using CloudVOffice.Data.Migrations;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.WareHouses.Months;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
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
	public class PurchaseOrderParentController : BasePluginController
	{
		private readonly IPurchaseOrderParentService _purchaseOrderParentServiceService;
		private readonly ISellerRegistrationService _sellerRegistrationService;

		public PurchaseOrderParentController(IPurchaseOrderParentService purchaseOrderParentServiceService, ISellerRegistrationService sellerRegistrationService)
		{
			_purchaseOrderParentServiceService = purchaseOrderParentServiceService;
			_sellerRegistrationService = sellerRegistrationService;
		}
		//[HttpGet]
		//public IActionResult CreatePurchaseOrderParent(Int64? purchaseOrderParentId)
		//{
		//	ViewBag.Sellers = _sellerRegistrationService.GetSellerRegistrationList();
		//	PurchaseOrderParentDTO purchaseOrderParentDTO = new PurchaseOrderParentDTO();
		//	if (purchaseOrderParentId != null)
		//	{

		//		var purchase = _purchaseOrderParentServiceService.GetPurchaseOrderParentById(int.Parse(purchaseOrderParentId.ToString()));

		//		purchaseOrderParentDTO.TotalAmount = purchase.TotalAmount;
		//		purchaseOrderParentDTO.TotalQuantity = purchase.TotalQuantity;
		//		purchaseOrderParentDTO.SellerRegistrationId = purchase.SellerRegistrationId;
		//		purchaseOrderParentDTO.OrderShipped = purchase.OrderShipped;
		//	}
		//	return View("~/Plugins/Warehouse.Management/Views/PurchaseOrder/PurchaseOrderParentCreate.cshtml", purchaseOrderParentDTO);
		//}

		//[HttpPost]
		//public IActionResult CreatePurchaseOrderParent(PurchaseOrderParentDTO purchaseOrderParentDTO)
		//{
		//	purchaseOrderParentDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

		//	if (ModelState.IsValid)
		//	{
		//		if (purchaseOrderParentDTO.PurchaseOrderParentId == null)
		//		{
		//			var a = _purchaseOrderParentServiceService.PurchaseOrderParentCreate(purchaseOrderParentDTO);

		//			if (a == MessageEnum.Success)
		//			{
		//				TempData["msg"] = MessageEnum.Success;
		//				return Redirect("/WareHouse/PurchaseOrderParent/PurchaseOrderParentView");
		//			}
		//			else if (a == MessageEnum.Duplicate)
		//			{
		//				TempData["msg"] = MessageEnum.Duplicate;
		//				ModelState.AddModelError("", "PurchaseOrderParent Already Exists");
		//			}
		//			else
		//			{
		//				TempData["msg"] = MessageEnum.UnExpectedError;
		//				ModelState.AddModelError("", "Un-Expected Error");
		//			}
		//		}
		//		else
		//		{
		//			var a = _purchaseOrderParentServiceService.PurchaseOrderParentUpdate(purchaseOrderParentDTO);
		//			if (a == MessageEnum.Updated)
		//			{
		//				TempData["msg"] = MessageEnum.Updated;
		//				return Redirect("/WareHouse/PurchaseOrderParent/PurchaseOrderParentView");

		//			}
		//			else if (a == MessageEnum.Duplicate)
		//			{
		//				TempData["msg"] = MessageEnum.Duplicate;
		//				ModelState.AddModelError("", "PurchaseOrderParent Already Exists");
		//			}
		//			else
		//			{
		//				TempData["msg"] = MessageEnum.UnExpectedError;
		//				ModelState.AddModelError("", "Un-Expected Error");
		//			}
		//		}
		//	}

		//	return View("~/Plugins/Warehouse.Management/Views/PurchaseOrder/PurchaseOrderParentCreate.cshtml", purchaseOrderParentDTO);

		//}

		public IActionResult PurchaseOrderParentView()
		{
			ViewBag.PurchaseOrderParents = _purchaseOrderParentServiceService.GetPurchaseOrderParentList();

			return View("~/Plugins/Warehouse.Management/Views/PurchaseOrder/PurchaseOrderParentView.cshtml");
		}

		[HttpGet]
		public IActionResult PurchaseOrderParentDelete(Int64 PurchaseOrderParentId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _purchaseOrderParentServiceService.PurchaseOrderParentDelete(PurchaseOrderParentId, DeletedBy);
			return Redirect("/WareHouse/PurchaseOrderParent/PurchaseOrderParentView");
		}
	}
}
