using CloudVOffice.Services.Distributors;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.Users;
using CloudVOffice.Services.WareHouse.PinCodes;
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
        public DistributorAssignController(IWebHostEnvironment hostingEnvironment,
            IDistributorRegistrationService DistributorRegistrationService,
            IUserWareHouseMappingService UserWareHouseMappingService, ISellerRegistrationService sellerRegistrationService,
            ISectorService SectorService, IPinCodeService pinCodeService, IBrandService BrandService,
            IPinCodeMappingService PinCodeMappingService)
        {
            _hostingEnvironment = hostingEnvironment;
            _DistributorRegistrationService = DistributorRegistrationService;
            _UserWareHouseMappingService = UserWareHouseMappingService;
            _sellerRegistrationService = sellerRegistrationService;
            _SectorService = SectorService;
            _pinCodeService = pinCodeService;
            _BrandService = BrandService;
            _PinCodeMappingService = PinCodeMappingService;
        }

    }
}
