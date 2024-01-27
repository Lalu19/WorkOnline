using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using CloudVOffice.Services.Sellers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Sellers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class SellerFarmingProductController : Controller
	{
		private readonly ISellerFarmingProductService _sellerFarmingProductService;
		public SellerFarmingProductController(ISellerFarmingProductService sellerFarmingProductService)
		{
			_sellerFarmingProductService = sellerFarmingProductService;
		}


		[HttpPost]
		public IActionResult CreateSellerFarmingProduct(SellerFarmingProductDTO sellerFarmingProductDTO)
		{
			try
			{
				var a = _sellerFarmingProductService.SellerFarmingProductCreate(sellerFarmingProductDTO);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}
		[HttpGet]
		public IActionResult SellerFarmingProductList()
		{
			var a = _sellerFarmingProductService.GetSellerFarmingProductList();
			return Ok(a);
		}
		[HttpGet("{sellerFarmingProductId}")]
		public IActionResult SellerFarmingProductListbyId(Int64 sellerFarmingProductId)
		{
			var a = _sellerFarmingProductService.GetSellerFarmingProductById(sellerFarmingProductId);
			return Ok(a);
		}
		[HttpPost]
		public IActionResult UpdateSellerFarmingProduct(SellerFarmingProductDTO sellerFarmingProductDTO)
		{
			try
			{
				var a = _sellerFarmingProductService.SellerFarmingProductUpdate(sellerFarmingProductDTO);
				return Ok(a);
			}
			catch (Exception ex)
			{
				return Accepted(new { Status = "error", ResponseMsg = ex.Message });
			}
		}

		[HttpGet("{sellerFarmingProductId}/{DeletedBy}")]
		public ActionResult DeleteSellerFarmingProduct(Int64 sellerFarmingProductId, int DeletedBy)
		{
			var a = _sellerFarmingProductService.SellerFarmingProductDelete(sellerFarmingProductId, DeletedBy);
			return Ok(a);
		}
	}
}
