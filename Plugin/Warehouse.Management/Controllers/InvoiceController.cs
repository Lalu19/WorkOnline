using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.SalesOrders;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.WareHouses.SalesOrders;
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

        private readonly ISalesOrderParentService _salesOrderParentService;
        private readonly ISalesOrderItemService _salesOrderItemService;

        public InvoiceController(
                                 IPurchaseOrderParentService purchaseOrderParentService,
                                 IPurchaseOrderService purchaseOrderService,
                                 ISalesOrderParentService salesOrderParentService,
                                 ISalesOrderItemService salesOrderItemService
                                )
        {
            _purchaseOrderParentService = purchaseOrderParentService;
            _purchaseOrderService = purchaseOrderService;
            _salesOrderParentService = salesOrderParentService;
            _salesOrderItemService = salesOrderItemService;
        }

        [HttpGet]
        public IActionResult InvoiceCreate(Int64 PurchaseOrderParentId)                       
        {
			var orderdetails = _purchaseOrderParentService.GetPOOrderByPurchaseOrderParentId(PurchaseOrderParentId);
			ViewBag.POOrderDetails = orderdetails;
			return View("~/Plugins/Warehouse.Management/Views/Invoice/InvoiceCreate.cshtml");

        }

        //[HttpGet]
        //public IActionResult SOInvoiceCreate(Int64 SalesOrderParentId)
        //{
        //    var orderdetails = _salesOrderParentService.GetSOOrderBySalesOrderParentId(SalesOrderParentId);
        //    ViewBag.SOOrderDetails = orderdetails;
        //    return View("~/Plugins/Warehouse.Management/Views/Invoice/SOInvoiceCreate.cshtml");

        //}

        [HttpGet]
        public IActionResult SOInvoiceCreate(Int64 CreatedBy, Int64 SalesOrderParentId)
        {
            var orderdetails = _salesOrderParentService.GetSOOrderBySalesOrderParentId(SalesOrderParentId);
            ViewBag.SOOrderDetails = orderdetails;

            var sellerdetails = _salesOrderParentService.GetSOOrderByCreatedBy(CreatedBy);
            ViewBag.SellerDetails = sellerdetails;
            return View("~/Plugins/Warehouse.Management/Views/Invoice/SOInvoiceCreate.cshtml");

        }

    }
}
 