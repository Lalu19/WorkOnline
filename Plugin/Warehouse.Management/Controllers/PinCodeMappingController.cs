using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Services.Users;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.PinCodes;
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
	public class PinCodeMappingController : BasePluginController
	{
		private readonly IPinCodeMappingService _pinCodeMappingService;
		private readonly IPinCodeService _pinCodeService;
		private readonly IWareHouseService _wareHouseService;
        private readonly IUserWareHouseMappingService _UserWareHouseMappingService;

        public PinCodeMappingController(IPinCodeMappingService pinCodeMappingService,
										IPinCodeService pinCodeService,
										IWareHouseService wareHouseService,
                                        IUserWareHouseMappingService UserWareHouseMappingService
            )
		{
			_pinCodeMappingService = pinCodeMappingService;
			_pinCodeService = pinCodeService;
            _UserWareHouseMappingService = UserWareHouseMappingService;
        }


		[HttpGet]
		public IActionResult PinCodeMappingCreate(Int64? PinCodeMappingId)
		{
			ViewBag.PinCodeList = _pinCodeService.GetPinList();
			ViewBag.WareHouseList = _wareHouseService.GetWareHouseList();

			PinCodeMappingDTO pinCodeMappingDTO = new PinCodeMappingDTO();

			if (PinCodeMappingId != null)	
			{
				PinCodeMapping RF = _pinCodeMappingService.GetPinCodeMappingById(int.Parse(PinCodeMappingId.ToString()));

				pinCodeMappingDTO.PinCodeId = new List<long> { RF.PinCodeId, 12345 };
				pinCodeMappingDTO.WareHuoseId = RF.WareHuoseId;

			}
			return View("~/Plugins/Warehouse.Management/Views/PinCodeMapping/PinCodeMappingCreate.cshtml", pinCodeMappingDTO);
		}

		[HttpPost]
		public IActionResult PinCodeMappingCreate(PinCodeMappingDTO pinCodeMappingDTO)
		{
			pinCodeMappingDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{

				if (pinCodeMappingDTO.PinCodeMappingId == null)
				{
					var a = _pinCodeMappingService.PinCodeMappingCreate(pinCodeMappingDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/PinCodeMapping/PinCodeMappingView");

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
					var a = _pinCodeMappingService.PinCodeMappingUpdate(pinCodeMappingDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/PinCodeMapping/PinCodeMappingView");

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
			ViewBag.WareHouseList = _wareHouseService.GetWareHouseList();

			return View("~/Plugins/Warehouse.Management/Views/PinCodeMapping/PinCodeMappingCreate.cshtml", pinCodeMappingDTO);
		}


		public IActionResult PinCodeMappingView()
		{
			ViewBag.PinCodeMapping = _pinCodeMappingService.GetPinCodeMappingList();

			return View("~/Plugins/Warehouse.Management/Views/PinCodeMapping/PinCodeMappingView.cshtml");
		}

		[HttpGet]
		public IActionResult DeletePinCodeMapping(Int64 PinCodeMappingId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _pinCodeMappingService.PinCodeMappingDelete(PinCodeMappingId, DeletedBy);
			return Redirect("/WareHouse/PinCodeMapping/PinCodeMappingView");
		}

        public JsonResult Getpincodelistbywarehouse()
        {
            Int64 UserId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            var Warehousedetails = _UserWareHouseMappingService.GetWareHouseByUserId(UserId);

            return Json(_pinCodeMappingService.GetPinCodeMappingListbywarehouseId(Warehousedetails.WareHuoseId));
        }
    }
}
