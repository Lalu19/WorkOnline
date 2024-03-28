using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Distributors;
using CloudVOffice.Services.Orders;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace Distributor_partner.Controllers
{
    public class SOController : Controller
    {
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<DSO> _SaleOrderRepo;
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly IItemService _ItemService;
		private readonly IDPOService _DPOService;
		private readonly IDPOItemsService _DPOItemsService;
		private readonly IBuyerOrderService _BuyerOrderService;
		private readonly IDistributorsAssignService _DistributorsAssignService;


		public SOController(ApplicationDBContext dbContext,
							IWebHostEnvironment hostingEnvironment,
							ISqlRepository<DSO> SaleOrderRepo,
							IItemService ItemService,
							IDPOService DPOService,
							IDPOItemsService DPOItemsService,
							IBuyerOrderService BuyerOrderService,
							IDistributorsAssignService distributorsAssignService

							)
		{
			_dbContext = dbContext;
			_hostingEnvironment = hostingEnvironment;
			_ItemService = ItemService;
			_SaleOrderRepo = SaleOrderRepo;
			_DPOService = DPOService;
			_DPOItemsService = DPOItemsService;
			_BuyerOrderService = BuyerOrderService;
			_DistributorsAssignService = distributorsAssignService;
		}
		[HttpGet]
		public IActionResult Buyerorderlist()
        {
			//var DistributorId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString());
			//var Pincodetails = _DistributorsAssignService.DAssignListbyDistributor(DistributorId);
			//foreach ( var x in Pincodetails )
			//{
			//	var buyerOrders = _BuyerOrderService.GetBuyerOrderListByPincode(x.PinCodeId);
			//	ViewBag.OrderList = buyerOrders;
			//}
			//return View();
			var DistributorId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString());
			var Pincodetails = _DistributorsAssignService.DAssignListbyDistributor(DistributorId);

			HashSet<BuyerOrder> allBuyerOrders = new HashSet<BuyerOrder>(); // Use HashSet instead of List

			foreach (var pincode in Pincodetails)
			{
				var buyerOrders = _BuyerOrderService.GetBuyerOrderListByPincode(pincode.PinCodeId);
				foreach (var order in buyerOrders)
				{
					allBuyerOrders.Add(order); // Add orders to HashSet
				}
			}

			ViewBag.OrderList = allBuyerOrders.ToList(); // Convert HashSet to List before assigning to ViewBag

			return View();
		}
    }
}
