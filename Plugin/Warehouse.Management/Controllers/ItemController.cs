using System;
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



		public ItemController(IItemService itemService, IWebHostEnvironment hostingEnvironment, IHandlingTypeService handlingTypeService, IGSTService gSTService, ISectorService sectorService, ICategoryService categoryService, ISubCategory1Service subCategory1Service)
        {
			_hostingEnvironment = hostingEnvironment;
			_itemService = itemService;
			_handlingTypeService = handlingTypeService;
			_gSTService = gSTService;
			_sectorService = sectorService;
			_categoryService = categoryService;
			_subCategory1Service = subCategory1Service;
		}

        [HttpGet]
        public IActionResult ItemCreate(int? itemId)
        {

			ViewBag.Gst = _gSTService.GetGSTList();
			ViewBag.HandlingTypes = _handlingTypeService.GetHandlingTypeList();
			ViewBag.Sectors = _sectorService.GetSectorList();
			ViewBag.Categories = _categoryService.GetCategoryList();
			ViewBag.SubCategories1 = _subCategory1Service.GetSubCategory1List();



			ItemDTO item = new ItemDTO();
            if (itemId != null)
            {
                var item1 = _itemService.GetItemByItemId(int.Parse(itemId.ToString()));

                item.ItemName = item1.ItemName;
				item.SectorId = item1.SectorId;
				item.CategoryId = item1.CategoryId;
				item.SubCategory1Id = item1.SubCategory1Id;
                item.CompanyName = item1.CompanyName;
                item.BrandName = item1.BrandName;
                item.UnitOfMeasurement = item1.UnitOfMeasurement;
                item.CaseWeight = item1.CaseWeight;
                item.UnitPerCase = item1.UnitPerCase;
                item.ManufactureDate = item1.ManufactureDate;
                item.ExpiryDate = item1.ExpiryDate;
                item.Barcode = item1.Barcode;
                item.BarCodeNotAvailable = item1.BarCodeNotAvailable;
                item.MRP = item1.MRP;
                item.PurchaseCost = item1.PurchaseCost;
                item.SalesCost = item1.SalesCost;
                item.CGST = item1.CGST;
                item.SGST = item1.SGST;
                item.HandlingType = item1.HandlingType;
                item.Thumbnail = item1.Thumbnail;

				//item.Images = item1.Images;

				if (!string.IsNullOrEmpty(item1.Images))
				{
					// Split the string into a list of images
					item.Images = item1.Images.Split(',').ToList();
				}
				else
				{
					item.Images = new List<string>();
				}

				item.Videos = item1.Videos;
                item.IsActive = item1.IsActive;

            }

            return View("~/Plugins/Warehouse.Management/Views/Item/ItemCreate.cshtml", item);
        }

        [HttpPost]
        public IActionResult ItemCreate(ItemDTO itemDTO)
        {
            itemDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


			TempData.Clear();

			string btnSave = Request.Form["btnSave"];
			string btnGenerateBarcode = Request.Form["btnGenerateBarcode"];

			

			//if (itemDTO.ImagesUp != null)
			//{
			//    FileInfo fileInfo = new FileInfo(itemDTO.ImagesUp.FileName);
			//    string extn = fileInfo.Extension.ToLower();
			//    Guid id = Guid.NewGuid();
			//    string filename = id.ToString() + extn;

			//    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/setup");
			//    if (!Directory.Exists(uploadsFolder))
			//    {
			//        Directory.CreateDirectory(uploadsFolder);
			//    }
			//    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
			//    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
			//    itemDTO.ImagesUp.CopyTo(new FileStream(imagePath, FileMode.Create));
			//    itemDTO.Images = uniqueFileName;
			//}

			if (itemDTO.ThumbnailUp != null)
            {
                FileInfo fileInfo = new FileInfo(itemDTO.ThumbnailUp.FileName);
                string extn = fileInfo.Extension.ToLower();
                Guid id = Guid.NewGuid();
                string filename = id.ToString() + extn;

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/setup");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                itemDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                itemDTO.Thumbnail = uniqueFileName;
            }



            if (itemDTO.ImagesUp != null && itemDTO.ImagesUp.Count > 0)
			{
				foreach (var image in itemDTO.ImagesUp)
				{
					if (image != null && image.Length > 0)
					{
						// Get file extension
						string extn = Path.GetExtension(image.FileName).ToLower();

						// Generate unique filename
						Guid id = Guid.NewGuid();
						string filename = id.ToString() + extn;

						// Construct the full path to save the file
						string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/setup");
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
						itemDTO.Images.Add(uniqueFileName); // Assuming Images is a List<string> or similar
					}
				}
			}



			//if (ModelState.IsValid)
			//{


			//if (itemDTO.ItemId == null)
			//{
			//    var a = _itemService.CreateItem(itemDTO);
			//    if (a == MessageEnum.Success)
			//    {
			//        TempData["msg"] = MessageEnum.Success;
			//        return Redirect("/WareHouse/Item/ItemView");
			//    }
			//    else if (a == MessageEnum.Duplicate)
			//    {

			//        TempData["msg"] = MessageEnum.Duplicate;
			//        ModelState.AddModelError("", "WareHouse Already Exists");
			//    }
			//    else
			//    {
			//        TempData["msg"] = MessageEnum.UnExpectedError;
			//        ModelState.AddModelError("", "Un-Expected Error");
			//    }

			//}
			//else
			//{
			//    var a = _itemService.UpdateItem(itemDTO);
			//    if (a == MessageEnum.Updated)
			//    {
			//        TempData["msg"] = MessageEnum.Updated;
			//        return Redirect("/WareHouse/Item/ItemView");
			//    }
			//    else if (a == MessageEnum.Duplicate)
			//    {
			//        TempData["msg"] = MessageEnum.Duplicate;
			//        ModelState.AddModelError("", "Item Already Exists");
			//    }
			//    else
			//    {
			//        TempData["msg"] = MessageEnum.UnExpectedError;
			//        ModelState.AddModelError("", "Un-Expected Error");
			//    }
			//}
			////}
			//return View("~/Plugins/Warehouse.Management/Views/Item/ItemCreate.cshtml", itemDTO);



			if (btnGenerateBarcode != null)
			{
				var barcodeResult = GenerateBarcodeButton(itemDTO, btnGenerateBarcode);
				if (barcodeResult is ViewResult)
				{					
					return barcodeResult;
				}
			}


			if (itemDTO.ItemId == null)
			{
				if (btnSave != null)
				{
					

					var createdItemDTO = _itemService.CreateItem(itemDTO);

					if (createdItemDTO != null && itemDTO.BarCodeNotAvailable == true)
					{
						//TempData["msg"] = MessageEnum.Success;

						return View("~/Plugins/Warehouse.Management/Views/Item/ItemCreate.cshtml", createdItemDTO);
					}
					else if(createdItemDTO != null && itemDTO.BarCodeNotAvailable == false)
					{
						TempData["msg"] = MessageEnum.Success;						
						return Redirect("/WareHouse/Item/ItemView");
					}
					else
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Item Already Exists");
						return Redirect("/WareHouse/Item/ItemView");
					}
				}				
			}
			else
			{
				var a = _itemService.UpdateItem(itemDTO);
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



			ViewBag.Items = _itemService.GetItemList();

			//Continue with the rest of your logic or return the view as needed
			return View("~/Plugins/Warehouse.Management/Views/Item/ItemView.cshtml", ViewBag.Items);

		}


		[HttpPost]
		public IActionResult GenerateBarcodeButton(ItemDTO itemDTO, string btnGenerateBarcode)
		{
			if (btnGenerateBarcode != "btnGenerateBarcode")
			{				
				// Logic for handling barcode generation
				_itemService.GenerateAndSaveBarcodeImage(btnGenerateBarcode);

				TempData["msg"] = "Barcode generated and Item saved successfully";
				return RedirectToAction("ItemView");
			}
			else
			{
				TempData["msg"] = "Kindly Save the data first";
				return View("~/Plugins/Warehouse.Management/Views/Item/ItemCreate.cshtml", itemDTO);
			}
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
    }
}
