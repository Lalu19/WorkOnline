using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sales;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.Months;
using CloudVOffice.Services.WareHouses.UOMs;
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
    public class BrandWiseTargetController : BaseController
    {
        private readonly IBrandWiseTargetService _brandWiseTargetService;
        private readonly ISectorService _sectorService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly IMonthService _monthService;
        private readonly IUnit _unitService;


        public BrandWiseTargetController(IBrandWiseTargetService brandWiseTargetService,
                                         ISectorService sectorService,
                                         ICategoryService categoryService,
                                         IBrandService brandService,
                                         IMonthService monthService,
                                         IUnit unitService
                                        )
        {
            _brandWiseTargetService = brandWiseTargetService;
            _sectorService = sectorService;
            _categoryService = categoryService;
            _brandService = brandService;
            _monthService = monthService;
            _unitService = unitService;
        }

        [HttpGet]
        public IActionResult BrandWiseTargetCreate(int? brandWiseTargetId)
        {

            ViewBag.Sectors = _sectorService.GetSectorList();
            ViewBag.Categories = _categoryService.GetCategoryList();
            ViewBag.Brands = _brandService.GetBrandList();
            ViewBag.Months = _monthService.GetMonthList();
            ViewBag.Units= _unitService.GetUnit();

            BrandWiseTargetDTO brandWiseTargetDTO = new BrandWiseTargetDTO();

            if (brandWiseTargetId != null)
            {
                var target = _brandWiseTargetService.GetBrandWiseTargetById(int.Parse(brandWiseTargetId.ToString()));

                brandWiseTargetDTO.SectorId = target.SectorId;
                brandWiseTargetDTO.CategoryId = target.CategoryId;
                brandWiseTargetDTO.BrandId =target.BrandId;
                brandWiseTargetDTO.MonthId = target.MonthId;
                brandWiseTargetDTO.UnitId = target.UnitId;
                brandWiseTargetDTO.MonthlyBrandWiseTarget = target.MonthlyBrandWiseTarget;

            }

            return View("~/Plugins/SalesExecutive/Views/BrandWiseTargets/BrandWiseTargetCreate.cshtml", brandWiseTargetDTO);
        }

        [HttpPost]
        public IActionResult BrandWiseTargetCreate([FromBody] BrandWiseTargetMasterDTO model)
        {
            foreach (var target in model.Targetss)
            {
                target.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

                if (target.BrandWiseTargetId == null)
                {

                    var result = _brandWiseTargetService.BrandWiseTargetCreate(target);

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
                    var result = _brandWiseTargetService.BrandWiseTargetUpdate(target);

                    if (result == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SalesExecutive/BrandWiseTarget/BrandWiseTargetView");
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

            ViewBag.BrandTarget = _brandWiseTargetService.GetBrandWiseTargetList();

            return View("~/Plugins/SalesExecutive/Views/BrandWiseTargets/BrandWiseTargetView.cshtml");
        }

        public IActionResult BrandWiseTargetView()

        {
            ViewBag.BrandTarget = _brandWiseTargetService.GetBrandWiseTargetList();

            return View("~/Plugins/SalesExecutive/Views/BrandWiseTargets/BrandWiseTargetView.cshtml");
        }

        [HttpGet]
        public IActionResult BrandWiseTargetDelete(int BrandWiseTargetId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _brandWiseTargetService.BrandWiseTargetDelete(BrandWiseTargetId, DeletedBy);
            return Redirect("/SalesExecutive/BrandWiseTarget/BrandWiseTargetView");
        }


    }
}
