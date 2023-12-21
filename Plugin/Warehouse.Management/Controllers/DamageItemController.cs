﻿using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class DamageItemController : BaseController
	{
		private readonly IDamageItemService _damageItemService;
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly IItemService _itemService;

		public DamageItemController(IDamageItemService damageItemService,
			                        IWebHostEnvironment hostingEnvironment,
									IItemService itemService)
		{
			_damageItemService = damageItemService;
			_hostingEnvironment = hostingEnvironment;
			_itemService = itemService;
		}

		[HttpGet]
		public IActionResult CreateDamageItem(int? damageItemId)
		{
			ViewBag.ItemList = _itemService.GetItemList();

			DamageItemDTO damageItemDTO = new DamageItemDTO();

			if (damageItemId != null)
			{

				DamageItem d = _damageItemService.GetDamageItemByDamageItemId(int.Parse(damageItemId.ToString()));

				damageItemDTO.ItemId = d.ItemId;
				damageItemDTO.ItemName = d.ItemName;
				damageItemDTO.WareHouseName = d.WareHouseName;
				damageItemDTO.DistrictName = d.DistrictName;
				damageItemDTO.VendorName = d.VendorName;
				damageItemDTO.EmployeeName = d.EmployeeName;
				damageItemDTO.CompanyName = d.CompanyName;
				damageItemDTO.BrandName = d.BrandName;
				damageItemDTO.ProductWeight = d.ProductWeight;
				damageItemDTO.UnitId = d.UnitId;
				damageItemDTO.CaseWeight = d.CaseWeight;
				damageItemDTO.UnitPerCase = d.UnitPerCase;
				damageItemDTO.ManufactureDate = d.ManufactureDate;
				damageItemDTO.ExpiryDate = d.ExpiryDate;
				damageItemDTO.MRP = d.MRP;
				damageItemDTO.PurchaseCost = d.PurchaseCost;
				damageItemDTO.SalesCost = d.SalesCost;
				damageItemDTO.CGST = d.CGST;
				damageItemDTO.SGST = d.SGST;
				damageItemDTO.HandlingType = d.HandlingType;
				damageItemDTO.ReceivedDate = d.ReceivedDate;
				damageItemDTO.Reason = d.Reason;
				damageItemDTO.DamagePics = d.DamagePics;
                damageItemDTO.InvoiceNo = d.InvoiceNo;
				damageItemDTO.DamageUnits = d.DamageUnits;	
            }
            return View("~/Plugins/Warehouse.Management/Views/Item/DamageItemCreate.cshtml", damageItemDTO);

        }

		[HttpPost]
		public IActionResult CreateDamageItem(DamageItemDTO damageItemDTO)
		{
			damageItemDTO.CreatedBy = int.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{
				if (damageItemDTO.DamagePic != null)
				{
					FileInfo fileInfo = new FileInfo(damageItemDTO.DamagePic.FileName);
					string extn = fileInfo.Extension.ToLower();
					Guid id = Guid.NewGuid();
					string filename = id.ToString() + extn;

					string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/damageproduct");
					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}
					string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
					string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
					damageItemDTO.DamagePic.CopyTo(new FileStream(imagePath, FileMode.Create));
					damageItemDTO.DamagePics = uniqueFileName;
				}
				if (damageItemDTO.DamageItemId == null)
				{
					var a = _damageItemService.DamageItemCreate(damageItemDTO);
					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/DamageItem/DamageItemView");
					}
					else if (a == MessageEnum.AlreadyCreate)
					{
						TempData["msg"] = MessageEnum.AlreadyCreate;

						return Redirect("/WareHouse/DamageItem/DamageItemView");
					}
					else if (a == MessageEnum.Duplicate)
                    {

                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "DamageItem Already Exists");
                    }
                    else
					{
						TempData["msg"] = MessageEnum.Error;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _damageItemService.DamageItemUpdate(damageItemDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/DamageItem/DamageItemView");
					}

					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}

		     ViewBag.ItemList = _itemService.GetItemList();

			return View("~/Plugins/Warehouse.Management/Views/Item/DamageItemCreate.cshtml", damageItemDTO);
        }

		public IActionResult DamageItemView()
		{
			ViewBag.DamageItems = _damageItemService.GetDamageItemList();

			return View("~/Plugins/Warehouse.Management/Views/Item/DamageItemView.cshtml");
		}
		public IActionResult DeleteDamageItem(int damageItemId)
		{
			int DeletedBy = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _damageItemService.DamageItemDelete(damageItemId, DeletedBy);
			TempData["msg"] = a;
			return Redirect("/WareHouse/DamageItem/DamageItemView");
		}
	}
}
