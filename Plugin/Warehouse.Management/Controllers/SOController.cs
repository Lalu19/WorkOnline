using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Data.DTO.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
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

		public SOController(IPurchaseOrderParentService purchaseOrderParentService)
		{
			_purchaseOrderParentService = purchaseOrderParentService;
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


	}
}
