using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Services.ProductCategories;
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
	public class SubCategory4Controller : BasePluginController
	{
		private readonly ISubCategory4Service _subcategory4Service;
		private readonly ISubCategory3Service _subcategory3Service;
		private readonly ISubCategory2Service _subcategory2Service;
		private readonly ISubCategory1Service _subcategory1Service;
		private readonly ISectorService _sectorService;
		public SubCategory4Controller(ISubCategory2Service subcategory2Service, ISubCategory1Service subcategory1Service, ISectorService sectorService, ISubCategory3Service subcategory3Service, ISubCategory4Service subcategory4Service)
		{
			_subcategory2Service = subcategory2Service;
			_subcategory1Service = subcategory1Service;
			_sectorService = sectorService;
			_subcategory3Service = subcategory3Service;
			_subcategory4Service = subcategory4Service;
		}
		[HttpGet]
		public IActionResult SubCategory4Create(int? SubCategory4Id)
		{
			ViewBag.SectorList = _sectorService.GetSectorList();
			ViewBag.SubCategories3 = _subcategory3Service.GetSubCategory3List();
			ViewBag.SubCategories2 = _subcategory2Service.GetSubCategory2List();
			ViewBag.subcategory1List = _subcategory1Service.GetSubCategory1List();
			SubCategory4DTO subcategory4DTO = new SubCategory4DTO();

			if (SubCategory4Id != null)
			{
				SubCategory4 d = _subcategory4Service.GetSubCategory4ById(int.Parse(SubCategory4Id.ToString()));

				subcategory4DTO.SectorId = d.SectorId;
				subcategory4DTO.CategoryId = d.CategoryId;
				subcategory4DTO.SubCategory1Id = d.SubCategory1Id;
				subcategory4DTO.SubCategory2Id = d.SubCategory2Id;
				subcategory4DTO.SubCategory3Id=d.SubCategory3Id;
				subcategory4DTO.SubCategory4Name = d.SubCategory4Name;

			}
			return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory4Create.cshtml", subcategory4DTO);
		}
		[HttpPost]
		public IActionResult SubCategory4Create(SubCategory4DTO subcategory4DTO)
		{
			subcategory4DTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
			if (ModelState.IsValid)
			{
				if (subcategory4DTO.SubCategory4Id == null)
				{
					var a = _subcategory4Service.SubCategory4Create(subcategory4DTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/SubCategory4/SubCategory4View");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "SubCategory Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _subcategory4Service.SubCategory4Update(subcategory4DTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/SubCategory4/SubCategory4View");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "SubCategory Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
			ViewBag.SectorList = _sectorService.GetSectorList();
			ViewBag.SubCategories3 = _subcategory3Service.GetSubCategory3List();
			ViewBag.SubCategories2 = _subcategory2Service.GetSubCategory2List();
			ViewBag.subcategory1List = _subcategory1Service.GetSubCategory1List();
			return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory4Create.cshtml", subcategory4DTO);

		}
		public IActionResult SubCategory4View()
		{
			ViewBag.SubCategories4 = _subcategory4Service.GetSubCategory4List();

			return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory4View.cshtml");
		}

		[HttpGet]
		public IActionResult DeleteSubCategory4(int SubCategory4Id)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _subcategory4Service.DeleteSubCategory4(SubCategory4Id, DeletedBy);
			return Redirect("/WareHouse/SubCategory4/SubCategory4View");
		}

		public JsonResult GetSubCategory4BySubCategory3Id(int SubCategory3Id)
		{
			return Json(_subcategory4Service.GetSubCategory4BySubCategory3Id(SubCategory3Id));
		}
	}
}
