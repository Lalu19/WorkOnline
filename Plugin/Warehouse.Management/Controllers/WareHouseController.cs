using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class WareHouseController : BasePluginController
    {
        private readonly IWareHouseService _wareHouseService;
        public WareHouseController(IWareHouseService wareHouseService)
        {
            _wareHouseService = wareHouseService;
        }

        [HttpGet]
        public IActionResult WareHouseCreate(int? wareHuoseId)
        {
            WareHouseDTO ware = new WareHouseDTO();
            if (wareHuoseId != null)
            {

                WareHuose W = _wareHouseService.GetWareHousebyWareHuoseId(int.Parse(wareHuoseId.ToString()));
                ware.WareHouseName = W.WareHouseName;
                ware.IsActive = W.IsActive;
                ware.Area = W.Area;
                ware.Address = W.Address;
                ware.Telephone = W.Telephone;
                ware.Mobile = W.Mobile;
                ware.GSTNumber = W.GSTNumber;

                //ware.Lat = d.Lat;
                //ware.Long = d.Long;
                //ware.IsActive = d.IsActive;

            }

            return View("~/Plugins/Warehouse.Management/Views/WareHouse/WareHouseCreate.cshtml", ware);
        }


        [HttpPost]
        public IActionResult WareHouseCreate(WareHouseDTO wareHouseDTO)
        {
            wareHouseDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


            if (ModelState.IsValid)
            {
                if (wareHouseDTO.WareHuoseId == null)
                {
                    var a = _wareHouseService.WareHouseCreate(wareHouseDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/WareHouse/WareHouseView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "WareHouse Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _wareHouseService.WareHouseUpdate(wareHouseDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/WareHouse/WareHouseView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "WareHouse Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            return View("~/Plugins/Warehouse.Management/Views/WareHouse/WareHouseCreate.cshtml", wareHouseDTO);
        }


        [HttpGet]
        public IActionResult WareHouseView()
        {
            ViewBag.pins = _wareHouseService.GetWareHouseList();

            return View("~/Plugins/Warehouse.Management/Views/WareHouse/WareHouseView.cshtml");
        }



        [HttpGet]
        public IActionResult DeleteWareHouse(Int64 WareHuoseId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _wareHouseService.WareHouseDelete(WareHuoseId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/WareHouse/WareHouseView");
        }

    }
}
