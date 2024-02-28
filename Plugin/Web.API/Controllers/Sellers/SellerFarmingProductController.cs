using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using CloudVOffice.Services.Sellers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using NUglify.JavaScript.Syntax;
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
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SellerFarmingProductController(ISellerFarmingProductService sellerFarmingProductService,
                                             IWebHostEnvironment hostingEnvironment
                                             )
		{
			_sellerFarmingProductService = sellerFarmingProductService;
			_hostingEnvironment = hostingEnvironment;
		}


		[HttpPost]
		public IActionResult CreateSellerFarmingProduct([FromForm] SellerFarmingProductDTO sellerFarmingProductDTO)
		{
			try
			{
                if (sellerFarmingProductDTO.ThumbnailUp != null)
                {
                    FileInfo fileInfo = new FileInfo(sellerFarmingProductDTO.ThumbnailUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(sellerFarmingProductDTO.ThumbnailUp.FileName);

                    string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\SellerFarmingThumbnail\" + sellerFarmingProductDTO.CreatedBy.ToString());
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        sellerFarmingProductDTO.ThumbnailUp.CopyTo(stream);
                    }

                    sellerFarmingProductDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    sellerFarmingProductDTO.Thumbnail = filename;

                }

                if (sellerFarmingProductDTO.ImagesUp != null && sellerFarmingProductDTO.ImagesUp.Count > 0)
                {
                    foreach (var image in sellerFarmingProductDTO.ImagesUp)
                    {
                        if (image != null && image.Length > 0)
                        {
                            string extn = Path.GetExtension(image.FileName).ToLower();

                            Guid id = Guid.NewGuid();
                            string filename = id.ToString() + extn;

                            string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/SellerFarmingImages/{newpath}");
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

                            sellerFarmingProductDTO.Images.Add(uniqueFileName);
                        }
                    }
                }


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

		[HttpGet("{SellerRegistrationId}")]
		public IActionResult GetSellerFarmingProductBySellerId(int SellerRegistrationId)
		{
			var a = _sellerFarmingProductService.GetSellerFarmingProductBySellerId(SellerRegistrationId);
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
