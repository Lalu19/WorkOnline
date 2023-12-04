using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Domain.WareHouses.Vendors;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using CloudVOffice.Services.WareHouses.Vendors;
using CloudVOffice.Web.Framework.Controllers;
using CloudVOffice.Web.Framework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Services.WareHouses.HandlingTypes;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Data.DTO.WareHouses.HandlingTypes;

namespace Warehouse.Management.Controllers
{
   
        [Area(AreaNames.WareHouse)]
        public class HandlingTypeController : BasePluginController
        {
            private readonly IHandlingTypeService _handlingtypeService;
            public HandlingTypeController(IHandlingTypeService handlingtypeService)
            {
                _handlingtypeService = handlingtypeService;
            }
            [HttpGet]
            [Authorize(Roles = "WareHouse Manager")]
            public IActionResult HandlingTypeCreate(int? handlingtypeId)
            {
                HandlingTypeDTO handlingtypeDTO = new HandlingTypeDTO();
                if (handlingtypeId != null)
                {

                    HandlingType d = _handlingtypeService.GetHandlingTypeByHandlingTypeId(int.Parse(handlingtypeId.ToString()));
                    handlingtypeDTO.HandlingTypeName = d.HandlingTypeName;
                    

                }

                return View("~/Plugins/Warehouse.Management/Views/HandlingType/HandlingTypeCreate.cshtml", handlingtypeDTO);

            }
            [HttpPost]
            [Authorize(Roles = "WareHouse Manager")]
            public IActionResult HandlingTypeCreate(HandlingTypeDTO handlingtypeDTO)
            {
                handlingtypeDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


                if (ModelState.IsValid)
                {
                    if (handlingtypeDTO.HandlingTypeId == null)
                    {
                        var a = _handlingtypeService.HandlingTypeCreate(handlingtypeDTO);
                        if (a == MessageEnum.Success)
                        {
                            TempData["msg"] = MessageEnum.Success;
                            return Redirect("/WareHouse/HandlingType/HandlingTypeView");
                        }
                        else if (a == MessageEnum.Duplicate)
                        {

                            TempData["msg"] = MessageEnum.Duplicate;
                            ModelState.AddModelError("", "HandlingType Already Exists");
                        }
                        else
                        {
                            TempData["msg"] = MessageEnum.UnExpectedError;
                            ModelState.AddModelError("", "Un-Expected Error");
                        }
                    }
                    else
                    {
                        var a = _handlingtypeService.HandlingTypeUpdate(handlingtypeDTO);
                        if (a == MessageEnum.Updated)
                        {
                            TempData["msg"] = MessageEnum.Updated;
                            return Redirect("/WareHouse/HandlingType/HandlingTypeView");
                        }
                        else if (a == MessageEnum.Duplicate)
                        {
                            TempData["msg"] = MessageEnum.Duplicate;
                            ModelState.AddModelError("", "HandlingType Already Exists");
                        }
                        else
                        {
                            TempData["msg"] = MessageEnum.UnExpectedError;
                            ModelState.AddModelError("", "Un-Expected Error");
                        }
                    }
                }
                return View("~/Plugins/Warehouse.Management/Views/HandlingType/HandlingTypeCreate.cshtml", handlingtypeDTO);
            }



            [Authorize(Roles = "WareHouse Manager")]
            public IActionResult HandlingTypeView()
            {
                ViewBag.handlingtypes = _handlingtypeService.GetHandlingTypeList();

                return View("~/Plugins/Warehouse.Management/Views/HandlingType/HandlingTypeView.cshtml");
            }


            [HttpGet]
            [Authorize(Roles = "WareHouse Manager")]
            public IActionResult DeletePin(Int64 handlingtypeId)
            {
                Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

                var a = _handlingtypeService.HandlingTypeDelete(handlingtypeId, DeletedBy);
                TempData["msg"] = a;
                return Redirect("/WareHouse/Vendor/VendorView");
            }

        }
 }

