using Microsoft.AspNetCore.Mvc;
using CloudVOffice.Services.Authentication;
using CloudVOffice.Services.Company;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouses;

namespace Seller_Login.Web.Controllers
{
    public class SellerSignupController : Controller
    {
        private readonly IUserAuthenticationService _userauthenticationService;
        private readonly ICompanyDetailsService _companyDetailsService;
        private readonly ISellerRegistrationService _sellerRegistrationService;
        private readonly ICategoryService _categoryService;
        private readonly ApplicationDBContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly IPinCodeService _pinCodeService;
        private readonly IWareHouseService _wareHouseService;
        private readonly ISectorService _sectorService;

        public SellerSignupController(IUserAuthenticationService userauthenticationService,
                                      ISellerRegistrationService sellerRegistrationService,
                                      ICompanyDetailsService companyDetailsService,
                                      ICategoryService categoryService, 
                                      ApplicationDBContext dbContext,
                                      IWebHostEnvironment hostingEnvironment,
                                      IPinCodeService pinCodeService,
                                      IWareHouseService wareHouseService,
                                      ISectorService sectorService
                                     )
        {
            _userauthenticationService = userauthenticationService;
            _companyDetailsService = companyDetailsService;
            _sellerRegistrationService = sellerRegistrationService;
            _categoryService = categoryService;
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _pinCodeService = pinCodeService;
            _wareHouseService = wareHouseService;
            _sectorService = sectorService;
        }
        public IActionResult SellerSignupPage()
        {
            ViewBag.PinList=_pinCodeService.GetPinList();
            ViewBag.WareHouseList = _wareHouseService.GetWareHouseList(); ;
            ViewBag.SectorList = _sectorService.GetSectorList();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SellerSignupPage(SellerRegistrationDTO sellerRegistrationDTO)
        {

            if (sellerRegistrationDTO.ImageUp != null)
            {
                FileInfo fileInfo = new FileInfo(sellerRegistrationDTO.ImageUp.FileName);
                string extn = fileInfo.Extension.ToLower();
                Guid id = Guid.NewGuid();
                string filename = id.ToString() + extn;

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/SellerRegistration");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                sellerRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                sellerRegistrationDTO.Image = uniqueFileName;
            }

            if (sellerRegistrationDTO.SellerRegistrationId == null)
            {
                var a = _sellerRegistrationService.SellerRegistrationCreate(sellerRegistrationDTO);

                if (a == MessageEnum.Success)
                {
                    TempData["msg"] = MessageEnum.Success;

                    return Redirect("/SellerUser/SellerLogin");

                }
                else if (a == MessageEnum.Duplicate)
                {

                    TempData["msg"] = MessageEnum.Duplicate;
                    ModelState.AddModelError("", "Mobile Number Already Exists");

                }
                else
                {

                    TempData["msg"] = MessageEnum.UnExpectedError;
                    ModelState.AddModelError("", "Un-Expected Error");

                }
            }

            ViewBag.PinList = _pinCodeService.GetPinList();
            ViewBag.WareHouseList = _wareHouseService.GetWareHouseList();
            ViewBag.SectorList = _sectorService.GetSectorList();

            return View();
           
        }

    }
}
