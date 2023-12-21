using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class PinCodeController :BasePluginController
    {
        private readonly IPinCodeService _pinCodeService;
        public PinCodeController(IPinCodeService pinCodeService)
        {
            _pinCodeService = pinCodeService;
        }

        [HttpGet]
		//[Authorize(Roles = "WareHouse Manager")]
		public IActionResult PinCodeCreate(int? pinCodeId)
        {
            PinCodeDTO pinCodeDTO = new PinCodeDTO();
            if (pinCodeId != null)
            {

                PinCode d = _pinCodeService.GetPinByPinCodeId(int.Parse(pinCodeId.ToString()));
                pinCodeDTO.Pin = d.Pin;
                pinCodeDTO.Lat = d.Lat;
                pinCodeDTO.Long = d.Long;
                pinCodeDTO.IsActive=d.IsActive;

            }

            return View("~/Plugins/Warehouse.Management/Views/PinCode/PinCodeCreate.cshtml", pinCodeDTO);

        }
         
        [HttpPost]
		//[Authorize(Roles = "WareHouse Manager")]
		public IActionResult PinCodeCreate(PinCodeDTO pinCodeDTO)
        {
            pinCodeDTO.CreatedBy  = (int) Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


            if (ModelState.IsValid)
            {
                if (pinCodeDTO.PinCodeId == null)
                {
                    var a = _pinCodeService.PinCodeCreate(pinCodeDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/PinCode/PinCodeView");
                    }
                    else if (a == MessageEnum.Duplicate)
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
                    var a = _pinCodeService.PinUpdate(pinCodeDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/PinCode/PinCodeView");
                    }
                    else if (a == MessageEnum.Duplicate)
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
            return View("~/Plugins/Warehouse.Management/Views/PinCode/PinCodeCreate.cshtml", pinCodeDTO);
        }



        //[Authorize(Roles = "WareHouse Manager")]
        public IActionResult PinCodeView()
        {
            ViewBag.pins = _pinCodeService.GetPinList();

            return View("~/Plugins/Warehouse.Management/Views/PinCode/PinCodeView.cshtml");
        }


        [HttpGet]
        //[Authorize(Roles = "WareHouse Manager")]
        public IActionResult DeletePin(Int64 pinCodeId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _pinCodeService.PinDelete(pinCodeId,DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/PinCode/PinCodeView");
        }

    }
}
