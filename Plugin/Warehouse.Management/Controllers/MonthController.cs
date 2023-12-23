using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Services.WareHouses.Districts;
using CloudVOffice.Services.WareHouses.Months;
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
    public class MonthController : BasePluginController
    {
        private readonly IMonthService _monthService;

        public MonthController(IMonthService monthService)
        {
            _monthService = monthService;

        }
        [HttpGet]
        public IActionResult MonthCreate(Int64? MonthId)
        {


            MonthDTO monthDTO = new MonthDTO();
            if (MonthId != null)
            {

                Month d = _monthService.GetMonthById(int.Parse(MonthId.ToString()));

                monthDTO.MonthName = d.MonthName;
            }
            return View("~/Plugins/Warehouse.Management/Views/Month/MonthCreate.cshtml", monthDTO);
        }

        [HttpPost]
        public IActionResult MonthCreate(MonthDTO monthDTO)
        {
            monthDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (monthDTO.MonthId == null)
                {
                    var a = _monthService.MonthCreate(monthDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/Month/MonthView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Month Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _monthService.MonthUpdate(monthDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/Month/MonthView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Month Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            return View("~/Plugins/Warehouse.Management/Views/Month/MonthCreate.cshtml", monthDTO);

        }

        public IActionResult MonthView()
        {
            ViewBag.Months = _monthService.GetMonthList();

            return View("~/Plugins/Warehouse.Management/Views/Month/MonthView.cshtml");
        }

        [HttpGet]
        public IActionResult MonthDelete(Int64 MonthId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _monthService.MonthDelete(MonthId, DeletedBy);
            return Redirect("/WareHouse/Month/MonthView");
        }
    }
}
