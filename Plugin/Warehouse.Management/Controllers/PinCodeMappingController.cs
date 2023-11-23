using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouse.PinCodeMapping;
using CloudVOffice.Core.Domain.WareHouse.PinCodes;
using CloudVOffice.Data.DTO.WareHouse.PinCodeMapping;
using CloudVOffice.Data.DTO.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouse.PinCodeMappings;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Authorization;
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
		public PinCodeMappingController(IPinCodeMappingService pinCodeMappingService)
		{
			_pinCodeMappingService = pinCodeMappingService;
		}

		[HttpGet]
		[Authorize(Roles = "WareHouse Manager")]
		public IActionResult PinMappingCreate(int? pinCodeMappingId)
		{
			PinCodeMappingDTO pinCodeMappingDTO = new PinCodeMappingDTO();
			if (pinCodeMappingId != null)
			{

				PinCodeMapping d = _pinCodeMappingService.GetPinMappingByPinCodeId(int.Parse(pinCodeMappingId.ToString()));
				pinCodeMappingDTO.UserId = d.UserId;
				pinCodeMappingDTO.PinCodeId=d.PinCodeId;

			}

			return View("~/Plugins/Warehouse.Management/Views/PinCodeMapping/PinMappingCreate.cshtml", pinCodeMappingDTO);

		}

		[HttpPost]
		[Authorize(Roles = "WareHouse Manager")]
		public IActionResult PinMappingCreate(PinCodeMappingDTO pinCodeMappingDTO)
		{
			pinCodeMappingDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


			if (ModelState.IsValid)
			{
				if (pinCodeMappingDTO.PinCodeMappingId == null)
				{
					var a = _pinCodeMappingService.PinMappingCreate(pinCodeMappingDTO);
					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/PinCodeMapping/PinMappingView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "PinCode Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _pinCodeMappingService.PinMappingUpdate(pinCodeMappingDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/PinCodeMapping/PinMappingView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "PinCode Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
			return View("~/Plugins/Warehouse.Management/Views/PinCodeMapping/PinMappingCreate.cshtml", pinCodeMappingDTO);
		}



		[Authorize(Roles = "WareHouse Manager")]
		public IActionResult PinCodeMappingView()
		{
			ViewBag.pinMappings = _pinCodeMappingService.GetPinMappingList();

			return View("~/Plugins/Warehouse.Management/Views/PinCodeMapping/PinMappingView.cshtml");
		}


		[HttpGet]
		[Authorize(Roles = "WareHouse Manager")]
		public IActionResult DeletePin(Int64 pinCodeMappingId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _pinCodeMappingService.PinMappingDelete(pinCodeMappingId, DeletedBy);
			TempData["msg"] = a;
			return Redirect("/WareHouse/PinCodeMapping/PinMappingView");
		}
	}
}
