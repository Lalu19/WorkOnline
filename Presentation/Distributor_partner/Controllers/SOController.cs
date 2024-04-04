using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Distributor;
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
		private readonly ISqlRepository<BuyerOrder> _BuyerOrderRepo;
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly IItemService _ItemService;
		private readonly IDPOService _DPOService;
		private readonly IDPOItemsService _DPOItemsService;
		private readonly IBuyerOrderService _BuyerOrderService;
		private readonly IDistributorsAssignService _DistributorsAssignService;


		public SOController(ApplicationDBContext dbContext,
							IWebHostEnvironment hostingEnvironment,
							ISqlRepository<DSO> SaleOrderRepo,
							ISqlRepository<BuyerOrder> BuyerOrderRepo,
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
			_BuyerOrderRepo = BuyerOrderRepo;
			_DPOService = DPOService;
			_DPOItemsService = DPOItemsService;
			_BuyerOrderService = BuyerOrderService;
			_DistributorsAssignService = distributorsAssignService;
		}
		[HttpGet]
		public IActionResult Buyerorderlist()
        {
			var DistributorId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString());
			var Pincodetails = _DistributorsAssignService.DAssignListbyDistributor(DistributorId);

			HashSet<BuyerOrder> allBuyerOrders = new HashSet<BuyerOrder>();

			foreach (var pincode in Pincodetails)
			{
				var buyerOrders = _BuyerOrderService.GetBuyerOrderListByPincode(pincode.PinCodeId, pincode.BrandId);
				foreach (var order in buyerOrders)
				{
					allBuyerOrders.Add(order);
				}
			}

			ViewBag.OrderList = allBuyerOrders.ToList();

			return View();
		}
		[HttpGet]
		public IActionResult Buyerorderdetails(Int64 BuyerOrderId)
		{
			var buyerOrderdetails = _BuyerOrderService.GetBuyerOrderListByBuyerOrderId(BuyerOrderId);
			ViewBag.OrderDetails = buyerOrderdetails;
			return View();
		}

		[HttpPost]
		public IActionResult SaveDSO([FromBody] DSODTO dsoDTO)
		{
			try
			{
				//Random random = new Random();
				DSO dso = new DSO
				{
					OrderUniqueNo = dsoDTO.OrderUniqueNo,
					DistributorId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString()),
					TotalAmount = dsoDTO.TotalAmount,
					TotalQuantity = dsoDTO.TotalQuantity,
					Address = dsoDTO.Address,
					MobileNumber = dsoDTO.MobileNumber,
					PincodeId = dsoDTO.PincodeId,
					BuyerOrderId = dsoDTO.BuyerOrderId,
					TotalWaight = dsoDTO.TotalWaight,
					OrderStatus = "Order Accepted",
					CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString()),
					CreatedDate = DateTime.Now
				};

				dso.DSOItems = new List<DSOItems>();

				foreach (var item in dsoDTO.Items)
				{
					DSOItems Dsoitem = new DSOItems
					{
						ItemId = item.ItemId,
						Quantity = item.Quantity,
						CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString()),
						CreatedDate = System.DateTime.Now
					};

					dso.DSOItems.Add(Dsoitem);
				}

				var obj = _SaleOrderRepo.Insert(dso);
				var buyerOrderlist = _BuyerOrderService.GetsingleBuyerOrderListByBuyerOrderId((long)dsoDTO.BuyerOrderId); 
				if (buyerOrderlist != null)
				{
					buyerOrderlist.OrderStatus = "Order Accepted";
					_BuyerOrderRepo.Update(buyerOrderlist); 
				}
				return Ok("DSO saved successfully");
			}
			catch (Exception ex)
			{
				return BadRequest("Error occurred while saving DPO");
			}
		}

		
	}
}
