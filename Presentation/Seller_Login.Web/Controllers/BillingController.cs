using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.WareHouses.SalesOrders;
using Microsoft.AspNetCore.Mvc;

namespace Seller_Login.Web.Controllers
{
	public class BillingController : Controller
	{
		private readonly IPurchaseOrderParentService _purchaseOrderParentService;
		private readonly ApplicationDBContext _dbContext;
		private readonly ISalesOrderParentService _salesOrderParentService;
		private readonly ISalesOrderItemService _salesOrderItemService;
		private readonly IPurchaseOrderService _purchaseOrderService;

		public BillingController(IPurchaseOrderParentService purchaseOrderParentService, ApplicationDBContext dbContext, ISalesOrderParentService salesOrderParentService, ISalesOrderItemService salesOrderItemService, IPurchaseOrderService purchaseOrderService)
		{
			_purchaseOrderParentService = purchaseOrderParentService;
			_dbContext = dbContext;
			_salesOrderParentService = salesOrderParentService;
			_salesOrderItemService = salesOrderItemService;
            _purchaseOrderService = purchaseOrderService;

        }
		[HttpGet]
		public IActionResult SOCreate(Int64? SOId)
		{
			ViewBag.POlist = _purchaseOrderParentService.GetPurchaseOrderParentList();
			//SODTO sODTO = new SODTO();

			//return View("~/Plugins/Warehouse.Management/Views/SalesOrders/SOCreate.cshtml", sODTO);
			return View();

        }


		[HttpPost]
		public IActionResult SalesOrderDataSave([FromBody] SalesOrderMasterDTO salesOrderMasterDTO)
		{
			var a = _salesOrderParentService.SalesOrderParentCreate(salesOrderMasterDTO.ParentOrder);
			Int64 createdBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var result = _salesOrderItemService.SalesOrderItemCreate(a.SalesOrderParentId, createdBy, salesOrderMasterDTO.Orders);

			if (result == MessageEnum.Success)
			{
				TempData["msg"] = MessageEnum.Success;
				return Redirect("/WareHouse/Month/MonthView");
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


			return Ok();
		}

		[HttpPost]
		public IActionResult SOShippedSetTrue([FromBody] int parsedGlobalId)
		{
			var a = _dbContext.PurchaseOrderParents.FirstOrDefault(a => a.POPUniqueNumber == parsedGlobalId.ToString());
			if (a != null)
			{
				a.OrderShipped = true;
				_dbContext.SaveChanges();
			}
			return Ok();
		}

		[HttpGet]
		public IActionResult SalesOrderParentView()
		{
			ViewBag.SalesOrderParent = _salesOrderParentService.GetSalesOrderParentList();
			return View("~/Plugins/Warehouse.Management/Views/SalesOrders/SalesOrderView.cshtml");
		}

		[HttpGet]
		public IActionResult SalesOrderParentDelete(int salesOrderParentId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _salesOrderParentService.DeleteSalesOrderParent(salesOrderParentId, DeletedBy);
			return Redirect("/WareHouse/SO/SalesOrderParentView");
		}

        public JsonResult GetItemsByPurchaseOrderParentId(Int64 PurchaseOrderParentId)
        {
            //Int64 UserId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            return Json(_purchaseOrderService.GetItemsByPurchaseOrderParentId(PurchaseOrderParentId));
        }

    }
}
