using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Web.Framework.Controllers;
using CloudVOffice.Web.Framework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Services.WareHouses.GSTs;
using CloudVOffice.Data.DTO.WareHouses.GSTs;
using CloudVOffice.Core.Domain.WareHouses.GST;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class GSTController : BasePluginController
    {
            private readonly IGSTService _gstService;
            public GSTController(IGSTService gstService)
            {
                _gstService = gstService;
            }
            [HttpGet]
            public IActionResult GSTCreate(Int64? GSTId)
            {

                GSTDTO gstDTO = new GSTDTO();
                if (GSTId != null)
                {

                    GST d = _gstService.GetGSTByGSTId(int.Parse(GSTId.ToString()));

                    gstDTO.GSTValue = d.GSTValue;
                }
                return View("~/Plugins/Warehouse.Management/Views/GST/GSTCreate.cshtml", gstDTO);
            }

            [HttpPost]
            public IActionResult GSTCreate(GSTDTO gstDTO)
            {
                gstDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

                if (ModelState.IsValid)
                {
                    if (gstDTO.GSTId == null)
                    {
                        var a = _gstService.GSTCreate(gstDTO);

                        if (a == MessageEnum.Success)
                        {
                            TempData["msg"] = MessageEnum.Success;
                            return Redirect("/WareHouse/GST/GSTView");
                        }
                        else if (a == MessageEnum.Duplicate)
                        {
                            TempData["msg"] = MessageEnum.Duplicate;
                            ModelState.AddModelError("", "GST Already Exists");
                        }
                        else
                        {
                            TempData["msg"] = MessageEnum.UnExpectedError;
                            ModelState.AddModelError("", "Un-Expected Error");
                        }
                    }
                    else
                    {
                        var a = _gstService.GSTUpdate(gstDTO);
                        if (a == MessageEnum.Updated)
                        {
                            TempData["msg"] = MessageEnum.Updated;
                            return Redirect("/WareHouse/GST/GSTView");

                        }
                        else if (a == MessageEnum.Duplicate)
                        {
                            TempData["msg"] = MessageEnum.Duplicate;
                            ModelState.AddModelError("", "GST Already Exists");
                        }
                        else
                        {
                            TempData["msg"] = MessageEnum.UnExpectedError;
                            ModelState.AddModelError("", "Un-Expected Error");
                        }
                    }
                }

                return View("~/Plugins/Warehouse.Management/Views/GST/GSTCreate.cshtml", gstDTO);

            }

            public IActionResult GSTView()
            {
                ViewBag.GSTs = _gstService.GetGSTList();

                return View("~/Plugins/Warehouse.Management/Views/GST/GSTView.cshtml");
            }

            [HttpGet]
            public IActionResult GSTDelete(Int64 GSTId)
            {
                Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

                var a = _gstService.GSTDelete(GSTId, DeletedBy);
                return Redirect("/WareHouse/GST/GSTView");
            }
    }
 }

