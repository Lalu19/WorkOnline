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
using CloudVOffice.Services.Distributors;
using CloudVOffice.Data.DTO.Distributor;

namespace Distributor_partner.Controllers
{
    public class DistributorSignupController : Controller
    {
        private readonly IUserAuthenticationService _userauthenticationService;
        private readonly ICompanyDetailsService _companyDetailsService;
        private readonly IDistributorRegistrationService _distributorRegistrationService;
        private readonly ICategoryService _categoryService;
        private readonly ApplicationDBContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly IPinCodeService _pinCodeService;
        private readonly IWareHouseService _wareHouseService;
        private readonly ISectorService _sectorService;

        public DistributorSignupController(IUserAuthenticationService userauthenticationService,
                                      IDistributorRegistrationService distributorRegistrationService,
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
            _distributorRegistrationService = distributorRegistrationService;
            _categoryService = categoryService;
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
            _pinCodeService = pinCodeService;
            _wareHouseService = wareHouseService;
            _sectorService = sectorService;
        }
        public IActionResult DistributorSignupPage()
        {
            ViewBag.PinList = _pinCodeService.GetPinList();
            ViewBag.WareHouseList = _wareHouseService.GetWareHouseList(); ;
            ViewBag.SectorList = _sectorService.GetSectorList();

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> DistributorSignupPage(DistributorRegistrationDTO distributorRegistrationDTO)
        {

            if (distributorRegistrationDTO.ImageUp != null)
            {
                FileInfo fileInfo = new FileInfo(distributorRegistrationDTO.ImageUp.FileName);
                string extn = fileInfo.Extension.ToLower();
                Guid id = Guid.NewGuid();
                string filename = id.ToString() + extn;

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/DistributorRegistration");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                distributorRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                distributorRegistrationDTO.Image = uniqueFileName;
            }

            if (distributorRegistrationDTO.DistributorRegistrationId == null)
            {
                var a = _distributorRegistrationService.DistributorRegistrationCreate(distributorRegistrationDTO);

                if (a != null)
                {
                    TempData["msg"] = MessageEnum.Success;

                    return Redirect("/DistributorPartner/DistributorLogin");

                }
                //else if (a == MessageEnum.Duplicate)
                //{

                //    TempData["msg"] = MessageEnum.Duplicate;
                //    ModelState.AddModelError("", "Mobile Number Already Exists");

                //}
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
