using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Distributors;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.AspNetCore.Mvc;

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


		public SOController(ApplicationDBContext dbContext,
							IWebHostEnvironment hostingEnvironment,
							ISqlRepository<DSO> SaleOrderRepo,
							IItemService ItemService,
							IDPOService DPOService,
							IDPOItemsService DPOItemsService

							)
		{
			_dbContext = dbContext;
			_hostingEnvironment = hostingEnvironment;
			_ItemService = ItemService;
			_SaleOrderRepo = SaleOrderRepo;
			_DPOService = DPOService;
			_DPOItemsService = DPOItemsService;

		}
		[HttpGet]
		public IActionResult Buyerorderlist()
        {
			//var DistributorId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "DistributorRegistrationId").Value.ToString());
			//var list = _DPOService.GetDPOList(DistributorId);
			//ViewBag.OrderList = list;
			return View();
        }
    }
}
