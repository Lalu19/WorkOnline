using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Data.DTO.Orders;
using CloudVOffice.Services.Orders;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Orders
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CheckoutController : Controller
	{
		private readonly ICheckoutService _checkoutService;
		private readonly IPurchaseOrderService _purchaseOrderService;
		public CheckoutController(ICheckoutService checkoutService,IPurchaseOrderService purchaseOrderService)
		{
			_checkoutService = checkoutService;
			_purchaseOrderService = purchaseOrderService;
		}
		[HttpPost]
		public IActionResult CheckOutCreate(CheckoutDTO checkoutDTO)
		{
			try
			{
				var a = _checkoutService.CheckoutCreate(checkoutDTO);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}
		[HttpGet]
		public IActionResult CheckOutList()
		{
			var a = _checkoutService.CheckoutList();
			return Ok(a);
		}
		[HttpGet("{CheckoutId}")]
		public IActionResult SingleCategoryListbyId(Int64 CheckoutId)
		{
			var a = _checkoutService.CheckoutById(CheckoutId);
			return Ok(a);
		}
		[HttpPost]
		public IActionResult UpdateCheckOut(CheckoutDTO checkOutDTO)
		{
			try
			{
				var a = _checkoutService.CheckoutUpdate(checkOutDTO);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}
		[HttpGet("{CheckoutId}/{Createdby}")]
		public IActionResult CheckOutUpdateplus(Int64 CheckoutId, int Createdby)
		{
			try
			{
				var a = _checkoutService.CheckOutPlusUpdate(CheckoutId, Createdby);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}
		[HttpGet("{CheckoutId}/{Createdby}")]
		public IActionResult CheckOutUpdateMinus(Int64 CheckoutId, int Createdby)
		{
			try
			{
				var a = _checkoutService.CheckOutMinusUpdate(CheckoutId, Createdby);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}
		[HttpGet("{CheckoutId}/{DeletedBy}")]
		public ActionResult DelateCheckout(Int64 CheckoutId, int DeletedBy)
		{
			var a = _checkoutService.CheckoutDelete(CheckoutId, DeletedBy);
			return Ok(a);
		}

        [HttpGet("{PurchaseOrderParentId}")]
        public IActionResult GetItemsByPurchaseOrderParentId(Int64 PurchaseOrderParentId)
        {
            var a = _purchaseOrderService.GetItemsByPurchaseOrderParentId(PurchaseOrderParentId);
            return Ok(a);
        }

        [HttpGet("{UserId}")]
        public IActionResult CheckOutListbyUserId(int UserId)
        {
            var a = _checkoutService.CheckOutListbyUserId(UserId);
            return Ok(a);
        }
        [HttpGet("{ItemsId}/{DeletedBy}/{Createdby}")]
        public ActionResult DeleteCheckOutAfterOrder(int ItemsId, Int64 DeletedBy, Int64 Createdby)
        {
            var a = _checkoutService.CheckOutDeleteAfterOrder(ItemsId, DeletedBy, Createdby);
            return Ok(a);
        }
    }
}
