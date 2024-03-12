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
    public class BuyerOrderController : Controller
    {
        private readonly ICheckoutService _checkoutService;
        private readonly IBuyerOrderService _BuyerOrderService;
        private readonly IBuyerOrderItemsService _BuyerOrderItemsService;
        public BuyerOrderController(ICheckoutService checkoutService, 
                                IBuyerOrderService BuyerOrderService,
                                IBuyerOrderItemsService buyerOrderItemsService
                                )
        {
            _checkoutService = checkoutService;
            _BuyerOrderService = BuyerOrderService;
            _BuyerOrderItemsService = buyerOrderItemsService;
        }
        [HttpPost]
        public IActionResult BuyerOrderCreate(BuyerOrderDTO BuyerOrderDTO)
        {
            try
            {
                var a = _BuyerOrderService.BuyerOrderCreate(BuyerOrderDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

       
        [HttpGet("{UserId}")]
        public IActionResult GetBuyerOrderListByUserId(int UserId)
        {
            var a = _BuyerOrderService.GetBuyerOrderListByUserId(UserId);
            return Ok(a);
        }

        //[HttpGet("{PincodeId}")]
        //public IActionResult GetItemsbyDistributorId(int PincodeId)
        //{

        //    var a = 

        //}

    }
}
