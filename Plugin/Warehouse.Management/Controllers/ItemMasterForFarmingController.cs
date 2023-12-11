using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
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
	public class ItemMasterForFarmingController : BasePluginController
	{
		private readonly IItemMasterForFarmingService _itemMasterForFarmingService;
		private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ICategoryService _categoryService;
        private readonly ISubCategory1Service _subCategory1Service;

        public ItemMasterForFarmingController(IItemMasterForFarmingService itemMasterForFarmingService,
			                                  IWebHostEnvironment hostingEnvironment,
                                              ICategoryService categoryService,
                                              ISubCategory1Service subCategory1Service
                                              )
		{
			_itemMasterForFarmingService = itemMasterForFarmingService;
			_hostingEnvironment = hostingEnvironment;
            _categoryService = categoryService;
            _subCategory1Service = subCategory1Service;
        }

		[HttpGet]
		public IActionResult CreateItemMasterForFarming(int? itemMasterForFarmingId)
		{

            ViewBag.Categories = _categoryService.GetCategoryList();
            ViewBag.SubCategories = _subCategory1Service.GetSubCategory1List();

            ItemMasterForFarmingDTO itemMaster = new ItemMasterForFarmingDTO();

			if (itemMasterForFarmingId != null)
			{
				var itemMaster1 = _itemMasterForFarmingService.GetItemMasterForFarmingByItemMasterForFarmingId(int.Parse(itemMasterForFarmingId.ToString()));

				itemMaster.CategoryId = itemMaster1.CategoryId;
				itemMaster.SubCategory1Id = itemMaster1.SubCategory1Id;
				itemMaster.Barcode = itemMaster1.Barcode;
				itemMaster.BarCodeNotAvailable = itemMaster1.BarCodeNotAvailable;
				itemMaster.UOMId = itemMaster1.UOMId;
				itemMaster.ProductName = itemMaster1.ProductName;
				itemMaster.QtyPerKg = itemMaster1.QtyPerKg;
				itemMaster.Price = itemMaster1.Price;
				itemMaster.MinQty = itemMaster1.MinQty;
				itemMaster.GST = itemMaster1.GST;
				itemMaster.HSN = itemMaster1.HSN;
				itemMaster.HarvestDate = itemMaster1.HarvestDate;
				
				itemMaster.Thumbnail = itemMaster1.Thumbnail;

				if (!string.IsNullOrEmpty(itemMaster1.Images))
				{
					// Split the string into a list of images
					itemMaster.Images = itemMaster1.Images.Split(',').ToList();
				}
				else
				{
					itemMaster.Images = new List<string>();
				}

			}

			return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingCreate.cshtml", itemMaster);
		}

        //[HttpPost]
        //public IActionResult CreateItemMasterForFarming(ItemMasterForFarmingDTO itemMasterForFarmingDTO, string btnSave, string btnGenerateBarcode)
        //{
        //	itemMasterForFarmingDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());


        //	if (itemMasterForFarmingDTO.ThumbnailUp != null)
        //	{
        //		FileInfo fileInfo = new FileInfo(itemMasterForFarmingDTO.ThumbnailUp.FileName);
        //		string extn = fileInfo.Extension.ToLower();
        //		Guid id = Guid.NewGuid();
        //		string filename = id.ToString() + extn;

        //		string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/setup");
        //		if (!Directory.Exists(uploadsFolder))
        //		{
        //			Directory.CreateDirectory(uploadsFolder);
        //		}
        //		string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
        //		string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
        //		itemMasterForFarmingDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
        //		itemMasterForFarmingDTO.Thumbnail = uniqueFileName;
        //	}



        //	if (itemMasterForFarmingDTO.ImagesUp != null && itemMasterForFarmingDTO.ImagesUp.Count > 0)
        //	{
        //		foreach (var image in itemMasterForFarmingDTO.ImagesUp)
        //		{
        //			if (image != null && image.Length > 0)
        //			{
        //				// Get file extension
        //				string extn = Path.GetExtension(image.FileName).ToLower();

        //				// Generate unique filename
        //				Guid id = Guid.NewGuid();
        //				string filename = id.ToString() + extn;

        //				// Construct the full path to save the file
        //				string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/setup");
        //				if (!Directory.Exists(uploadsFolder))
        //				{
        //					Directory.CreateDirectory(uploadsFolder);
        //				}
        //				string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
        //				string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

        //				// Copy the stream to the file
        //				using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //				{
        //					image.CopyTo(fileStream);
        //				}

        //				// Store the unique filename in your model
        //				itemMasterForFarmingDTO.Images.Add(uniqueFileName); // Assuming Images is a List<string> or similar
        //			}
        //		}
        //	}



        //	if (itemMasterForFarmingDTO.ItemMasterForFarmingId == null)
        //	{

        //		if (!string.IsNullOrEmpty(btnSave) && itemMasterForFarmingDTO.BarCodeNotAvailable == false)
        //		{

        //			var createdItemDTO = _itemMasterForFarmingService.CreateItemMasterForFarming(itemMasterForFarmingDTO);

        //			if (createdItemDTO != null)
        //			{
        //				TempData["msg"] = MessageEnum.Success;
        //				// Pass the createdItemDTO directly to the view
        //				return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingView.cshtml");
        //			}
        //			else
        //			{
        //				TempData["msg"] = MessageEnum.Duplicate;
        //				ModelState.AddModelError("", "Item Already Exists");
        //			}
        //		}

        //		if (!string.IsNullOrEmpty(btnSave) && itemMasterForFarmingDTO.BarCodeNotAvailable == true)
        //		{

        //			var createdItemDTO = _itemMasterForFarmingService.CreateItemMasterForFarming(itemMasterForFarmingDTO);

        //			if (createdItemDTO != null)
        //			{
        //				TempData["msg"] = MessageEnum.Success;


        //				return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingCreate.cshtml", createdItemDTO);
        //			}
        //			else
        //			{
        //				TempData["msg"] = MessageEnum.Duplicate;
        //				ModelState.AddModelError("", "Item Already Exists");
        //			}
        //		}


        //		if (!string.IsNullOrEmpty(btnGenerateBarcode) && itemMasterForFarmingDTO.BarCodeNotAvailable == true)
        //		{

        //			if (itemMasterForFarmingDTO.BarCodeNotAvailable)
        //			{
        //				_itemMasterForFarmingService.GenerateAndSaveBarcodeImage(btnGenerateBarcode);

        //				TempData["msg"] = "Barcode generated and Item saved successfully";
        //			}
        //		}
        //	}

        //	else
        //	{
        //		var a = _itemMasterForFarmingService.UpdateItemMasterForFarming(itemMasterForFarmingDTO);
        //		if (a == MessageEnum.Updated)
        //		{
        //			TempData["msg"] = MessageEnum.Updated;
        //			return Redirect("/WareHouse/ItemMasterForFarming/ItemMasterForFarmingView");
        //		}
        //		else if (a == MessageEnum.Duplicate)
        //		{
        //			TempData["msg"] = MessageEnum.Duplicate;
        //			ModelState.AddModelError("", "Item Already Exists");
        //		}
        //		else
        //		{
        //			TempData["msg"] = MessageEnum.UnExpectedError;
        //			ModelState.AddModelError("", "Un-Expected Error");
        //		}
        //	}


        //	ViewBag.Items = _itemMasterForFarmingService.GetItemMasterForFarmingList();

        //          ViewBag.CategoryList = _categoryService.GetCategoryList();
        //          ViewBag.SubCategory1List = _subCategory1Service.GetSubCategory1List();


        //          //Continue with the rest of your logic or return the view as needed
        //          return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingView.cshtml", ViewBag.Items);

        //}



        [HttpPost]
        public IActionResult CreateItemMasterForFarming(ItemMasterForFarmingDTO itemMasterForFarmingDTO)
        {
            itemMasterForFarmingDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            TempData.Clear();

            string btnSave = Request.Form["btnSave"];
            string btnGenerateBarcode = Request.Form["btnGenerateBarcode"];

            if (itemMasterForFarmingDTO.ThumbnailUp != null)
            {
                FileInfo fileInfo = new FileInfo(itemMasterForFarmingDTO.ThumbnailUp.FileName);
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
                itemMasterForFarmingDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                itemMasterForFarmingDTO.Thumbnail = uniqueFileName;
            }


            if (itemMasterForFarmingDTO.ImagesUp != null && itemMasterForFarmingDTO.ImagesUp.Count > 0)
            {
                foreach (var image in itemMasterForFarmingDTO.ImagesUp)
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
                        itemMasterForFarmingDTO.Images.Add(uniqueFileName); // Assuming Images is a List<string> or similar
                    }
                }
            }



            if (btnGenerateBarcode != null)
            {
                var barcodeResult = GenerateBarcodeButton(itemMasterForFarmingDTO, btnGenerateBarcode);
                if (barcodeResult is ViewResult)
                {
                    return barcodeResult;
                }
            }


            if (itemMasterForFarmingDTO.ItemMasterForFarmingId == null)
            {
                if (btnSave != null)
                {
                    var createdItemDTO = _itemMasterForFarmingService.CreateItemMasterForFarming(itemMasterForFarmingDTO);

                    if (createdItemDTO != null && itemMasterForFarmingDTO.BarCodeNotAvailable == true)
                    {
                        //TempData["msg"] = MessageEnum.Success;

                        return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingCreate.cshtml", createdItemDTO);
                    }
                    else if (createdItemDTO != null && itemMasterForFarmingDTO.BarCodeNotAvailable == false)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/ItemMasterForFarming/ItemMasterForFarmingView");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Item Already Exists");
                        return Redirect("/WareHouse/ItemMasterForFarming/ItemMasterForFarmingView");
                    }
                }
            }
            else
            {
                var a = _itemMasterForFarmingService.UpdateItemMasterForFarming(itemMasterForFarmingDTO);
                if (a == MessageEnum.Updated)
                {
                    TempData["msg"] = MessageEnum.Updated;
                    return Redirect("/WareHouse/ItemMasterForFarming/ItemMasterForFarmingView");
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


            ViewBag.Items = _itemMasterForFarmingService.GetItemMasterForFarmingList();

            ViewBag.Categories = _categoryService.GetCategoryList();
            ViewBag.SubCategories = _subCategory1Service.GetSubCategory1List();


            //Continue with the rest of your logic or return the view as needed
            return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingView.cshtml", ViewBag.Items);


        }


        [HttpPost]
        public IActionResult GenerateBarcodeButton(ItemMasterForFarmingDTO itemMasterForFarmingDTO, string btnGenerateBarcode)
        {
            if (btnGenerateBarcode != "btnGenerateBarcode")
            {
                // Logic for handling barcode generation
                _itemMasterForFarmingService.GenerateAndSaveBarcodeImage(btnGenerateBarcode);


                TempData["msg"] = "Barcode generated and Item saved successfully";
                return RedirectToAction("ItemMasterForFarmingView");
            }
            else
            {
                TempData["msg"] = "Kindly Save the data first";
                return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingCreate.cshtml", itemMasterForFarmingDTO);
            }
        }







        [HttpGet]
		public IActionResult ItemMasterForFarmingView()
		{
			ViewBag.Items = _itemMasterForFarmingService.GetItemMasterForFarmingList();
			return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingView.cshtml");
		}

		[HttpGet]
		public IActionResult ItemMasterForFarmingDelete(Int64 itemMasterForFarmingId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _itemMasterForFarmingService.DeleteItemMasterForFarming(itemMasterForFarmingId, DeletedBy);

			TempData["msg"] = a;
			return Redirect("/WareHouse/ItemMasterForFarming/ItemMasterForFarmingView");
		}

	}
}
