﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Services.WareHouses.GSTs;
using CloudVOffice.Services.WareHouses.HandlingTypes;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloudVOffice.Services.ProductCategories;
//using Warehouse.Management.ViewModel;
using CloudVOffice.Data.DTO.WareHouses.ViewModel;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.Vendors;
using CloudVOffice.Services.WareHouses.Employees;
using CloudVOffice.Services.WareHouses.Districts;
using CloudVOffice.Services.WareHouses.UOMs;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Core.Domain.Sellers;
using Microsoft.Identity.Client;
using CloudVOffice.Services.Users;
using CloudVOffice.Core.Domain.WareHouses.Brands;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class ItemController : BasePluginController
    {
        private readonly IItemService _itemService;
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly IHandlingTypeService _handlingTypeService;
		private readonly IGSTService _gSTService;
		private readonly ISectorService _sectorService;
		private readonly ICategoryService _categoryService;
		private readonly ISubCategory1Service _subCategory1Service;
		private readonly ISubCategory2Service _subCategory2Service;
		private readonly IWareHouseService _warehouseService;
		private readonly IAddDistrictService _addDistrictService;
		private readonly IVendorService _vendorService;
		private readonly IEmployeeService _employeeService;
		private readonly IUnit _unitService;
		private readonly IBrandService _brandService;
		private readonly ISellerRegistrationService _sellerRegistrationService;

        private readonly IUserWareHouseMappingService _UserWareHouseMappingService;

        public ItemController(IItemService itemService,
			IWebHostEnvironment hostingEnvironment, 
			IHandlingTypeService handlingTypeService, 
			IGSTService gSTService, 
			ISectorService sectorService, 
			ICategoryService categoryService, 
			ISubCategory1Service subCategory1Service, 
			ISubCategory2Service subCategory2Service, 
			IWareHouseService warehouseService, 
			IVendorService vendorService, 
			IEmployeeService employeeService, 
			IAddDistrictService addDistrictService, 
			IUnit unitService,IBrandService brandService, 
			ISellerRegistrationService sellerRegistrationService,
             IUserWareHouseMappingService UserWareHouseMappingService
            )
        {
			_hostingEnvironment = hostingEnvironment;
			_itemService = itemService;
			_handlingTypeService = handlingTypeService;
			_gSTService = gSTService;
			_sectorService = sectorService;
            _categoryService = categoryService;
			_subCategory1Service = subCategory1Service;
			_subCategory2Service = subCategory2Service;
			_warehouseService = warehouseService;
            _addDistrictService = addDistrictService;
			//_vendorService = vendorService;
			_employeeService = employeeService;
			_unitService = unitService;
			_brandService = brandService;
			_sellerRegistrationService = sellerRegistrationService;
            _UserWareHouseMappingService = UserWareHouseMappingService;
        }

        [HttpGet]
        public IActionResult ItemCreate(int? itemId)
        {

            //ViewBag.Gst = _gSTService.GetGSTList();
            //ViewBag.HandlingTypes = _handlingTypeService.GetHandlingTypeList();
            //ViewBag.Sectors = _sectorService.GetSectorList();
            //ViewBag.Categories = _categoryService.GetCategoryList();
            //ViewBag.SubCategories1 = _subCategory1Service.GetSubCategory1List();

            //ViewBag.Sellers = _sellerRegistrationService.GetSellerRegistrationList();



            var viewForItem = new ViewForItem
            {
                HandlingTypes = _handlingTypeService.GetHandlingTypeList(),
                WareHuose = _warehouseService.GetWareHouseList(),
				SellerRegistration = _sellerRegistrationService.GetSellerRegistrationList(),
                AddDistrict = _addDistrictService.GetAddDistrictList(),
                //Vendor = _vendorService.GetVendorList(),
                Employee = _employeeService.GetEmployees(),
                //GST = _gSTService.GetGSTList(),
                Sectors = _sectorService.GetSectorList(),
                Category = _categoryService.GetCategoryList(),
                SubCategory1 = _subCategory1Service.GetSubCategory1List(),
                SubCategory2 = _subCategory2Service.GetSubCategory2List(),
                Unit = _unitService.GetUnit(),
                Brand = _brandService.GetBrandList(),
                CreatedItemDTO = new ItemDTO()
            };


            //ItemDTO item = new ItemDTO();
            if (itemId != null)
            {
                var item1 = _itemService.GetItemByItemId(int.Parse(itemId.ToString()));

				viewForItem.CreatedItemDTO.ItemId = itemId;
				viewForItem.CreatedItemDTO.ItemName = item1.ItemName;
				viewForItem.CreatedItemDTO.SectorId = item1.SectorId;
				viewForItem.CreatedItemDTO.CategoryId = item1.CategoryId;
				viewForItem.CreatedItemDTO.SubCategory1Id = item1.SubCategory1Id;
				viewForItem.CreatedItemDTO.SubCategory2Id = item1.SubCategory2Id;
				viewForItem.CreatedItemDTO.CompanyName = item1.CompanyName;
				viewForItem.CreatedItemDTO.BrandId = item1.BrandId;
				//viewForItem.CreatedItemDTO.BrandName = item1.BrandName;
				viewForItem.CreatedItemDTO.UnitId = item1.UnitId;
				//viewForItem.CreatedItemDTO.UnitOfMeasurement = item1.UnitOfMeasurement;
				viewForItem.CreatedItemDTO.ProductWeight = item1.ProductWeight;
                viewForItem.CreatedItemDTO.CaseWeight = item1.CaseWeight;
				viewForItem.CreatedItemDTO.UnitPerCase = item1.UnitPerCase;
				viewForItem.CreatedItemDTO.ManufactureDate = item1.ManufactureDate;
				viewForItem.CreatedItemDTO.ReceivedDate = item1.ReceivedDate;
				viewForItem.CreatedItemDTO.ExpiryDate = item1.ExpiryDate;
				viewForItem.CreatedItemDTO.Barcode = item1.Barcode;
				viewForItem.CreatedItemDTO.BarCodeNotAvailable = item1.BarCodeNotAvailable;
				viewForItem.CreatedItemDTO.MRP = item1.MRP;
				viewForItem.CreatedItemDTO.MRPCaseCost = item1.MRPCaseCost;				
				viewForItem.CreatedItemDTO.SalesCost = item1.SalesCost;
				viewForItem.CreatedItemDTO.SalesCaseCost = item1.SalesCaseCost;				
				viewForItem.CreatedItemDTO.CGST = item1.CGST;
				viewForItem.CreatedItemDTO.SGST = item1.SGST;
				viewForItem.CreatedItemDTO.HSN = item1.HSN;
				viewForItem.CreatedItemDTO.SellerMargin = item1.SellerMargin;

				viewForItem.CreatedItemDTO.RetailerCost = item1.RetailerCost;
				viewForItem.CreatedItemDTO.RetailerLandingCost = item1.RetailerLandingCost;
				viewForItem.CreatedItemDTO.RetailerCaseCost = item1.RetailerCaseCost;
                viewForItem.CreatedItemDTO.PartnerSalesCost = item1.PartnerSalesCost;
                viewForItem.CreatedItemDTO.PartnerSalesCaseCost = item1.PartnerSalesCaseCost;
				viewForItem.CreatedItemDTO.DistributorCaseCost = item1.DistributorCaseCost;
				viewForItem.CreatedItemDTO.DistributorCost = item1.DistributorCost;
				viewForItem.CreatedItemDTO.DistributorLandingCost = item1.DistributorLandingCost;
                viewForItem.CreatedItemDTO.PurchaseCost = item1.PurchaseCost;
                viewForItem.CreatedItemDTO.PurchaseCaseCost = item1.PurchaseCaseCost;
				viewForItem.CreatedItemDTO.PurchaseLandingCost = item1.PurchaseLandingCost;
				viewForItem.CreatedItemDTO.IGST = item1.IGST;


				viewForItem.CreatedItemDTO.DistributorMargin = item1.DistributorMargin;
				viewForItem.CreatedItemDTO.RetailerMargin = item1.RetailerMargin;
				viewForItem.CreatedItemDTO.PurchaseCGSTValue = item1.PurchaseCGSTValue;
				viewForItem.CreatedItemDTO.PurchaseSGSTValue = item1.PurchaseSGSTValue;
				viewForItem.CreatedItemDTO.PurchaseIGSTValue = item1.PurchaseIGSTValue;
				viewForItem.CreatedItemDTO.DistributorCGSTValue = item1.DistributorCGSTValue;
				viewForItem.CreatedItemDTO.DistributorSGSTValue = item1.DistributorSGSTValue;
				viewForItem.CreatedItemDTO.RetailerCGSTValue = item1.RetailerCGSTValue;
				viewForItem.CreatedItemDTO.RetailerSGSTValue = item1.RetailerSGSTValue;


                //viewForItem.CreatedItemDTO.HandlingType = item1.HandlingType;
                //viewForItem.CreatedItemDTO.WareHouseName = item1.WareHouseName;
                //viewForItem.CreatedItemDTO.DistrictName = item1.DistrictName;
                //viewForItem.CreatedItemDTO.VendorName = item1.VendorName;
                //viewForItem.CreatedItemDTO.EmployeeName = item1.EmployeeName;

                viewForItem.CreatedItemDTO.HandlingTypeId = item1.HandlingTypeId;
                viewForItem.CreatedItemDTO.WareHuoseId = item1.WareHuoseId;
                viewForItem.CreatedItemDTO.AddDistrictId = item1.AddDistrictId;
                viewForItem.CreatedItemDTO.VendorId = item1.VendorId;
                viewForItem.CreatedItemDTO.EmployeeId = item1.EmployeeId;


                viewForItem.CreatedItemDTO.Thumbnail = item1.Thumbnail;
				viewForItem.CreatedItemDTO.InvoiceNo = item1.InvoiceNo;

				if (!string.IsNullOrEmpty(item1.Images))
				{
					// Split the string into a list of images
					viewForItem.CreatedItemDTO.Images = item1.Images.Split(',').ToList();
				}
				else
				{
					viewForItem.CreatedItemDTO.Images = new List<string>();
				}
				//viewForItem.CreatedItemDTO.IsActive = item1.IsActive;



				//            item.ItemName = item1.ItemName;
				//item.SectorId = item1.SectorId;
				//item.CategoryId = item1.CategoryId;
				//item.SubCategory1Id = item1.SubCategory1Id;
				//            item.CompanyName = item1.CompanyName;
				//            item.BrandName = item1.BrandName;
				//            item.UnitOfMeasurement = item1.UnitOfMeasurement;
				//            item.CaseWeight = item1.CaseWeight;
				//            item.UnitPerCase = item1.UnitPerCase;
				//            item.ManufactureDate = item1.ManufactureDate;
				//            item.ExpiryDate = item1.ExpiryDate;
				//            item.Barcode = item1.Barcode;
				//            item.BarCodeNotAvailable = item1.BarCodeNotAvailable;
				//            item.MRP = item1.MRP;
				//            item.PurchaseCost = item1.PurchaseCost;
				//            item.SalesCost = item1.SalesCost;
				//            item.CGST = item1.CGST;
				//            item.SGST = item1.SGST;
				//            item.HandlingType = item1.HandlingType;
				//            item.Thumbnail = item1.Thumbnail;

				////item.Images = item1.Images;

				//if (!string.IsNullOrEmpty(item1.Images))
				//{
				//	// Split the string into a list of images
				//	item.Images = item1.Images.Split(',').ToList();
				//}
				//else
				//{
				//	item.Images = new List<string>();
				//}

				//item.Videos = item1.Videos;
				//            item.IsActive = item1.IsActive;




			}

			return View("~/Plugins/Warehouse.Management/Views/Item/ItemCreate.cshtml", viewForItem);
        }

        [HttpPost]
        public IActionResult ItemCreate(ViewForItem viewForItem)
        {
			viewForItem.CreatedItemDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			

			TempData.Clear();

			string btnSave = Request.Form["btnSave"];
			string btnGenerateBarcode = Request.Form["btnGenerateBarcode"];




			if (viewForItem.CreatedItemDTO.ThumbnailUp != null)
			{
				FileInfo fileInfo = new FileInfo(viewForItem.CreatedItemDTO.ThumbnailUp.FileName);
				string extn = fileInfo.Extension.ToLower();
				Guid id = Guid.NewGuid();
				string filename = id.ToString() + extn;

				string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/itemimage");
				if (!Directory.Exists(uploadsFolder))
				{
					Directory.CreateDirectory(uploadsFolder);
				}
				string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
				string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
				viewForItem.CreatedItemDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
				viewForItem.CreatedItemDTO.Thumbnail = uniqueFileName;
			}



			if (viewForItem.CreatedItemDTO.ImagesUp != null && viewForItem.CreatedItemDTO.ImagesUp.Count > 0)
			{
				foreach (var image in viewForItem.CreatedItemDTO.ImagesUp)
				{
					if (image != null && image.Length > 0)
					{
						// Get file extension
						string extn = Path.GetExtension(image.FileName).ToLower();

						// Generate unique filename
						Guid id = Guid.NewGuid();
						string filename = id.ToString() + extn;

						// Construct the full path to save the file
						string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/itemimage");
						if (!Directory.Exists(uploadsFolder))
						{
							Directory.CreateDirectory(uploadsFolder);
						}
						string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
						string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

						// Copy the stream to the file
						using (var fileStream = new FileStream(imagePath, FileMode.Create))
						{
							image.CopyTo(fileStream);
						}

						// Store the unique filename in your model
						viewForItem.CreatedItemDTO.Images.Add(uniqueFileName); // Assuming Images is a List<string> or similar
					}
				}
			}



			//if (btnGenerateBarcode != null)
			//{
			//	var barcodeResult = GenerateBarcodeButton(viewForItem, btnGenerateBarcode);
			//	if (barcodeResult is ViewResult)
			//	{
			//		return barcodeResult;
			//	}
			//}


			if (viewForItem.CreatedItemDTO.ItemId == null)
			{
				if (btnSave != null)
				{

					var createdItemDTO = _itemService.CreateItem(viewForItem.CreatedItemDTO);

					if (createdItemDTO != null && viewForItem.CreatedItemDTO.BarCodeNotAvailable == true)
					{
						var barcodeResult = GenerateBarcodeButton(createdItemDTO.ItemId);
						if (barcodeResult is ViewResult)
						{
							//return barcodeResult;
							return Redirect("/WareHouse/Item/ItemView");
						}

						//var viewForItem1 = new ViewForItem
						//{
						//	//CreatedItemDTO = _itemService.CreateItem(viewForItem.CreatedItemDTO),
						//	CreatedItemDTO = createdItemDTO,
						//	Sectors = _sectorService.GetSectorList(),
						//	HandlingTypes = _handlingTypeService.GetHandlingTypeList(),
						//	//GST = _gSTService.GetGSTList(),
						//	Category = _categoryService.GetCategoryList(),
						//	SubCategory1 = _subCategory1Service.GetSubCategory1List(),
						//	SubCategory2 = _subCategory2Service.GetSubCategory2List(),
						//	WareHuose = _warehouseService.GetWareHouseList(),
						//	AddDistrict = _addDistrictService.GetAddDistrictList(),
						//	Employee = _employeeService.GetEmployees(),
						//	Vendor = _vendorService.GetVendorList(),
						//	Unit = _unitService.GetUnit(),
						//	Brand = _brandService.GetBrandList()
						//};

						//return View("~/Plugins/Warehouse.Management/Views/Item/ItemCreate.cshtml", viewForItem1);

						return Redirect("/WareHouse/Item/ItemView");
					}
					else if (createdItemDTO != null && viewForItem.CreatedItemDTO.BarCodeNotAvailable == false)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/Item/ItemView");
					}
					else if (createdItemDTO == null)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						//ModelState.AddModelError("", "Item Already Exists");
						//return Redirect("/WareHouse/Item/ItemView");
						TempData["msg"] = "Item Already Exists";
					}
				}
			}
			else
			{
				if (viewForItem.CreatedItemDTO.BarCodeNotAvailable == false)
				{
                    var a = _itemService.UpdateItem(viewForItem.CreatedItemDTO);                    
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/Item/ItemView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Item Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
				else
				{
                    var a = _itemService.UpdateItem(viewForItem.CreatedItemDTO);
                    var barcodeResult = GenerateBarcodeButton(viewForItem.CreatedItemDTO.ItemId);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/Item/ItemView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Item Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }				
			}

			ViewBag.Items = _itemService.GetItemList();
			return View("~/Plugins/Warehouse.Management/Views/Item/ItemView.cshtml", ViewBag.Items);

		}


		[HttpPost]
		public IActionResult GenerateBarcodeButton(Int64? btnGenerateBarcode)
		{
			//if (btnGenerateBarcode != "btnGenerateBarcode")
			//{				
			//	// Logic for handling barcode generation
			//	_itemService.GenerateAndSaveBarcodeImage(ItemId.ToString());

			//	TempData["msg"] = "Barcode generated and Item saved successfully";
			//	return RedirectToAction("ItemView");
			//}

			_itemService.GenerateAndSaveBarcodeImage(btnGenerateBarcode.ToString());
			TempData["msg"] = "Barcode generated and Item saved successfully";
			//return RedirectToAction("ItemView");

			ViewBag.Items = _itemService.GetItemList();
			return View("~/Plugins/Warehouse.Management/Views/Item/ItemView.cshtml", ViewBag.Items);


			//else
			//{
			//	TempData["msg"] = "Kindly Save the data first";
			//	var viewForItem1 = new ViewForItem
			//	{
			//		//CreatedItemDTO = _itemService.CreateItem(viewForItem.CreatedItemDTO),
			//		CreatedItemDTO = viewForItem.CreatedItemDTO,
			//		Sectors = _sectorService.GetSectorList(),
			//		HandlingTypes = _handlingTypeService.GetHandlingTypeList(),
			//		//GST = _gSTService.GetGSTList(),
			//		Category = _categoryService.GetCategoryList(),
			//		SubCategory1 = _subCategory1Service.GetSubCategory1List(),
			//		SubCategory2 = _subCategory2Service.GetSubCategory2List(),
			//		WareHuose = _warehouseService.GetWareHouseList(),
			//		AddDistrict = _addDistrictService.GetAddDistrictList(),
			//		Employee = _employeeService.GetEmployees(),
			//		Vendor = _vendorService.GetVendorList(),
			//		Unit = _unitService.GetUnit(),
			//		Brand = _brandService.GetBrandList()
			//	};

			//return View("~/Plugins/Warehouse.Management/Views/Item/ItemCreate.cshtml", viewForItem1);
		}
	

		[HttpGet]
        public IActionResult ItemView()
        {
            ViewBag.Items = _itemService.GetItemList();
            return View("~/Plugins/Warehouse.Management/Views/Item/ItemView.cshtml");
        }

        [HttpGet]
        public IActionResult ItemDelete(Int64 itemId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _itemService.DeleteItem(itemId, DeletedBy);

            TempData["msg"] = a;
            return Redirect("/WareHouse/Item/ItemView");
        }

		public JsonResult GetItemById(int ItemId)
		{
			return Json(_itemService.GetItemById(ItemId));
		}


        [HttpGet]
        public string GetGstForSeller(int sellerRegistrationId)
        {
            string a = _gSTService.GetGstForSeller(sellerRegistrationId);
			return a;
        }

        public JsonResult BrandListByWareHouseId()
        {
            Int64 UserId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            var Warehousedetails = _UserWareHouseMappingService.GetWareHouseByUserId(UserId);

            var brands = _itemService.BrandListByWareHouseId(Warehousedetails.WareHuoseId)
                            .GroupBy(b => new { b.BrandId , b.Brands.BrandName }) 
                            .Select(g => new { BrandId = g.Key.BrandId, BrandName = g.Key.BrandName })
                            .ToList();

            return Json(brands);
        }

    }
}
