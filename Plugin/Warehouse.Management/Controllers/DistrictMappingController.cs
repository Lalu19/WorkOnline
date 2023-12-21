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
	public class DistrictMappingController : BasePluginController
	{
		
		private readonly IDistrictMappingService _districtService;
		private readonly IPinCodeService _pinCodeService;
        private readonly IAddDistrictService _addDistrictService;

        public DistrictMappingController(IDistrictMappingService districtService, IPinCodeService pinCodeService, IAddDistrictService addDistrictService)
		{
			_districtService = districtService;
			_pinCodeService = pinCodeService;
			_addDistrictService = addDistrictService;

        }


		[HttpGet]
		public IActionResult DistrictCreate(Int64? DistrictMappingId)
		{

			ViewBag.PinCodeList = _pinCodeService.GetPinList();
            ViewBag.AddDistricts = _addDistrictService.GetAddDistrictList();
            DistrictMappingDTO districtMappingDTO = new DistrictMappingDTO();

			if (DistrictMappingId != null)
			{
				DistrictMapping RF = _districtService.GetDistrictById(int.Parse(DistrictMappingId.ToString()));

                districtMappingDTO.PinCodeId = new List<long> { RF.PinCodeId, 12345 };
                districtMappingDTO.AddDistrictId = RF.AddDistrictId;

			}
			return View("~/Plugins/Warehouse.Management/Views/District/DistrictMappingCreate.cshtml", districtMappingDTO);
		}

		[HttpPost]
		public IActionResult DistrictCreate(DistrictMappingDTO districtMappingDTO)
		{
            districtMappingDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{

				if (districtMappingDTO.DistrictMappingId == null)
				{
					var a = _districtService.DistrictCreate(districtMappingDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/DistrictMapping/DistrictMappingView");

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
					var a = _districtService.DistrictUpdate(districtMappingDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/DistrictMapping/DistrictMappingView");

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
            ViewBag.AddDistricts = _addDistrictService.GetAddDistrictList();

            return View("~/Plugins/Warehouse.Management/Views/District/DistrictMappingCreate.cshtml", districtMappingDTO);
		}


		public IActionResult DistrictView()
		{
			ViewBag.DistrictMappings = _districtService.GetDistrictList();

			return View("~/Plugins/Warehouse.Management/Views/District/DistrictMappingView.cshtml");
		}

		[HttpGet]
		public IActionResult DistrictDelete(Int64 DistrictMappingId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _districtService.DistrictDelete(DistrictMappingId, DeletedBy);
			return Redirect("/WareHouse/DistrictMapping/DistrictMappingView");
		}
	}
}
