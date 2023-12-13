using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Data.DTO.WareHouses.UOMs;
using CloudVOffice.Services.WareHouses.UOMs;
using CloudVOffice.Web.Framework.Controllers;
using CloudVOffice.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class UnitController : BasePluginController
	{
		private readonly IUnit _UnitService;
		private readonly IUnitGroup _UnitGroupService;
		public UnitController(IUnit UnitService, IUnitGroup unitGroupService)
		{

			_UnitService = UnitService;
			_UnitGroupService = unitGroupService;
		}
		[HttpGet]
		public IActionResult UnitCreate(int? unitId)
		{
			UnitDTO unitDTO = new UnitDTO();
			var UnitGroups = _UnitGroupService.GetUnitGroup();
			ViewBag.unitgroup = UnitGroups;
			if (unitId != null)
			{

				var d = _UnitService.GetUnitByUnitId(int.Parse(unitId.ToString()));
				unitDTO.UnitName = d.UnitName;
				unitDTO.ShortName = d.ShortName;
				unitDTO.UnitGroupId = d.UnitGroupId;

			}

			return View("~/Plugins/Warehouse.Management/Views/Unit/UnitCreate.cshtml", unitDTO);

		}
		[HttpPost]
		public IActionResult UnitCreate(UnitDTO unitDTO)
		{
			unitDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


			if (ModelState.IsValid)
			{
				if (unitDTO.UnitId == null)
				{
					var a = _UnitService.UnitCreate(unitDTO);
					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/Unit/UnitView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Unit Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _UnitService.UnitUpdate(unitDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/Unit/UnitView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Unit Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
			var UnitGroups = _UnitGroupService.GetUnitGroup();
			ViewBag.unitgroup = UnitGroups;
			return View("~/Plugins/Warehouse.Management/Views/Unit/UnitCreate.cshtml", unitDTO);
		}

		public IActionResult UnitView()
		{
			ViewBag.Unit = _UnitService.GetUnit();

			return View("~/Plugins/Warehouse.Management/Views/Unit/UnitView.cshtml");
		}

		[HttpGet]
		public IActionResult UnitDelete(int unitId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _UnitService.UnitDelete(unitId, DeletedBy);
			TempData["msg"] = a;
			return Redirect("/WareHouse/Unit/UnitView");
		}
	}
}
