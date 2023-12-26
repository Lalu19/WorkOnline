using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using CloudVOffice.Web.Framework.Controllers;
using CloudVOffice.Services.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Districts;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
	public class DistrictMappingController : BasePluginController
	{
		
		private readonly IDistrictMappingService _districtMappingService;
		private readonly IPinCodeService _pinCodeService;
        private readonly IAddDistrictService _addDistrictService;

        public DistrictMappingController(IDistrictMappingService districtMappingService,
			                             IPinCodeService pinCodeService,
										 IAddDistrictService addDistrictService
			                            )
		{
            _districtMappingService = districtMappingService;
			_pinCodeService = pinCodeService;
			_addDistrictService = addDistrictService;

        }


		[HttpGet]
		public IActionResult DistrictMappingCreate(Int64? DistrictMappingId)
		{

			ViewBag.PinCodeList = _pinCodeService.GetPinList();
            ViewBag.AddDistricts = _addDistrictService.GetAddDistrictList();

            DistrictMappingDTO districtMappingDTO = new DistrictMappingDTO();

			if (DistrictMappingId != null)
			{
				DistrictMapping RF = _districtMappingService.GetDistrictMappingById(int.Parse(DistrictMappingId.ToString()));

                districtMappingDTO.PinCodeId = new List<long> { RF.PinCodeId, 12345 };
                districtMappingDTO.AddDistrictId = RF.AddDistrictId;

			}
			return View("~/Plugins/Warehouse.Management/Views/District/DistrictMappingCreate.cshtml", districtMappingDTO);
		}

		[HttpPost]
		public IActionResult DistrictMappingCreate(DistrictMappingDTO districtMappingDTO)
		{
            districtMappingDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{

				if (districtMappingDTO.DistrictMappingId == null)
				{
					var a = _districtMappingService.DistrictMappingCreate(districtMappingDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/DistrictMapping/DistrictMappingView");

					}
					else if (a == MessageEnum.Duplicate)
					{

						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "District Mapping Already Exists");

					}
					else
					{

						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");

					}
				}
				else
				{
					var a = _districtMappingService.DistrictMappingUpdate(districtMappingDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/DistrictMapping/DistrictMappingView");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "District Mapping Already Exists");
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


		public IActionResult DistrictMappingView()
		{
			ViewBag.DistrictMappings = _districtMappingService.GetDistrictMappingList();

			return View("~/Plugins/Warehouse.Management/Views/District/DistrictMappingView.cshtml");
		}

		[HttpGet]
		public IActionResult DistrictMappingDelete(Int64 DistrictMappingId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _districtMappingService.DistrictMappingDelete(DistrictMappingId, DeletedBy);

			return Redirect("/WareHouse/DistrictMapping/DistrictMappingView");
		}
	}
}
