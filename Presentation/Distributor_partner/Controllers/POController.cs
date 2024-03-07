using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.Distributor;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Authentication;
using CloudVOffice.Services.Company;
using CloudVOffice.Services.Distributors;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.AspNetCore.Mvc;

namespace Distributor_partner.Controllers
{
    public class POController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<DPO> _PurchaseOrderRepo;
		private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IItemService _ItemService;
        private readonly IDPOService _DPOService;
        private readonly IDPOItemsService _DPOItemsService;
		

		public POController(ApplicationDBContext dbContext, 
                            IWebHostEnvironment hostingEnvironment,
							ISqlRepository<DPO> PurchaseOrderRepo,
							IItemService ItemService,
							IDPOService DPOService,
							IDPOItemsService DPOItemsService

							)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
			_ItemService = ItemService;
			_PurchaseOrderRepo = PurchaseOrderRepo;
			_DPOService = DPOService;
			_DPOItemsService = DPOItemsService;

		}

        public IActionResult POCreate()
        {
            return View();
        }

		[HttpGet]
		public IActionResult ItemListByWareHouseIdbyJson()
		{
			int WareHousid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "WareHuoseId").Value.ToString());

			var a = _ItemService.ItemListByWareHouseId(WareHousid);

			return Json(a);

		}

		[HttpGet]
		public IActionResult GetItemByItemIdbyJson(Int64 itemId)
		{
			var a = _ItemService.GetItemByItemId(itemId);

			return Json(a);

		}
		
		[HttpPost]
		public IActionResult SaveDPO([FromBody] DPODTO dpoDTO)
		{
			try
			{
				Random random = new Random();
				DPO dpo = new DPO
				{
					DPOUniqueNo = random.Next(100000, 1000000).ToString(),
					WareHuoseId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "WareHuoseId").Value.ToString()),
					DistributorId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString()),
					TotalAmount = dpoDTO.TotalAmount,
					TotalQuantity = dpoDTO.TotalQuantity,
					OrderStatus = "Order Placed",
					CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString()),
					CreatedDate = DateTime.Now
				};

				dpo.DPOItems = new List<DPOItems>();

				foreach (var item in dpoDTO.Items)
				{
					DPOItems Dpoitem = new DPOItems
					{
						ItemId = item.ItemId,
						Quantity = item.Quantity,
						CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString()),
						CreatedDate = System.DateTime.Now
					};

					dpo.DPOItems.Add(Dpoitem);
				}

				var obj = _PurchaseOrderRepo.Insert(dpo);

				return Ok("DPO saved successfully");
			}
			catch (Exception ex)
			{
				return BadRequest("Error occurred while saving DPO");
			}
		}
		public IActionResult OrderList()
		{
			var DistributorId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString());
			var list = _DPOService.GetDPOList(DistributorId);
			ViewBag.OrderList = list;
            return View();
        }
		public IActionResult Orderdelete(Int64 DPOId)
		{
			var deleteby = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString());
			var a = _DPOService.DeleteDPOrder(DPOId, deleteby);
			return Json(a);
		}
	}
}
