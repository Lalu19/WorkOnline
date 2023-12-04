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

namespace Warehouse.Management.Controllers
{
   
        [Area(AreaNames.WareHouse)]
        public class VendorController : BasePluginController
        {
            private readonly IVendorService _vendorService;
            public VendorController(IVendorService vendorService)
            {
                _vendorService = vendorService;
            }
            [HttpGet]
            [Authorize(Roles = "WareHouse Manager")]
            public IActionResult VendorCreate(int? vendorId)
            {
                VendorDTO vendorDTO = new VendorDTO();
                if (vendorId != null)
                {

                    Vendor d = _vendorService.GetVendorByVendorId(int.Parse(vendorId.ToString()));
                    vendorDTO.VendorName = d.VendorName;
                    vendorDTO.CompanyName = d.CompanyName;
                    vendorDTO.GST = d.GST;
                    vendorDTO.Address = d.Address;
                    vendorDTO.Telephone = d.Telephone;
                    vendorDTO.Mobile1 = d.Mobile1;
                    vendorDTO.Mobile2 = d.Mobile2;
                    vendorDTO.MailId = d.MailId;
                    vendorDTO.PoCName = d.PoCName;
                    vendorDTO.Segment = d.Segment;
                    vendorDTO.Category = d.Category;
                    vendorDTO.WarehousesAffiliated = d.WarehousesAffiliated;
                    vendorDTO.IsActive = d.IsActive;

                }

                return View("~/Plugins/Warehouse.Management/Views/Vendor/VendorCreate.cshtml", vendorDTO);

            }
            [HttpPost]
            [Authorize(Roles = "WareHouse Manager")]
            public IActionResult VendorCreate(VendorDTO vendorDTO)
            {
                vendorDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


                if (ModelState.IsValid)
                {
                    if (vendorDTO.VendorId == null)
                    {
                        var a = _vendorService.VendorCreate(vendorDTO);
                        if (a == MessageEnum.Success)
                        {
                            TempData["msg"] = MessageEnum.Success;
                            return Redirect("/WareHouse/Vendor/VendorView");
                        }
                        else if (a == MessageEnum.Duplicate)
                        {

                            TempData["msg"] = MessageEnum.Duplicate;
                            ModelState.AddModelError("", "Vendor Already Exists");
                        }
                        else
                        {
                            TempData["msg"] = MessageEnum.UnExpectedError;
                            ModelState.AddModelError("", "Un-Expected Error");
                        }
                    }
                    else
                    {
                        var a = _vendorService.VendorUpdate(vendorDTO);
                        if (a == MessageEnum.Updated)
                        {
                            TempData["msg"] = MessageEnum.Updated;
                            return Redirect("/WareHouse/Vendor/VendorView");
                        }
                        else if (a == MessageEnum.Duplicate)
                        {
                            TempData["msg"] = MessageEnum.Duplicate;
                            ModelState.AddModelError("", "Vendor Already Exists");
                        }
                        else
                        {
                            TempData["msg"] = MessageEnum.UnExpectedError;
                            ModelState.AddModelError("", "Un-Expected Error");
                        }
                    }
                }
                return View("~/Plugins/Warehouse.Management/Views/Vendor/VendorCreate.cshtml", vendorDTO);
            }



            [Authorize(Roles = "WareHouse Manager")]
            public IActionResult VendorView()
            {
                ViewBag.vendors = _vendorService.GetVendorList();

                return View("~/Plugins/Warehouse.Management/Views/Vendor/VendorView.cshtml");
            }


            [HttpGet]
            [Authorize(Roles = "WareHouse Manager")]
            public IActionResult DeletePin(Int64 vendorId)
            {
                Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

                var a = _vendorService.VendorDelete(vendorId, DeletedBy);
                TempData["msg"] = a;
                return Redirect("/WareHouse/Vendor/VendorView");
            }

        }
    }

