using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.Distributor;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Services.Distributors;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.Users;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.PinCodes;
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
    public class DistributorAssignController : BasePluginController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IDistributorRegistrationService _DistributorRegistrationService;
        private readonly IUserWareHouseMappingService _UserWareHouseMappingService;
        private readonly ISellerRegistrationService _sellerRegistrationService;
        private readonly ISectorService _SectorService;
        private readonly IPinCodeService _pinCodeService;
        private readonly IBrandService _BrandService;
        private readonly IPinCodeMappingService _PinCodeMappingService;
        private readonly IWareHouseService  _WareHouseService;
        private readonly IDistributorsAssignService _DistributorsAssignService;
        public DistributorAssignController(IWebHostEnvironment hostingEnvironment,
            IDistributorRegistrationService DistributorRegistrationService,
            IUserWareHouseMappingService UserWareHouseMappingService, ISellerRegistrationService sellerRegistrationService,
            ISectorService SectorService, IPinCodeService pinCodeService, IBrandService BrandService,
            IPinCodeMappingService PinCodeMappingService, IWareHouseService WareHouseService, IDistributorsAssignService distributorsAssignService)
        {
            _hostingEnvironment = hostingEnvironment;
            _DistributorRegistrationService = DistributorRegistrationService;
            _UserWareHouseMappingService = UserWareHouseMappingService;
            _sellerRegistrationService = sellerRegistrationService;
            _SectorService = SectorService;
            _pinCodeService = pinCodeService;
            _BrandService = BrandService;
            _PinCodeMappingService = PinCodeMappingService;
            _WareHouseService = WareHouseService;
            _DistributorsAssignService = distributorsAssignService;
        }
        [HttpGet]
        public IActionResult DistributorAssign()
        {
            Int64 UserId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            var Warehousedetails = _UserWareHouseMappingService.GetWareHouseByUserId(UserId);
            ViewBag.distributorlist = _DistributorRegistrationService.getdistibutorlistbywarehouseId(Warehousedetails.WareHuoseId);

            return View("~/Plugins/Warehouse.Management/Views/Distributor/DistributorAssign.cshtml");
        }
        [HttpPost]
        public IActionResult DistributorAssign(DistributorAssignDTO DistributorAssignDTO)
        {
            Int64 UserId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            var Warehousedetails = _UserWareHouseMappingService.GetWareHouseByUserId(UserId);
            ViewBag.distributorlist = _DistributorRegistrationService.getdistibutorlistbywarehouseId(Warehousedetails.WareHuoseId);
            

            DistributorAssignDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (DistributorAssignDTO.DistributorAssignId == null)
                {
                    var a = _DistributorsAssignService.DistributorAssign(DistributorAssignDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/DistributorAssign/DistributorAssignView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "DistributorAssign Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                //else
                //{
                //    var a = _DistributorsAssignService.DistributorAssign(DistributorAssignDTO);
                //    if (a == MessageEnum.Updated)
                //    {
                //        TempData["msg"] = MessageEnum.Updated;
                //        return Redirect("/WareHouse/DistributorAssign/DistributorAssignView");

                //    }
                //    else if (a == MessageEnum.Duplicate)
                //    {
                //        TempData["msg"] = MessageEnum.Duplicate;
                //        ModelState.AddModelError("", "Distributor Already Exists");
                //    }
                //    else
                //    {
                //        TempData["msg"] = MessageEnum.UnExpectedError;
                //        ModelState.AddModelError("", "Un-Expected Error");
                //    }
                //}
            }

            return View("~/Plugins/Warehouse.Management/Views/Distributor/DistributorAssign.cshtml", DistributorAssignDTO);
        }


        public IActionResult DistributorAssignView()
        {
            Int64 UserId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            var Warehousedetails = _UserWareHouseMappingService.GetWareHouseByUserId(UserId);
            ViewBag.dsView = _DistributorsAssignService.DAssignListbyWareHouseId(Warehousedetails.WareHuoseId);

            return View("~/Plugins/Warehouse.Management/Views/Distributor/DistributorAssignView.cshtml");
        }

        [HttpGet]
        public IActionResult DeletaDistributorAssign(Int64 DistributorAssignId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _DistributorsAssignService.DistributorAssignDelete(DistributorAssignId, DeletedBy);
            return Redirect("/WareHouse/DistributorAssign/DistributorAssignView");
        }
    }
}
