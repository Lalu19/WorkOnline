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


    }
}
