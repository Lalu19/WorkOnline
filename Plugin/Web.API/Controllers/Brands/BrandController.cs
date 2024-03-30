using CloudVOffice.Data.DTO.Banners;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Services.Banners;
using CloudVOffice.Services.WareHouses.Brands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Brands
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class BrandController : Controller
	{
		private readonly IBrandService _brandService;
		public BrandController(IBrandService brandService)
		{
			_brandService = brandService;
		}
		[HttpPost]
		public IActionResult BrandCreate(BrandDTO brandDTO)
		{
			try
			{
				var a = _brandService.BrandCreate(brandDTO);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}

		[HttpGet]
		public IActionResult BrandList()
		{
			var a = _brandService.GetBrandList();
			return Ok(a);
		}

		[HttpGet("{PincodeId}/{SectorId}")]
		public IActionResult BrandListbyPincodeIdSectorId(Int64 PincodeId, int SectorId)
		{
			var a = _brandService.GetBrandListByPincodeIdSectorId(PincodeId, SectorId);
			return Ok(a);
		}

		[HttpGet("{brandId}")]
		public IActionResult SingleBannerListbyId(Int64 brandId)
		{
			var a = _brandService.GetBrandById(brandId);
			return Ok(a);
		}
	

	}
}
