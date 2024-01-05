using CloudVOffice.Core.Domain.Banners;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Services.Banners;
using CloudVOffice.Services.WareHouses.Brands;
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
	public class BannerController : BasePluginController
	{
		private readonly IBannerService _bannerService;
		private readonly IWebHostEnvironment _hostingEnvironment;
		public BannerController(IBannerService bannerService, IWebHostEnvironment hostingEnvironment)
		{
			_bannerService = bannerService;
			_hostingEnvironment = hostingEnvironment;
		}
		[HttpGet]
		public IActionResult BannerCreate(Int64? bannerId)
		{
			BannerDTO bannerDTO = new BannerDTO();
			if (bannerId != null)
			{
				Banner d = _bannerService.GetBannerById(int.Parse(bannerId.ToString()));
				bannerDTO.BannerName = d.BannerName;
				bannerDTO.BannerImage = d.BannerImage;
			}
			return View("~/Plugins/Warehouse.Management/Views/Banner/BannerCreate.cshtml", bannerDTO);
		}
		[HttpPost]
		public IActionResult BannerCreate(BannerDTO bannerDTO)
		{
			bannerDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			if (ModelState.IsValid)
			{
				if (bannerDTO.BannerImageUp != null)
				{
					FileInfo fileInfo = new FileInfo(bannerDTO.BannerImageUp.FileName);
					string extn = fileInfo.Extension.ToLower();
					Guid id = Guid.NewGuid();
					string filename = id.ToString() + extn;

					string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Bannerimages");
					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}
					string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
					string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
					bannerDTO.BannerImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
					bannerDTO.BannerImage = uniqueFileName;
				}
				if (bannerDTO.BannerId == null)
				{
					var a = _bannerService.CreateBanner(bannerDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/Banner/BannerView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Banner Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _bannerService.UpdateBanner(bannerDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/Banner/BannerView");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Banner Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
			return View("~/Plugins/Warehouse.Management/Views/Banner/BannerCreate.cshtml", bannerDTO);

		}

		public IActionResult BannerView()
		{
			ViewBag.Banners = _bannerService.GetBannerList();

			return View("~/Plugins/Warehouse.Management/Views/Banner/BannerView.cshtml");
		}

		[HttpGet]
		public IActionResult BannerDelete(Int64 bannerId)
		{
			Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			var a = _bannerService.DeleteBanner(bannerId, DeletedBy);
			return Redirect("/WareHouse/Banner/BannerView");
		}

	}
}
