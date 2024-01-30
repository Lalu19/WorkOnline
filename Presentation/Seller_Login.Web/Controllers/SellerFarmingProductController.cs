using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.GSTs;
using CloudVOffice.Services.WareHouses.UOMs;
using Microsoft.AspNetCore.Mvc;

namespace Seller_Login.Web.Controllers
{
	public class SellerFarmingProductController : Controller
	{
		private readonly ISellerFarmingProductService _sellerFarmingProductService;
		private readonly IWebHostEnvironment _hostingEnvironment;

		private readonly ICategoryService _categoryService;
		private readonly ISubCategory1Service _subCategory1Service;
		private readonly ISubCategory2Service _subCategory2Service;
		private readonly IUnit _unitService;
		private readonly IBrandService _brandService;
		private readonly IGSTService _gSTService;

		public SellerFarmingProductController(ISellerFarmingProductService sellerFarmingProductService,
											  IWebHostEnvironment hostingEnvironment,
											  ICategoryService categoryService,
											  ISubCategory1Service subCategory1Service,
											  ISubCategory2Service subCategory2Service,
											  IUnit unitService,
											  IBrandService brandService,
											  IGSTService gSTService
											 )
		{
			_sellerFarmingProductService = sellerFarmingProductService;
			_hostingEnvironment = hostingEnvironment;	
			_categoryService = categoryService;
			_subCategory1Service= subCategory1Service;
			_subCategory2Service = subCategory2Service;
			_unitService = unitService;
			_brandService = brandService;
			_gSTService = gSTService;
		}

		[HttpGet]
		public IActionResult CreateSellerFarmingProduct(int? sellerFarmingProductId)
		{
			ViewBag.Category = _categoryService.GetCategoryList();
			ViewBag.SubCategory1 = _subCategory1Service.GetSubCategory1List();
			ViewBag.SubCategory2 = _subCategory2Service.GetSubCategory2List();
			ViewBag.Brand = _brandService.GetBrandList();
			ViewBag.Unit = _unitService.GetUnit();
			ViewBag.GST = _gSTService.GetGSTList();

			SellerFarmingProductDTO sellerFarmingProductDTO = new SellerFarmingProductDTO();

			if (sellerFarmingProductId != null)
			{

				SellerFarmingProduct d = _sellerFarmingProductService.GetSellerFarmingProductById(int.Parse(sellerFarmingProductId.ToString()));
			
				sellerFarmingProductDTO.CategoryId = d.CategoryId;
				sellerFarmingProductDTO.SubCategory1Id = d.SubCategory1Id;
				sellerFarmingProductDTO.SubCategory2Id = d.SubCategory2Id;
				sellerFarmingProductDTO.ProductName = d.ProductName;
				sellerFarmingProductDTO.MinQty = d.MinQty;
				sellerFarmingProductDTO.GSTId = d.GSTId;
				sellerFarmingProductDTO.HSN = d.HSN;
				sellerFarmingProductDTO.Price = d.Price;
				sellerFarmingProductDTO.QtyPerKg = d.QtyPerKg;
				sellerFarmingProductDTO.CompanyName = d.CompanyName;
				sellerFarmingProductDTO.BrandId = d.BrandId;
				sellerFarmingProductDTO.ProductWeight = d.ProductWeight;
				sellerFarmingProductDTO.UnitId = d.UnitId;
				sellerFarmingProductDTO.HarvestDate = d.HarvestDate;

				sellerFarmingProductDTO.Thumbnail=d.Thumbnail;

				if (!string.IsNullOrEmpty(d.Images))
				{
					// Split the string into a list of images
					sellerFarmingProductDTO.Images = d.Images.Split(',').ToList();
				}
				else
				{
					sellerFarmingProductDTO.Images = new List<string>();
				}


			}

			return View();
			
			//return View("~/Presentation/Seller_Login.Web/Views/SellerFarmingProduct/SellerFarmingProductCreate.cshtml", sellerFarmingProductDTO);
		}


