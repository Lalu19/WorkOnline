using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Services.WareHouses.Districts;
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
	public class AddDistrictController : BasePluginController
	{
		private readonly IAddDistrictService _addDistrictService;

		public AddDistrictController(IAddDistrictService addDistrictService)
		{
			_addDistrictService = addDistrictService;

		}
		[HttpGet]
		public IActionResult AddDistrictCreate(Int64? AddDistrictId)
		{


			AddDistrictDTO addDistrictDTO = new AddDistrictDTO();
			if (AddDistrictId != null)
			{

				AddDistrict d = _addDistrictService.GetAddDistrictById(int.Parse(AddDistrictId.ToString()));

				addDistrictDTO.DistrictName = d.DistrictName;
			}
			return View("~/Plugins/Warehouse.Management/Views/District/AddDistrictCreate.cshtml", addDistrictDTO);
		}

		[HttpPost]
		public IActionResult AddDistrictCreate(AddDistrictDTO addDistrictDTO)
		{
			addDistrictDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{
				if (addDistrictDTO.AddDistrictId == null)
				{
					var a = _addDistrictService.AddDistrictCreate(addDistrictDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/AddDistrict/AddDistrictView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "AddDistrict Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _addDistrictService.AddDistrictUpdate(addDistrictDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/AddDistrict/AddDistrictView");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "AddDistrict Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}

			return View("~/Plugins/Warehouse.Management/Views/District/AddDistrictCreate.cshtml", addDistrictDTO);

		}

		public IActionResult AddDistrictView()
		{
			ViewBag.AddDistricts = _addDistrictService.GetAddDistrictList();

			return View("~/Plugins/Warehouse.Management/Views/District/AddDistrictView.cshtml");
		}

		[HttpGet]
		public IActionResult AddDistrictDelete(Int64 AddDistrictId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _addDistrictService.AddDistrictDelete(AddDistrictId, DeletedBy);
			return Redirect("/WareHouse/AddDistrict/AddDistrictView");
		}
	}
}
