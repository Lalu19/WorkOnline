using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Data.DTO.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.WareHouses.SalesOrders;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class SOController : BasePluginController
	{
		private readonly IPurchaseOrderParentService _purchaseOrderParentService;
		private readonly ApplicationDBContext _dbContext;
        private readonly ISalesOrderParentService _salesOrderParentService;
        private readonly ISalesOrderItemService _salesOrderItemService;
        private readonly IWareHouseService _wareHouseService;

        public SOController(IPurchaseOrderParentService purchaseOrderParentService, ApplicationDBContext dbContext, ISalesOrderParentService salesOrderParentService, ISalesOrderItemService salesOrderItemService, IWareHouseService wareHouseService)
		{
			_purchaseOrderParentService = purchaseOrderParentService;
			_dbContext = dbContext;
			_salesOrderParentService = salesOrderParentService;
            _salesOrderItemService = salesOrderItemService;
			_wareHouseService = wareHouseService;
        }
		[HttpGet]
		public IActionResult SOCreate(Int64? SOId)
		{

			ViewBag.POlist = _purchaseOrderParentService.GetPurchaseOrderParentList();
			SODTO sODTO = new SODTO();



			


			return View("~/Plugins/Warehouse.Management/Views/SalesOrders/SOCreate.cshtml", sODTO);
		}


		[HttpPost]
		public IActionResult SalesOrderDataSave([FromBody] SalesOrderMasterDTO salesOrderMasterDTO)
		{
			Int64 createdBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var warehouseId =  _wareHouseService.GetWareHouseByPOPUniqueNumber(salesOrderMasterDTO.ParentOrder.POPUniqueNumber);

			salesOrderMasterDTO.ParentOrder.WareHuoseId = warehouseId;
			salesOrderMasterDTO.ParentOrder.CreatedBy =	createdBy;

			var a = _salesOrderParentService.SalesOrderParentCreate(salesOrderMasterDTO.ParentOrder);
			
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
			var a = _dbContext.PurchaseOrderParents.FirstOrDefault(a=> a.POPUniqueNumber == parsedGlobalId.ToString());
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

    }
}
