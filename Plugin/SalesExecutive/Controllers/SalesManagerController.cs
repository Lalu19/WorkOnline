using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Services.Sales;
using CloudVOffice.Services.WareHouses.Months;
using CloudVOffice.Services.WareHouses.States;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesExecutive.Controllers
{
	[Area(AreaNames.SalesExecutive)]
	public class SalesManagerController : BaseController
	{
		private readonly ISalesManagerService _salesManagerService;
		private readonly IStateService _stateService;

		public SalesManagerController(ISalesManagerService salesManagerService, IStateService stateService)
		{
			_salesManagerService = salesManagerService;
			_stateService = stateService;

		}
		[HttpGet]
		public IActionResult SalesManagerCreate(Int64? SalesManagerId)
		{

			ViewBag.States = _stateService.GetStateList();
			SalesManagerDTO salesManagerDTO = new SalesManagerDTO();
			if (SalesManagerId != null)
			{

				SalesManager d = _salesManagerService.GetSalesManagerById(int.Parse(SalesManagerId.ToString()));

				salesManagerDTO.SalesManagerName = d.SalesManagerName;
				salesManagerDTO.StateId = d.StateId;
				salesManagerDTO.Telephone = d.Telephone;
				salesManagerDTO.Address = d.Address;
				salesManagerDTO.EmailId = d.EmailId;
			}
            return View("~/Plugins/SalesExecutive/Views/SalesManagers/SalesManagerCreate.cshtml", salesManagerDTO);
        }

		[HttpPost]
		public IActionResult SalesManagerCreate(SalesManagerDTO salesManagerDTO)
		{
			salesManagerDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{
				if (salesManagerDTO.SalesManagerId == null)
				{
					var a = _salesManagerService.SalesManagerCreate(salesManagerDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/SalesExecutive/SalesManager/SalesManagerView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Month Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _salesManagerService.SalesManagerUpdate(salesManagerDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/SalesExecutive/SalesManager/SalesManagerView");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "salesManager Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
			ViewBag.States = _stateService.GetStateList();
			return View("~/Plugins/SalesExecutive/Views/SalesManagers/SalesManager.cshtml", salesManagerDTO);

		}

		public IActionResult SalesManagerView()
		{
			ViewBag.SalesManagers = _salesManagerService.GetSalesManagerList();

			return View("~/Plugins/SalesExecutive/Views/SalesManagers/SalesManagerView.cshtml");

		}

		[HttpGet]
		public IActionResult SalesManagerDelete(Int64 SalesManagerId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _salesManagerService.SalesManagerDelete(SalesManagerId, DeletedBy);
			return Redirect("/SalesExecutive/SalesManager/SalesManagerView");
		}
	}
}
