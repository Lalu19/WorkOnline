using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributors;
using CloudVOffice.Data.DTO.Distributor;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Services.Distributors;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.Users;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class DistributorRegistrationController : BasePluginController
	{
		private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly IDistributorRegistrationService _DistributorRegistrationService;
		private readonly IUserWareHouseMappingService _UserWareHouseMappingService;
        private readonly ISellerRegistrationService _sellerRegistrationService;
        private readonly ISectorService _SectorService;
        private readonly IPinCodeService _pinCodeService;
        public DistributorRegistrationController( IWebHostEnvironment hostingEnvironment,
			IDistributorRegistrationService DistributorRegistrationService,
			IUserWareHouseMappingService UserWareHouseMappingService, ISellerRegistrationService sellerRegistrationService,
            ISectorService SectorService, IPinCodeService pinCodeService)
		{
			_hostingEnvironment = hostingEnvironment;
			_DistributorRegistrationService = DistributorRegistrationService;
			_UserWareHouseMappingService = UserWareHouseMappingService;
            _sellerRegistrationService = sellerRegistrationService;
            _SectorService = SectorService;
            _pinCodeService = pinCodeService;
        }
		[HttpGet]
		public IActionResult DistributorCreate(int? DistributorRegistrationId)
		{
            ViewBag.Sectorlist = _SectorService.GetSectorList();
            ViewBag.PinList = _pinCodeService.GetPinList();
            DistributorRegistrationDTO DistributorRegistrationDTO = new DistributorRegistrationDTO();

			if (DistributorRegistrationId != null)  
			{
				DistributorRegistration DistributorRegistration = _DistributorRegistrationService.getdistibutorlistbyid(int.Parse(DistributorRegistrationId.ToString()));

				DistributorRegistrationDTO.Name = DistributorRegistration.Name;
				DistributorRegistrationDTO.SectorId = DistributorRegistration.SectorId;
				DistributorRegistrationDTO.BusinessName = DistributorRegistration.BusinessName;
				DistributorRegistrationDTO.Address = DistributorRegistration.Address;
				DistributorRegistrationDTO.PinCodeId = DistributorRegistration.PinCodeId;
				DistributorRegistrationDTO.Country = DistributorRegistration.Country;
				DistributorRegistrationDTO.State = DistributorRegistration.State;
				DistributorRegistrationDTO.PrimaryPhone = DistributorRegistration.PrimaryPhone;
				DistributorRegistrationDTO.AlternatePhone = DistributorRegistration.AlternatePhone;
				DistributorRegistrationDTO.MailId = DistributorRegistration.MailId;
				DistributorRegistrationDTO.GSTNumber = DistributorRegistration.GSTNumber;
				DistributorRegistrationDTO.Password = DistributorRegistration.Password;
				DistributorRegistrationDTO.Image = DistributorRegistration.Image;
			}
			return View("~/Plugins/Warehouse.Management/Views/Distributor/DistributorCreate.cshtml", DistributorRegistrationDTO);
		}


		[HttpPost]
		public IActionResult DistributorCreate(DistributorRegistrationDTO DistributorRegistrationDTO)
		{
			Int64 UserId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
			var Warehousedetails = _UserWareHouseMappingService.GetWareHouseByUserId(UserId);
			DistributorRegistrationDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
			DistributorRegistrationDTO.WareHuoseId = Warehousedetails.WareHuoseId;

            if (DistributorRegistrationDTO.ImageUp != null)
            {
                FileInfo fileInfo = new FileInfo(DistributorRegistrationDTO.ImageUp.FileName);
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
                DistributorRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                DistributorRegistrationDTO.Image = uniqueFileName;
            }

            if (DistributorRegistrationDTO.DistributorRegistrationId == null)   
			{
				var a = _DistributorRegistrationService.DistributorRegistrationCreate(DistributorRegistrationDTO);
				if (a == MessageEnum.Success)
				{
					TempData["msg"] = MessageEnum.Success;
					return Redirect("/WareHouse/DistributorRegistration/DistributorView");
				}
				else if (a == MessageEnum.Duplicate)
				{
					TempData["msg"] = MessageEnum.Duplicate;
					ModelState.AddModelError("", "Distributor Already Exists");
				}
				else
				{
					TempData["msg"] = MessageEnum.UnExpectedError;
					ModelState.AddModelError("", "Un-Expected Error");
				}
			}
			else
			{
				var a = _DistributorRegistrationService.DistributorRegistrationCreate(DistributorRegistrationDTO);
				if (a == MessageEnum.Updated)
				{
					TempData["msg"] = MessageEnum.Updated;
					return Redirect("/WareHouse/DistributorRegistration/DistributorView");
				}
				else if (a == MessageEnum.Duplicate)
				{
					TempData["msg"] = MessageEnum.Duplicate;
					ModelState.AddModelError("", "Distributor Already Exists");
				}
				else
				{
					TempData["msg"] = MessageEnum.UnExpectedError;
					ModelState.AddModelError("", "Un-Expected Error");
				}
			}
            ViewBag.Sectorlist = _SectorService.GetSectorList();
            return View("~/Plugins/Warehouse.Management/Views/Distributor/DistributorView.cshtml", DistributorRegistrationDTO);
		}

		[HttpGet]
		public IActionResult DistributorView()
		{
			Int64 UserId = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
			var Warehousedetails = _UserWareHouseMappingService.GetWareHouseByUserId(UserId);
			ViewBag.DistibutorList = _DistributorRegistrationService.getdistibutorlistbywarehouseId(Warehousedetails.WareHuoseId);
            ViewBag.Sectorlist = _SectorService.GetSectorList();
            return View("~/Plugins/Warehouse.Management/Views/Distributor/DistributorView.cshtml");
		}

        [HttpGet]
        public IActionResult DeletaDistributor(Int64 DistributorRegistrationId)
        {
            Int64 deletedby = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
			var a = _DistributorRegistrationService.DistributorDelete(DistributorRegistrationId, deletedby);
            TempData["msg"] = a;
            return Redirect("/WareHouse/DistributorRegistration/DistributorView");
        }
    }
}
