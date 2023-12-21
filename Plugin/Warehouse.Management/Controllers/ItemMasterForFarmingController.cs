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
using CloudVOffice.Data.DTO.WareHouses.ViewModel;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.Employees;
using CloudVOffice.Services.WareHouses.Vendors;
using CloudVOffice.Services.WareHouses.Districts;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class ItemMasterForFarmingController : BasePluginController
	{
		private readonly IItemMasterForFarmingService _itemMasterForFarmingService;
		private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly ISectorService _sectorService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategory1Service _subCategory1Service;
        private readonly ISubCategory2Service _subCategory2Service;
        private readonly IWareHouseService _wareHouseService;
        private readonly IEmployeeService _employeeService;
        private readonly IVendorService _vendorService;
        private readonly IDistrictService _districtService;

        public ItemMasterForFarmingController(IItemMasterForFarmingService itemMasterForFarmingService,
			                                  IWebHostEnvironment hostingEnvironment,
                                              ISectorService sectorService,
                                              ICategoryService categoryService,
                                              ISubCategory1Service subCategory1Service,
                                              ISubCategory2Service subCategory2Service,
											  IWareHouseService wareHouseService,
                                              IEmployeeService employeeService,
                                              IVendorService vendorService,
                                              IDistrictService districtService
                                              )
		{
			_itemMasterForFarmingService = itemMasterForFarmingService;
			_hostingEnvironment = hostingEnvironment;
            _sectorService = sectorService;
            _categoryService = categoryService;
            _subCategory1Service = subCategory1Service;
            _subCategory2Service = subCategory2Service;
			_wareHouseService = wareHouseService;
            _employeeService = employeeService;
            _vendorService = vendorService;
            _districtService = districtService;
        }

		[HttpGet]
		public IActionResult CreateItemMasterForFarming(int? itemMasterForFarmingId)
		{
            //ViewBag.Sectors = _sectorService.GetSectorListforFarmerProduces();
            //ViewBag.Categories = _categoryService.GetCategoryList();
            //ViewBag.SubCategories = _subCategory1Service.GetSubCategory1List();


            var viewForItemMasterFarming = new ViewForItemMasterFarming
            {
                    Sectors = _sectorService.GetSectorListforFarmerProduces(),
                    Categories = _categoryService.GetCategoryList(),
                    SubCategories1 = _subCategory1Service.GetSubCategory1List(),
				    SubCategories2 = _subCategory2Service.GetSubCategory2List(),
			    	WareHouses = _wareHouseService.GetWareHouseList(),
			    	Employees = _employeeService.GetEmployees(),
			    	Vendors = _vendorService.GetVendorList(),
				    Districts = _districtService.GetDistrictList(),

                    CreatedItemMasterFarmingDTO = new ItemMasterForFarmingDTO()
                };


            //ItemMasterForFarmingDTO itemMaster = new ItemMasterForFarmingDTO();

			if (itemMasterForFarmingId != null)
			{
				var itemMaster1 = _itemMasterForFarmingService.GetItemMasterForFarmingByItemMasterForFarmingId(int.Parse(itemMasterForFarmingId.ToString()));

                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.SectorId = itemMaster1.SectorId;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.CategoryId = itemMaster1.CategoryId;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.SubCategory1Id = itemMaster1.SubCategory1Id;

				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.SubCategory2Id = itemMaster1.SubCategory2Id;
				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.WareHouseName = itemMaster1.WareHouseName;
				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.EmployeeName = itemMaster1.EmployeeName;
				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.VendorName = itemMaster1.VendorName;
				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.DistrictName = itemMaster1.DistrictName;

				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.Barcode = itemMaster1.Barcode;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ItemMasterForFarmingId = itemMasterForFarmingId;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.BarCodeNotAvailable = itemMaster1.BarCodeNotAvailable;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.UnitId = itemMaster1.UnitId;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ProductName = itemMaster1.ProductName;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.QtyPerKg = itemMaster1.QtyPerKg;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.Price = itemMaster1.Price;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.MinQty = itemMaster1.MinQty;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.GST = itemMaster1.GST;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.HSN = itemMaster1.HSN;
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.HarvestDate = itemMaster1.HarvestDate;

				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.InvoiceNo = itemMaster1.InvoiceNo;
				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ReceivedDate = itemMaster1.ReceivedDate;

				viewForItemMasterFarming.CreatedItemMasterFarmingDTO.Thumbnail = itemMaster1.Thumbnail;

				if (!string.IsNullOrEmpty(itemMaster1.Images))
				{
                    // Split the string into a list of images
                    viewForItemMasterFarming.CreatedItemMasterFarmingDTO.Images = itemMaster1.Images.Split(',').ToList();
				}
				else
				{
                    viewForItemMasterFarming.CreatedItemMasterFarmingDTO.Images = new List<string>();
				}

			}

			return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingCreate.cshtml", viewForItemMasterFarming);
		}


        [HttpPost]
        public IActionResult CreateItemMasterForFarming(ViewForItemMasterFarming viewForItemMasterFarming)
        {
            viewForItemMasterFarming.CreatedItemMasterFarmingDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            TempData.Clear();

            string btnSave = Request.Form["btnSave"];
            string btnGenerateBarcode = Request.Form["btnGenerateBarcode"];

            if (viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ThumbnailUp != null)
            {
                FileInfo fileInfo = new FileInfo(viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ThumbnailUp.FileName);
                string extn = fileInfo.Extension.ToLower();
                Guid id = Guid.NewGuid();
                string filename = id.ToString() + extn;


                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/farmingimage");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                viewForItemMasterFarming.CreatedItemMasterFarmingDTO.Thumbnail = uniqueFileName;
            }


            if (viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ImagesUp != null && viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ImagesUp.Count > 0)
            {
                foreach (var image in viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ImagesUp)
                {
                    if (image != null && image.Length > 0)
                    {
                        // Get file extension
                        string extn = Path.GetExtension(image.FileName).ToLower();

                        // Generate unique filename
                        Guid id = Guid.NewGuid();
                        string filename = id.ToString() + extn;

                        // Construct the full path to save the file
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/farmingimage");
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
                        viewForItemMasterFarming.CreatedItemMasterFarmingDTO.Images.Add(uniqueFileName); // Assuming Images is a List<string> or similar
                    }
                }
            }



            if (btnGenerateBarcode != null)
            {
                var barcodeResult = GenerateBarcodeButton(viewForItemMasterFarming, btnGenerateBarcode);
                if (barcodeResult is ViewResult)
                {
                    return barcodeResult;
                }
            }


            if (viewForItemMasterFarming.CreatedItemMasterFarmingDTO.ItemMasterForFarmingId == null)
            {
                if (btnSave != null)
                {
                    var createdItemMasterFarmingDTO = _itemMasterForFarmingService.CreateItemMasterForFarming(viewForItemMasterFarming.CreatedItemMasterFarmingDTO);

                    if (createdItemMasterFarmingDTO != null && viewForItemMasterFarming.CreatedItemMasterFarmingDTO.BarCodeNotAvailable == true)
                    {
                        //TempData["msg"] = MessageEnum.Success;


                        var viewForItemMasterFarming1 = new ViewForItemMasterFarming
                        {
                            CreatedItemMasterFarmingDTO = createdItemMasterFarmingDTO,
                            Sectors = _sectorService.GetSectorListforFarmerProduces(),
                            Categories = _categoryService.GetCategoryList(),
                            SubCategories1 = _subCategory1Service.GetSubCategory1List(),
							SubCategories2 = _subCategory2Service.GetSubCategory2List(),
							WareHouses = _wareHouseService.GetWareHouseList(),
                            Employees = _employeeService.GetEmployees(),
                            Vendors = _vendorService.GetVendorList(),
                            Districts = _districtService.GetDistrictList(),
                        };

                        return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingCreate.cshtml", viewForItemMasterFarming1);
                    }
                    else if (createdItemMasterFarmingDTO != null && viewForItemMasterFarming.CreatedItemMasterFarmingDTO.BarCodeNotAvailable == false)
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
                var a = _itemMasterForFarmingService.UpdateItemMasterForFarming(viewForItemMasterFarming.CreatedItemMasterFarmingDTO);
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

            //ViewBag.Sectors = _sectorService.GetSectorListforFarmerProduces();
            //ViewBag.Categories = _categoryService.GetCategoryList();
            //ViewBag.SubCategories = _subCategory1Service.GetSubCategory1List();


            //Continue with the rest of your logic or return the view as needed
            return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingView.cshtml", ViewBag.Items);


        }


        [HttpPost]
        public IActionResult GenerateBarcodeButton(ViewForItemMasterFarming viewForItemMasterFarming, string btnGenerateBarcode)
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
                var viewForItemMasterFarming1 = new ViewForItemMasterFarming
                {
                    CreatedItemMasterFarmingDTO = viewForItemMasterFarming.CreatedItemMasterFarmingDTO,
                    Sectors = _sectorService.GetSectorListforFarmerProduces(),
                    Categories = _categoryService.GetCategoryList(),
                    SubCategories1 = _subCategory1Service.GetSubCategory1List(),
					SubCategories2 = _subCategory2Service.GetSubCategory2List(),
					WareHouses = _wareHouseService.GetWareHouseList(),
                    Employees = _employeeService.GetEmployees(),
                    Vendors = _vendorService.GetVendorList(),
                    Districts = _districtService.GetDistrictList(),

                };


                return View("~/Plugins/Warehouse.Management/Views/Item/ItemMasterForFarmingCreate.cshtml", viewForItemMasterFarming1);
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
