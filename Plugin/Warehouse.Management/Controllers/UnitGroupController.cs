using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.WareHouses.UOMs;
using CloudVOffice.Services.WareHouses.UOMs;
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
    public class UnitGroupController : BasePluginController
    {
        private readonly IUnitGroup _UnitGroupService;
        public UnitGroupController(IUnitGroup UnitGroupService)
        {

            _UnitGroupService = UnitGroupService;
        }
        [HttpGet]
        public IActionResult UnitGroupCreate(int? unitgroupId)
        {
            UnitGroupDTO unitGroupDTO = new UnitGroupDTO();

            if (unitgroupId != null)
            {

                var d = _UnitGroupService.GetUnitGroupByGetUnitGroupId(int.Parse(unitgroupId.ToString()));
                unitGroupDTO.UnitGroupName = d.UnitGroupName;

            }

            return View("~/Plugins/Warehouse.Management/Views/UnitGroup/UnitGroupCreate.cshtml", unitGroupDTO);

        }
        [HttpPost]
        public IActionResult UnitGroupCreate(UnitGroupDTO unitGroupDTO)
        {
            unitGroupDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


            if (ModelState.IsValid)
            {
                if (unitGroupDTO.UnitGroupId == null)
                {
                    var a = _UnitGroupService.UnitGroupCreate(unitGroupDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/UnitGroup/UnitGroupView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "CustomerGroup Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _UnitGroupService.UnitGroupUpdate(unitGroupDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/UnitGroup/UnitGroupView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "UnitGroup Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            return View("~/Plugins/Warehouse.Management/Views/UnitGroup/UnitGroupCreate.cshtml", unitGroupDTO);
        }

        public IActionResult UnitGroupView()
        {
            ViewBag.UnitGroup = _UnitGroupService.GetUnitGroup();

            return View("~/Plugins/Warehouse.Management/Views/UnitGroup/UnitGroupView.cshtml");
        }
        [HttpGet]
        public IActionResult UnitGroupDelete(int unitgroupId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _UnitGroupService.UnitGroupDelete(unitgroupId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/UnitGroup/UnitGroupView");
        }
    }
}
