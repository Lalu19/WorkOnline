using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class DamageItemForFarmingController : BasePluginController
    {
        private readonly IDamageItemForFarmingService _damageItemForFarmingService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IItemMasterForFarmingService _itemMasterForFarmingService;
        public DamageItemForFarmingController(IDamageItemForFarmingService damageItemForFarmingService,
                                              IWebHostEnvironment hostingEnvironment,
                                              IItemMasterForFarmingService itemMasterForFarmingService)
        {
            _damageItemForFarmingService = damageItemForFarmingService;
            _hostingEnvironment = hostingEnvironment;
            _itemMasterForFarmingService = itemMasterForFarmingService;
        }

        [HttpGet]
        public IActionResult DamageItemForFarmingCreate(Int64? damageItemForFarmingId)
        {
            ViewBag.ItemMasterFarmingList = _itemMasterForFarmingService.GetItemMasterForFarmingList(); 

            DamageItemForFarmingDTO damageItemForFarmingDTO = new DamageItemForFarmingDTO();

            if (damageItemForFarmingId != null)
            {
                DamageItemForFarming d = _damageItemForFarmingService.GetDamageItemForFarmingById(int.Parse(damageItemForFarmingId.ToString()));

                damageItemForFarmingDTO.ItemMasterForFarmingId = d.ItemMasterForFarmingId;
                damageItemForFarmingDTO.WareHouseName = d.WareHouseName;
                damageItemForFarmingDTO.EmployeeName = d.EmployeeName;
                damageItemForFarmingDTO.VendorName = d.VendorName;
                damageItemForFarmingDTO.DistrictName = d.DistrictName;
                damageItemForFarmingDTO.UnitId = d.UnitId;
                damageItemForFarmingDTO.ProductName = d.ProductName;
                damageItemForFarmingDTO.QtyPerKg = d.QtyPerKg;
                damageItemForFarmingDTO.Price = d.Price;
                damageItemForFarmingDTO.MinQty = d.MinQty;
                damageItemForFarmingDTO.GST = d.GST;
                damageItemForFarmingDTO.HSN = d.HSN;
                damageItemForFarmingDTO.HarvestDate = d.HarvestDate;
                damageItemForFarmingDTO.Reason = d.Reason;
                damageItemForFarmingDTO.DamagePic = d.DamagePic;
                damageItemForFarmingDTO.DamageUnits = d.DamageUnits;
                damageItemForFarmingDTO.InvoiceNo = d.InvoiceNo;
                damageItemForFarmingDTO.ReceivedDate = d.ReceivedDate;
              
            }
            return View("~/Plugins/Warehouse.Management/Views/Item/DamageItemForFarmingCreate.cshtml", damageItemForFarmingDTO);
        }

        [HttpPost]
        public IActionResult DamageItemForFarmingCreate(DamageItemForFarmingDTO damageItemForFarmingDTO)
        {
            damageItemForFarmingDTO.CreatedBy = int.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (damageItemForFarmingDTO.DamagePicUp != null)
                {
                    FileInfo fileInfo = new FileInfo(damageItemForFarmingDTO.DamagePicUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/damagefarmigproduct");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    damageItemForFarmingDTO.DamagePicUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    damageItemForFarmingDTO.DamagePic = uniqueFileName;
                }


                if (damageItemForFarmingDTO.DamageItemForFarmingId == null)
                {
                    var a = _damageItemForFarmingService.DamageItemForFarmingCreate(damageItemForFarmingDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/DamageItemForFarming/DamageItemForFarmingView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Damage Product Farming Already Exists");
					}
                    else
                    {
                        TempData["msg"] = MessageEnum.Error;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _damageItemForFarmingService.DamageItemForFarmingUpdate(damageItemForFarmingDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/DamageItemForFarming/DamageItemForFarmingView");
                    }
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Damage Product Farming Already Exists");
					}
					else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }

            ViewBag.ItemMasterFarmingList = _itemMasterForFarmingService.GetItemMasterForFarmingList();

            return View("~/Plugins/Warehouse.Management/Views/Item/DamageItemForFarmingCreate.cshtml", damageItemForFarmingDTO);
        }

        public IActionResult DamageItemForFarmingView()
        {
            ViewBag.DamageItems = _damageItemForFarmingService.GetDamageItemForFarmingList();

            return View("~/Plugins/Warehouse.Management/Views/Item/DamageItemForFarmingView.cshtml");
        }


        [HttpGet]
        public IActionResult DamageItemForFarmingDelete(Int64 damageItemForFarmingId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _damageItemForFarmingService.DamageItemForFarmingDelete(damageItemForFarmingId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/DamageItemForFarming/DamageItemForFarmingView");
        }
    }
}
