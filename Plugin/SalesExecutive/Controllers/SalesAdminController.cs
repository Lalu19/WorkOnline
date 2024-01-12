using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Services.Sales;
using CloudVOffice.Web.Framework.Controllers;
using CloudVOffice.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using Microsoft.AspNetCore.Authorization;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Months;
using CloudVOffice.Core.Domain.Sales;

namespace SalesExecutive.Controllers
{
	[Area(AreaNames.SalesExecutive)]
	public class SalesAdminController : BasePluginController
	{
		private readonly ISalesAdminService _salesAdminService;
		private readonly ISectorService _sectorService;
		private readonly ICategoryService _categoryService;
		private readonly IMonthService _monthService;
		

		public SalesAdminController(ISalesAdminService salesAdminService, ISectorService sectorService, ICategoryService categoryService,IMonthService monthService)
		{
			_salesAdminService = salesAdminService;
			_sectorService = sectorService;
			_categoryService = categoryService;
			_monthService = monthService;
		}



		[HttpGet]
		public IActionResult CreateTargetBySalesAdmin(int? salesAdminTargetId)
		{

			ViewBag.Sectors = _sectorService.GetSectorList();
			ViewBag.Categories = _categoryService.GetCategoryList();
			ViewBag.months = _monthService.GetMonthList();

			SalesAdminDTO salesAdminDTO = new SalesAdminDTO();

			if (salesAdminTargetId != null)
			{
				var target = _salesAdminService.GetSalesAdminTargetBySalesAdminId(int.Parse(salesAdminTargetId.ToString()));

				salesAdminDTO.SalesAdminTargetName = target.SalesAdminTargetName;
				salesAdminDTO.MonthId = target.MonthId;
				salesAdminDTO.SectorId = target.SectorId;
				salesAdminDTO.CategoryId = target.CategoryId;
				salesAdminDTO.MonthlyCategoryWiseTarget = target.MonthlyCategoryWiseTarget;
				salesAdminDTO.MonthlySectorWiseTarget = target.MonthlySectorWiseTarget;
				salesAdminDTO.MonthlyBrandWiseTarget = target.MonthlyBrandWiseTarget;
				salesAdminDTO.UnitId = target.UnitId;
				//salesAdminDTO.Districts = target.Districts;

			}

			return View("~/Plugins/SalesExecutive/Views/SalesAdmins/SalesAdminCreate.cshtml", salesAdminDTO);
		}


		//[HttpPost]
		//public IActionResult CreateTargetBySalesAdmin(SalesAdminTargetMasterDTO Targets)
		//{

		//[HttpPost]
		//public IActionResult CreateTargetBySalesAdmin([FromBody] SalesAdminTargetMasterDTO model)
		//{

		//	//model.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

		//	SalesAdminTarget 

		//	foreach(var target in model.Targets)
		//	{

		//	}



		//	if (salesAdminDTO.SalesAdminTargetId == null)
		//	{
		//		var a = _salesAdminService.CreateTargetsBySalesAdmin(salesAdminDTO);
		//		if (a == MessageEnum.Success)
		//		{
		//			TempData["msg"] = MessageEnum.Success;
		//			return Redirect("/SalesExecutive/SalesAdmin/SalesAdminTargetView");
		//		}
		//		else if (a == MessageEnum.Duplicate)
		//		{

		//			TempData["msg"] = MessageEnum.Duplicate;
		//			ModelState.AddModelError("", "PinCode Already Exists");
		//		}
		//		else
		//		{
		//			TempData["msg"] = MessageEnum.UnExpectedError;
		//			ModelState.AddModelError("", "Un-Expected Error");
		//		}
		//	}
		//	else
		//	{
		//		var a = _salesAdminService.UpdateTargetsBySalesAdmin(salesAdminDTO);
		//		if (a == MessageEnum.Updated)
		//		{
		//			TempData["msg"] = MessageEnum.Updated;
		//			return Redirect("/SalesExecutive/SalesAdmin/SalesAdminTargetView");
		//		}
		//		else if (a == MessageEnum.Duplicate)
		//		{
		//			TempData["msg"] = MessageEnum.Duplicate;
		//			ModelState.AddModelError("", "PinCode Already Exists");
		//		}
		//		else
		//		{
		//			TempData["msg"] = MessageEnum.UnExpectedError;
		//			ModelState.AddModelError("", "Un-Expected Error");
		//		}
		//	}

		//	//return View("~/Plugins/SalesExecutive/Views/SalesAdmins/SalesAdminCreate.cshtml", salesAdminDTO);

		//	return View("~/Plugins/SalesExecutive/Views/SalesAdmins/SalesAdminCreate.cshtml");
		//}


		[HttpPost]
		public IActionResult CreateTargetBySalesAdmin([FromBody] SalesAdminTargetMasterDTO model)
		{
			foreach (var target in model.Targets)
			{
				target.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

				if (target.SalesAdminTargetId == null)
				{
					// It's a new target, create it
					var result = _salesAdminService.CreateTargetsBySalesAdmin(target);

					// Handle the result accordingly
					if (result == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
					}
					else if (result == MessageEnum.Duplicate)
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
					// It's an existing target, update it
					var result = _salesAdminService.UpdateTargetsBySalesAdmin(target);

					// Handle the result accordingly
					if (result == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/SalesExecutive/SalesAdmin/SalesAdminTargetView");
					}
					else if (result == MessageEnum.Duplicate)
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



			//ViewBag.SalesTarget = _salesAdminService.GetAllTargetsBySalesAdmin();
			// Redirect or return the appropriate view
			return Redirect("/SalesExecutive/SalesAdmin/SalesAdminTargetView");

			//return View("~/Plugins/SalesExecutive/Views/SalesAdmins/SalesAdminView.cshtml", ViewBag.SalesTarget);
		}



		public IActionResult SalesAdminTargetView()
		
		{
			ViewBag.SalesTarget = _salesAdminService.GetAllTargetsBySalesAdmin();

			return View("~/Plugins/SalesExecutive/Views/SalesAdmins/SalesAdminView.cshtml");
		}


        [HttpGet]
        public IActionResult SalesAdminTargetDelete(int SalesAdminTargetId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _salesAdminService.DeleteTargetsBySalesAdmin(SalesAdminTargetId, DeletedBy);
            return Redirect("/SalesExecutive/SalesAdmin/SalesAdminTargetView");
        }


		public string GetCategoryIdByName(string categoryName)
		{
			var a = _salesAdminService.GetCategoryIdByName(categoryName);
			return a;
		}

		public Int64 GetMonthIdByName(string monthName)
		{
			var a = _monthService.GetMonthIdByName(monthName);
			return a;
		}

	}
}
