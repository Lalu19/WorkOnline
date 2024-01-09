using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.States;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.States;
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

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class StateController : BasePluginController
	{
		private readonly IStateService _stateService;

		public StateController(IStateService stateService)
		{
			_stateService = stateService;

		}
		[HttpGet]
		public IActionResult StateCreate(Int64? StateId)
		{


			StateDTO stateDTO = new StateDTO();
			if (StateId != null)
			{

				State d = _stateService.GetStateById(int.Parse(StateId.ToString()));

				stateDTO.StateName = d.StateName;
			}
			return View("~/Plugins/Warehouse.Management/Views/State/StateCreate.cshtml", stateDTO);
		}

		[HttpPost]
		public IActionResult StateCreate(StateDTO stateDTO)
		{
			stateDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{
				if (stateDTO.StateId == null)
				{
					var a = _stateService.StateCreate(stateDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/State/StateView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "State Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _stateService.StateUpdate(stateDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/State/StateView");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "State Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}

			return View("~/Plugins/Warehouse.Management/Views/State/StateCreate.cshtml", stateDTO);

		}

		public IActionResult StateView()
		{
			ViewBag.States = _stateService.GetStateList();

			return View("~/Plugins/Warehouse.Management/Views/State/StateView.cshtml");
		}

		[HttpGet]
		public IActionResult StateDelete(Int64 StateId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _stateService.StateDelete(StateId, DeletedBy);
			return Redirect("/WareHouse/State/StateView");
		}
	}
}
