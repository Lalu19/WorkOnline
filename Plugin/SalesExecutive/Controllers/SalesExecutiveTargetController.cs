using CloudVOffice.Core.Domain.Common;
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
    public class SalesExecutiveTargetController : BasePluginController
    {
        private readonly ISalesExecutiveTargetService _salesExecutiveTargetService;
        private readonly ISectorService _sectorService;
        private readonly ICategoryService _categoryService;
        private readonly IMonthService _monthService;
        private readonly IBrandService _brandService;
        private readonly ISalesExecutiveRegistrationService _salesExecutiveRegistrationService;


        public SalesExecutiveTargetController(
                                              ISalesExecutiveTargetService salesExecutiveTargetService,
                                              ISectorService sectorService,
                                              ICategoryService categoryService,
                                              IMonthService monthService,
                                              IBrandService brandService,
                                              ISalesExecutiveRegistrationService salesExecutiveRegistrationService)
        {
            _salesExecutiveTargetService = salesExecutiveTargetService;
            _sectorService = sectorService;
            _categoryService = categoryService;
            _monthService = monthService;
            _brandService = brandService;
            _salesExecutiveRegistrationService = salesExecutiveRegistrationService;
        }

        [HttpGet]
        public IActionResult CreateTargetBySalesExecutive(int? salesExecutiveTargetId)
        {

            ViewBag.Sectors = _sectorService.GetSectorList();
            //ViewBag.Categories = _categoryService.GetCategoryList();
            ViewBag.months = _monthService.GetMonthList();
            ViewBag.Brands = _brandService.GetBrandList();
            ViewBag.SalesExecutive = _salesExecutiveRegistrationService.GetAllSalesExecutiveRegistrations();

            SalesExecutiveDTO salesExecutiveDTO = new SalesExecutiveDTO();

            if (salesExecutiveTargetId != null)
            {
                var target = _salesExecutiveTargetService.GetSalesExecutiveTargetBySalesExecutiveId(int.Parse(salesExecutiveTargetId.ToString()));

                salesExecutiveDTO.SalesExecutiveRegistrationId = target.SalesExecutiveRegistrationId;
                salesExecutiveDTO.MonthId = target.MonthId;
                salesExecutiveDTO.SectorId = target.SectorId;
                salesExecutiveDTO.CategoryId = target.CategoryId;
                salesExecutiveDTO.MonthlyCategoryWiseTarget = target.MonthlyCategoryWiseTarget;
                salesExecutiveDTO.MonthlySectorWiseTarget = target.MonthlySectorWiseTarget;
                salesExecutiveDTO.MonthlyBrandWiseTarget = target.MonthlyBrandWiseTarget;

            }

            return View("~/Plugins/SalesExecutive/Views/SalesExecutiveTargets/SalesExecutiveTargetCreate.cshtml", salesExecutiveDTO);
        }


        [HttpPost]
        public IActionResult CreateTargetBySalesExecutive([FromBody] SalesExecutiveTargetMasterDTO model)
        {
            foreach (var target in model.Targets)
            {
                target.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

                if (target.SalesExecutiveTargetId == null)
                {
                    // It's a new target, create it
                    var result = _salesExecutiveTargetService.CreateTargetsBySalesExecutive(target);

                    // Handle the result accordingly
                    if (result == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                    }
                    else if (result == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Already Exists");
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
                    var result = _salesExecutiveTargetService.UpdateTargetsBySalesExecutive(target);

                    // Handle the result accordingly
                    if (result == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SalesExecutive/SalesExecutiveTarget/SalesExecutiveTargetView");
                    }
                    else if (result == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult SalesExecutiveTargetView()
        {
            ViewBag.SalesTarget = _salesExecutiveTargetService.GetAllTargetsBySalesExecutive();

            return View("~/Plugins/SalesExecutive/Views/SalesExecutiveTargets/SalesExecutiveTargetView.cshtml");
        }

        [HttpGet]
        public IActionResult SalesExecutiveTargetDelete(int SalesExecutiveTargetId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _salesExecutiveTargetService.DeleteTargetsBySalesExecutive(SalesExecutiveTargetId, DeletedBy);
            return Redirect("/SalesExecutive/SalesExecutiveTarget/SalesExecutiveTargetView");
        }

        public string GetCategoryIdByName(string categoryName)
        {
            var a = _salesExecutiveTargetService.GetCategoryIdByName(categoryName);
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
