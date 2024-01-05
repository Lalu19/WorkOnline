using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Data.DTO.RetailerModel;
using CloudVOffice.Services.Banners;
using CloudVOffice.Services.RetailerModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Banners
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class BannerController : Controller
	{
		private readonly IBannerService _bannerService;
		public BannerController(IBannerService bannerService)
		{
			_bannerService = bannerService;
		}
		[HttpPost]
		public IActionResult BannerCreate(BannerDTO bannerDTO)
		{
			try
			{
				var a = _bannerService.CreateBanner(bannerDTO);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}
		[HttpGet]
		public IActionResult BannerList()
		{
			var a = _bannerService.GetBannerList();
			return Ok(a);
		}
		[HttpGet("{bannerId}")]
		public IActionResult SingleBannerListbyId(Int64 bannerId)
		{
			var a = _bannerService.GetBannerById(bannerId);
			return Ok(a);
		}
		[HttpPost]
		public IActionResult UpdateBanner(BannerDTO bannerDTO)
		{
			try
			{
				var a = _bannerService.UpdateBanner(bannerDTO);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}
		[HttpGet("{bannerId}/{DeletedBy}")]
		public ActionResult DeleteBanner(Int64 bannerId, int DeletedBy)
		{
			var a = _bannerService.DeleteBanner(bannerId, DeletedBy);
			return Ok(a);
		}

	}
}
