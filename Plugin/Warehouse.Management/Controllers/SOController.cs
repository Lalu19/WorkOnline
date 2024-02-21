using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Data.DTO.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
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

        public SOController(IPurchaseOrderParentService purchaseOrderParentService, ApplicationDBContext dbContext)
		{
			_purchaseOrderParentService = purchaseOrderParentService;
			_dbContext = dbContext;
		}
		[HttpGet]
		public IActionResult SOCreate(Int64? SOId)
		{


			ViewBag.POlist = _purchaseOrderParentService.GetPurchaseOrderParentList();

			SODTO sODTO = new SODTO();
			//if (SOId != null)
			//{

			//	SO d = _purchaseOrderParentService.GetPurchaseOrderParentList();

			//	SODTO.BrandName = d.BrandName;
			//	SODTO.BrandImage = d.BrandImage;
			//}
			return View("~/Plugins/Warehouse.Management/Views/SalesOrders/SOCreate.cshtml", sODTO);			
		}


		[HttpPost]
		public IActionResult SalesOrderDataSave([FromBody] SalesOrderMasterDTO salesOrderMasterDTO)
		{


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



    }
}
