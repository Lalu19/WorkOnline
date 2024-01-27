using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.HandlingTypes;
using CloudVOffice.Services.WareHouses.UOMs;
using Microsoft.AspNetCore.Mvc;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.WareHouses.GSTs;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Items;

namespace Seller_Login.Web.Controllers
{
   
    public class SellerProductEntryController : Controller
    {
        private readonly ISellerProductEntryService _sellerProductEntryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IGSTService _gstService;
        private readonly IHandlingTypeService _handlingTypeService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategory1Service _subCategory1Service;
        private readonly ISubCategory2Service _subCategory2Service;
        private readonly IUnit _unitService;
        private readonly IBrandService _brandService;
		

		public SellerProductEntryController(ISellerProductEntryService sellerProductEntryService, 
                                            IWebHostEnvironment hostingEnvironment,
                                            IHandlingTypeService handlingTypeService,
                                            ICategoryService categoryService,
                                            ISubCategory1Service subCategory1Service,
                                            ISubCategory2Service subCategory2Service,
                                            IUnit unitService,
                                            IBrandService brandService,
                                            IGSTService gstService
										   )
        {

            _sellerProductEntryService = sellerProductEntryService;
            _hostingEnvironment= hostingEnvironment;
            _handlingTypeService= handlingTypeService;
            _categoryService= categoryService;
            _subCategory1Service= subCategory1Service;
            _subCategory2Service= subCategory2Service;
            _unitService= unitService;
            _brandService= brandService;
            _gstService= gstService;
			
		}
        [HttpGet]
        public IActionResult SellerProductEntryCreate(int? sellerProductEntryId)
        {

            ViewBag.Categories = _categoryService.GetCategoryList();
            ViewBag.SubCategories1 = _subCategory1Service.GetSubCategory1List();
            ViewBag.SubCategories2 = _subCategory2Service.GetSubCategory2List();
            ViewBag.Unit = _unitService.GetUnit();
            ViewBag.Brands = _brandService.GetBrandList();
            ViewBag.GSTs = _gstService.GetGSTList();
            ViewBag.handlingtypes = _handlingTypeService.GetHandlingTypeList();

            SellerProductEntryDTO sellerProductEntryDTO = new SellerProductEntryDTO();
            if (sellerProductEntryId != null)
            {

                SellerProductEntry d = _sellerProductEntryService.GetSellerProductEntryById(int.Parse(sellerProductEntryId.ToString()));

                sellerProductEntryDTO.ProductName = d.ProductName;
                sellerProductEntryDTO.SellerProductCode = d.SellerProductCode;
                sellerProductEntryDTO.CategoryId = d.CategoryId;
                sellerProductEntryDTO.SubCategory1Id = d.SubCategory1Id;
                sellerProductEntryDTO.SubCategory2Id = d.SubCategory2Id;
                sellerProductEntryDTO.HSN = d.HSN;
                sellerProductEntryDTO.CompanyName = d.CompanyName;
                sellerProductEntryDTO.BrandId = d.BrandId;
                sellerProductEntryDTO.ProductWeight = d.ProductWeight;
                sellerProductEntryDTO.UnitId = d.UnitId;
                sellerProductEntryDTO.CaseWeight = d.CaseWeight;
                sellerProductEntryDTO.UnitPerCase = d.UnitPerCase;
                sellerProductEntryDTO.ManufactureDate = d.ManufactureDate;
                sellerProductEntryDTO.ExpiryDate = d.ExpiryDate;
                sellerProductEntryDTO.MRP = d.MRP;
                sellerProductEntryDTO.MRPCaseCost = d.MRPCaseCost;
                sellerProductEntryDTO.SalesCost = d.SalesCost;
                sellerProductEntryDTO.GSTId = d.GSTId;
                sellerProductEntryDTO.HandlingTypeId = d.HandlingTypeId;
                sellerProductEntryDTO.Thumbnail = d.Thumbnail;
                if (!string.IsNullOrEmpty(d.Images))
                {
                   
                    sellerProductEntryDTO.Images = d.Images.Split(',').ToList();
                }
                else
                {
                    sellerProductEntryDTO.Images = new List<string>();
                }
            }
            return View();
           // return View("~/Presentation/Seller_Login.Web/Views/SellerProductEntry/SellerProductEntryCreate.cshtml", sellerProductEntryDTO);
        }
        [HttpPost]
        public IActionResult SellerProductEntryCreate(SellerProductEntryDTO sellerProductEntryDTO)
        {
            sellerProductEntryDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (sellerProductEntryDTO.ThumbnailUp != null)
                {
                    FileInfo fileInfo = new FileInfo(sellerProductEntryDTO.ThumbnailUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Thumbnail");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    sellerProductEntryDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    sellerProductEntryDTO.Thumbnail = uniqueFileName;
                }


                if (sellerProductEntryDTO.ImagesUp != null && sellerProductEntryDTO.ImagesUp.Count > 0)
                {
                    foreach (var image in sellerProductEntryDTO.ImagesUp)
                    {
                        if (image != null && image.Length > 0)
                        {
                            string extn = Path.GetExtension(image.FileName).ToLower();
                            Guid id = Guid.NewGuid();
                            string filename = id.ToString() + extn;
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Images");
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
                            sellerProductEntryDTO.Images.Add(uniqueFileName);
                        }
                    }
                }

                if (sellerProductEntryDTO.SellerProductEntryId == null)
                {
                    var a = _sellerProductEntryService.CreateSellerProductEntry(sellerProductEntryDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/SellerProductEntry/SellerProductEntryView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "SellerProductEntry Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _sellerProductEntryService.UpdateSellerProductEntry(sellerProductEntryDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/SellerProductEntry/SellerProductEntryView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "SellerProductEntry Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }

            }

            return View("~/Presentation/Seller_Login.Web/Views/SellerProductEntry/SellerProductEntryCreate.cshtml", sellerProductEntryDTO);
            
        }

        public IActionResult SellerProductEntryView()
        {
            ViewBag.SellerProductEntrys = _sellerProductEntryService.GetSellerProductEntryList();

            return View();
           // return View("~/Presentation/Seller_Login.Web/Views/SellerProductEntry/SellerProductEntryView.cshtml");
        }
        [HttpGet]
        public IActionResult DeleteSellerProductEntry(Int64 sellerProductEntryId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _sellerProductEntryService.DeleteSellerProductEntry(sellerProductEntryId, DeletedBy);
            return Redirect("/SellerProductEntry/SellerProductEntryView");
        }
        
    }
}
