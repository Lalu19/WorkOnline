using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Data.DTO.WareHouses.UOMs;
using CloudVOffice.Services.WareHouses.UOMs;
using CloudVOffice.Web.Framework.Controllers;
using CloudVOffice.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class UnitConversionFactorsController : BasePluginController
    {
        private readonly IUnitConversionFactors _unitConversionFactorsService;
        private readonly IUnit _unitService;
        public UnitConversionFactorsController(IUnitConversionFactors unitConversionFactorsService, IUnit unitService)
        {
            _unitConversionFactorsService = unitConversionFactorsService;
            _unitService = unitService;
        }
        [HttpGet]
        public IActionResult UnitConversionFactorsCreate(Int64? UnitConversionFactorsId)
        {
            UnitConversionFactorsDTO unitConversionFactorsDTO = new UnitConversionFactorsDTO();
            var Unit = _unitService.GetUnit();
            ViewBag.unit = Unit;
            if (UnitConversionFactorsId != null)
            {
                var a = _unitConversionFactorsService.GetUnitConversionFactorsByUnitConversionFactorsId(int.Parse(UnitConversionFactorsId.ToString()));
                unitConversionFactorsDTO.FromUnitId = a.FromUnitId;
                unitConversionFactorsDTO.ToUnitId = a.ToUnitId;
                unitConversionFactorsDTO.Value = a.Value;
            }
            return View("~/Plugins/Warehouse.Management/Views/UnitConversionFactors/UnitConversionFactorsCreate.cshtml", unitConversionFactorsDTO);
        }
        [HttpPost]
        public IActionResult UnitConversionFactorsCreate(UnitConversionFactorsDTO unitConversionFactorsDTO)
        {
            unitConversionFactorsDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


            if (ModelState.IsValid)
            {
                if (unitConversionFactorsDTO.UnitConversionFactorsId == null)
                {
                    var a = _unitConversionFactorsService.UnitConversionFactorsCreate(unitConversionFactorsDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/Warehouse/UnitConversionFactors/UnitConversionFactorsView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "UnitConversionFactors Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _unitConversionFactorsService.UnitConversionFactorsUpdate(unitConversionFactorsDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/UnitConversionFactors/UnitConversionFactorsView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "UnitConversionFactors Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            var Unit = _unitService.GetUnit();
            ViewBag.unit = Unit;
            return View("~/Plugins/Warehouse.Management/Views/UnitConversionFactors/UnitConversionFactorsCreate.cshtml", unitConversionFactorsDTO);
        }
        public IActionResult UnitConversionFactorsView()
        {
            ViewBag.UnitConversionFactors = _unitConversionFactorsService.GetUnitConversionFactors();

            return View("~/Plugins/Warehouse.Management/Views/UnitConversionFactors/UnitConversionFactorsView.cshtml");
        }

        [HttpGet]
        public IActionResult UnitConversionFactorsDelete(int UnitConversionFactorsId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _unitConversionFactorsService.UnitConversionFactorsDelete(UnitConversionFactorsId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/UnitConversionFactors/UnitConversionFactorsView");
        }
    }
}