		[HttpPost]
		public IActionResult CreateSellerFarmingProduct(SellerFarmingProductDTO sellerFarmingProductDTO)
		{
			sellerFarmingProductDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "SellerRegistrationId").Value.ToString());

			if (ModelState.IsValid)
			{
				if (sellerFarmingProductDTO.ThumbnailUp != null)
				{
					FileInfo fileInfo = new FileInfo(sellerFarmingProductDTO.ThumbnailUp.FileName);
					string extn = fileInfo.Extension.ToLower();
					Guid id = Guid.NewGuid();
					string filename = id.ToString() + extn;

					string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/SellerFarmingThumbnail");
					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}
					string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
					string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
					sellerFarmingProductDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
					sellerFarmingProductDTO.Thumbnail = uniqueFileName;
				}

				if (sellerFarmingProductDTO.ImagesUp != null && sellerFarmingProductDTO.ImagesUp.Count > 0)
				{
					foreach (var image in sellerFarmingProductDTO.ImagesUp)
					{
						if (image != null && image.Length > 0)
						{
							string extn = Path.GetExtension(image.FileName).ToLower();

							Guid id = Guid.NewGuid();
							string filename = id.ToString() + extn;

							string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/SellerFarmingImages");
							if (!Directory.Exists(uploadsFolder))
							{
								Directory.CreateDirectory(uploadsFolder);
							}
							string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
							string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

							using (var fileStream = new FileStream(imagePath, FileMode.Create))
							{
								image.CopyTo(fileStream);
							}

							sellerFarmingProductDTO.Images.Add(uniqueFileName);
						}
					}
				}

				if (sellerFarmingProductDTO.SellerFarmingProductId == null)
				{
					var a = _sellerFarmingProductService.SellerFarmingProductCreate(sellerFarmingProductDTO);
					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/SellerFarmingProduct/SellerFarmingProductView");
					}
					else if (a == MessageEnum.Duplicate)
					{

						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Product Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _sellerFarmingProductService.SellerFarmingProductUpdate(sellerFarmingProductDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/SellerFarmingProduct/SellerFarmingProductView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Product Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}

			ViewBag.Category = _categoryService.GetCategoryList();
			ViewBag.SubCategory1 = _subCategory1Service.GetSubCategory1List();
			ViewBag.SubCategory2 = _subCategory2Service.GetSubCategory2List();
			ViewBag.Brand = _brandService.GetBrandList();
			ViewBag.Unit = _unitService.GetUnit();
			ViewBag.GST = _gSTService.GetGSTList();


            return View();
            //return View("~/Presentation/Seller_Login.Web/Views/SellerFarmingProduct/SellerFarmingProductCreate.cshtml", sellerFarmingProductDTO);
        }


		[HttpGet]
		public IActionResult SellerFarmingProductView()
		{
			ViewBag.SellerFarmingProducts = _sellerFarmingProductService.GetSellerFarmingProductList();

            return View();
            //return View("~/Presentation/Seller_Login.Web/Views/SellerFarmingProduct/SellerFarmingProductView.cshtml");
        }

		[HttpGet]
		public IActionResult DeleteSellerFarmingProduct(Int64 sellerFarmingProductId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "SellerRegistrationId").Value.ToString());

			var a = _sellerFarmingProductService.SellerFarmingProductDelete(sellerFarmingProductId, DeletedBy);
			TempData["msg"] = a;
			return Redirect("/SellerFarmingProduct/SellerFarmingProductView");
		}


        public JsonResult GetCategoryBySectorId(int SectorId)
        {
            int sectorId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "SectorId").Value.ToString());
            var a = _categoryService.GetCategoryBySectorId(sectorId);
            
            return Json(a);
        }

        public JsonResult GetSubCategoryByCategoryId(int CategoryId)
        {
            var a = _subCategory1Service.GetSubCategoryByCategoeyId(CategoryId);
           
            return Json(a);
        }

        public JsonResult GetSubCategory2BySubCategoryId(int SubCategory1Id)
        {
            var a = _subCategory2Service.GetSubCategory2BySubCategory1Id(SubCategory1Id);
          
            return Json(a);
        }
    }
}
