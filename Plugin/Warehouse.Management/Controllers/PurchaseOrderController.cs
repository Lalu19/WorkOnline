using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]

	public class PurchaseOrderController : BasePluginController
	{
		private readonly IPurchaseOrderService _purchaseOrderService;
		private readonly ISellerRegistrationService _sellerRegistrationService;
		private readonly IPurchaseOrderParentService _purchaseOrderParentService;


		public PurchaseOrderController(IPurchaseOrderService purchaseOrderService, ISellerRegistrationService sellerRegistrationService,
									   IPurchaseOrderParentService purchaseOrderParentService
										)
		{
			_purchaseOrderService = purchaseOrderService;
			_sellerRegistrationService = sellerRegistrationService;
			_purchaseOrderParentService = purchaseOrderParentService;
		}


		[HttpGet]
		public IActionResult CreatePurchaseOrder(int? purchaseOrderId)
		{
			PurchaseOrderDTO purchaseOrderDTO = new PurchaseOrderDTO();

			ViewBag.Sellers = _sellerRegistrationService.GetSellerRegistrationList();

			if(purchaseOrderId != null)
			{
				var purchase = _purchaseOrderService.GetPurchaseOrderById(int.Parse(purchaseOrderId.ToString()));

				purchaseOrderDTO.Quantity = purchase.Quantity;
				purchaseOrderDTO.SellerRegistrationId = purchase.SellerRegistrationId;
				purchaseOrderDTO.ItemId = purchase.ItemId;

			}

			return View("~/Plugins/Warehouse.Management/Views/PurchaseOrder/PurchaseOrderCreate.cshtml", purchaseOrderDTO);

		}

		[HttpPost]
		public IActionResult CreatePurchaseOrder([FromBody] PurchaseOrderMasterDTO model)
		{
			//purchaseOrderDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _purchaseOrderParentService.PurchaseOrderParentCreate(model.Parent);

			foreach (var order in model.Orders)
			{
				order.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

				if (order.PurchaseOrderId == null)
				{
					// It's a new target, create it

					order.PurchaseOrderParentId = a.PurchaseOrderParentId;
					var result = _purchaseOrderService.PurchaseOrderCreate(order);

					// Handle the result accordingly
					if (result == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
					}
					else if (result == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Order Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					// It's an existing target, update it
					var result = _purchaseOrderService.PurchaseOrderUpdate(order);

					// Handle the result accordingly
					if (result == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/PurchaseOrder/PurchaseOrderView");
					}
					else if (result == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Order Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}

			return Ok();

		}

		[HttpGet]
		public IActionResult DeletePurchaseOrder(Int64 purchaseOrderId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _purchaseOrderService.PurchaseOrderDelete(purchaseOrderId, DeletedBy);
			TempData["msg"] = a;
			return Redirect("/WareHouse/PurchaseOrder/PurchaseOrderView");
		}


		public IActionResult PurchaseOrderView()
		{
			ViewBag.PurchaseOrders = _purchaseOrderService.GetPurchaseOrderList();
            return View("~/Plugins/Warehouse.Management/Views/PurchaseOrder/PurchaseOrderView.cshtml");
        }

		public List<Item> ItemsFromSellerRegisteredSector(Int64 sellerRegistrationId)
		{
			var items = _purchaseOrderService.ItemsFromSellerRegisteredSector(sellerRegistrationId);

			var uniqueBrands = items.GroupBy(b => b.ItemId).Select(g => g.First()).ToList();

			return uniqueBrands;
		}

		public Int64 ItemIdFromItemName(string itemName)
		{
			var itemId = _purchaseOrderService.ItemIdFromItemName(itemName);
			return itemId;
		}

		public Item ItemDetails(int itemId)
		{
			var item = _purchaseOrderService.GetItemFromItemId(itemId);

			return item;
		}
	}
}
