using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouses.PinCodes;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Web.Framework.Controllers;
using CloudVOffice.Services.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Districts;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class DistrictController : BasePluginController
	{
		
		private readonly IDistrictService _districtService;
		private readonly IPinCodeService _pinCodeService;

		public DistrictController(IDistrictService districtService, IPinCodeService pinCodeService)
		{
			_districtService = districtService;
			_pinCodeService = pinCodeService;
		}


		[HttpGet]
		public IActionResult DistrictCreate(Int64? DistrictId)
		{

			ViewBag.PinCodeList = _pinCodeService.GetPinList();
			DistrictDTO districtDTO = new DistrictDTO();

			if (DistrictId != null)
			{
				District RF = _districtService.GetDistrictById(int.Parse(DistrictId.ToString()));

				districtDTO.PinCodeId = new List<long> { RF.PinCodeId, 12345 };
				districtDTO.DistrictName = RF.DistrictName;

			}
			return View("~/Plugins/Warehouse.Management/Views/District/DistrictCreate.cshtml", districtDTO);
		}

		[HttpPost]
		public IActionResult DistrictCreate(DistrictDTO districtDTO)
		{
			districtDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{

				if (districtDTO.DistrictId == null)
				{
					var a = _districtService.DistrictCreate(districtDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/District/DistrictView");

					}
					else if (a == MessageEnum.Duplicate)
					{

						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "WareHouse Already Exists");

					}
					else
					{

						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");

					}
				}
				else
				{
					var a = _districtService.DistrictUpdate(districtDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/District/DistrictView");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "WareHouse Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
			ViewBag.PinCodeList = _pinCodeService.GetPinList();

			return View("~/Plugins/Warehouse.Management/Views/District/DistrictCreate.cshtml", districtDTO);
		}


		public IActionResult DistrictView()
		{
			ViewBag.District = _districtService.GetDistrictList();

			return View("~/Plugins/Warehouse.Management/Views/District/DistrictView.cshtml");
		}

		[HttpGet]
		public IActionResult DistrictDelete(Int64 DistrictId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _districtService.DistrictDelete(DistrictId, DeletedBy);
			return Redirect("/WareHouse/District/DistrictView");
		}
	}
}
