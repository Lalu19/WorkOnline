using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sales;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.Months;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesExecutive.Controllers
{
    [Area(AreaNames.SalesExecutive)]
    public class SalesManagerTargetController : BasePluginController
    {
        private readonly ISalesManagerTargetService _salesManagerTargetService;
        private readonly ISectorService _sectorService;
        private readonly ICategoryService _categoryService;
        private readonly IMonthService _monthService;
		private readonly IBrandService _brandService;


		public SalesManagerTargetController(ISalesManagerTargetService salesManagerTargetService, ISectorService sectorService, ICategoryService categoryService, IMonthService monthService, IBrandService brandService)
        {
            _salesManagerTargetService = salesManagerTargetService;
            _sectorService = sectorService;
            _categoryService = categoryService;
            _monthService = monthService;
			_brandService= brandService;

		}



        [HttpGet]
        public IActionResult CreateSalesManagerTargets(int? salesManagerTargetId)
        {
			ViewBag.Brands = _brandService.GetBrandList();
			ViewBag.Sectors = _sectorService.GetSectorList();
            ViewBag.Categories = _categoryService.GetCategoryList();
            ViewBag.months = _monthService.GetMonthList();

            SalesManagerTargetDTO salesManagerTargetDTO = new SalesManagerTargetDTO();

            if (salesManagerTargetId != null)
            {
                var target = _salesManagerTargetService.GetSalesManagerTargetBySalesManagerTargetId(int.Parse(salesManagerTargetId.ToString()));

               //salesManagerTargetDTO.SalesAdminTargetName = target.SalesAdminTargetName;
                salesManagerTargetDTO.MonthId = target.MonthId;
                salesManagerTargetDTO.SectorId = target.SectorId;
                salesManagerTargetDTO.CategoryId = target.CategoryId;
                salesManagerTargetDTO.MonthlyCategoryWiseTarget = target.MonthlyCategoryWiseTarget;
                salesManagerTargetDTO.MonthlySectorWiseTargetByAdmin = target.MonthlySectorWiseTargetByAdmin;
                salesManagerTargetDTO.MonthlyBrandWiseTarget = target.MonthlyBrandWiseTarget;
                //salesManagerTargetDTO.UnitId = target.UnitId;
                //salesAdminDTO.Districts = target.Districts;

            }

            return View("~/Plugins/SalesExecutive/Views/SalesManagerTargets/SalesManagerTargetCreate.cshtml", salesManagerTargetDTO);
        }


        


        [HttpPost]
        public IActionResult CreateSalesManagerTargets([FromBody] SalesManagerTargetMasterDTO model)
        {
            foreach (var target in model.Targets)
            {
                target.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

                if (target.SalesManagerTargetId == null)
                {
                    // It's a new target, create it
                    var result = _salesManagerTargetService.CreateSalesManagerTarget(target);

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
                    var result = _salesManagerTargetService.UpdateTargetsBySalesManagerTarget(target);

                    // Handle the result accordingly
                    if (result == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SalesExecutive/SalesManagerTarget/SalesManagerTargetView");
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



            ViewBag.SalesTarget = _salesManagerTargetService.GetAllTargetsBySalesManagerTarget();
            // Redirect or return the appropriate view
            //return Redirect("/SalesExecutive/SalesAdmin/SalesAdminTargetView");

            return View("~/Plugins/SalesExecutive/Views/SalesManagerTargets/SalesManagerTargetView.cshtml", ViewBag.SalesTarget);
        }



        public IActionResult SalesManagerTargetView()

        {
            ViewBag.SalesTarget = _salesManagerTargetService.GetAllTargetsBySalesManagerTarget();

            return View("~/Plugins/SalesExecutive/Views/SalesManagerTargets/SalesManagerTargetView.cshtml");
        }


        [HttpGet]
        public IActionResult SalesManagerTargetDelete(int SalesManagerTargetId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _salesManagerTargetService.DeleteTargetsBySalesManagerTarget(SalesManagerTargetId, DeletedBy);
            return Redirect("/SalesExecutive/SalesManagerTarget/SalesManagerTargetView");
        }


        public string GetCategoryIdByName(string categoryName)
        {
            var a = _salesManagerTargetService.GetCategoryIdByName(categoryName);
            return a;
        }

        public Int64 GetMonthIdByName(string monthName)
        {
            var a = _monthService.GetMonthIdByName(monthName);
            return a;
        }
		public List<Brand> BrandsBySectorId(Int64 sectorId)
		{
			var brands = _brandService.GetBrandsBySectorId(sectorId);
			var uniqueBrands = brands.GroupBy(b => b.BrandId).Select(g => g.First()).ToList();

			return uniqueBrands;
		}

		public Int64 GetBrandIdByName(string brandName)
		{
			var a = _brandService.GetBrandIdByBrandName(brandName);
			return a;
		}
	}
}
