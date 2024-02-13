using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.SalesOrders;
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
    public class InvoiceController : BasePluginController
    {
        private readonly IPurchaseOrderParentService _purchaseOrderParentService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        public InvoiceController(IPurchaseOrderParentService purchaseOrderParentService, IPurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderParentService = purchaseOrderParentService;
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpGet]
        public IActionResult InvoiceCreate(Int64 PurchaseOrderParentId)                       
        {
			var orderdetails = _purchaseOrderParentService.GetPOOrderByPurchaseOrderParentId(PurchaseOrderParentId);
			ViewBag.POOrderDetails = orderdetails;
			return View("~/Plugins/Warehouse.Management/Views/Invoice/InvoiceCreate.cshtml");

        }
	}
}
