using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.AspNetCore.Hosting;
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
    public class SellerProductEntryController:Controller
    {
        private readonly ISellerProductEntryService _sellerProductEntryService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SellerProductEntryController(ISellerProductEntryService sellerProductEntryService, IWebHostEnvironment hostingEnvironment)
        {
            _sellerProductEntryService = sellerProductEntryService;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        public IActionResult CreateSellerProductEntry([FromForm] SellerProductEntryDTO sellerProductEntryDTO)
        {
            try
            {
                if (sellerProductEntryDTO.ThumbnailUp != null)
                {
                    FileInfo fileInfo = new FileInfo(sellerProductEntryDTO.ThumbnailUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + Path.GetExtension(sellerProductEntryDTO.ThumbnailUp.FileName);

                    string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\Thumbnail\" + sellerProductEntryDTO.CreatedBy.ToString());
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        sellerProductEntryDTO.ThumbnailUp.CopyTo(stream);
                    }

                    sellerProductEntryDTO.ThumbnailUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    sellerProductEntryDTO.Thumbnail = filename;

                }

                if (sellerProductEntryDTO.ImagesUp != null && sellerProductEntryDTO.ImagesUp.Count > 0)
                {
                    foreach (var image in sellerProductEntryDTO.ImagesUp)
                    {
                        if (image != null && image.Length > 0)
                        {
                            string extn = Path.GetExtension(image.FileName).ToLower();

                            Guid id = Guid.NewGuid();
                            string filename = id.ToString() + extn;

                            string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, $"uploads/Images/{newpath}");
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

                            sellerProductEntryDTO.Images.Add(uniqueFileName);
                        }
                    }
                }

                var a = _sellerProductEntryService.CreateSellerProductEntry(sellerProductEntryDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpPost]
        public IActionResult UpdateSellerProductEntry(SellerProductEntryDTO sellerProductEntryDTO)
        {
            try
            {
                var a = _sellerProductEntryService.UpdateSellerProductEntry(sellerProductEntryDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult SellerProductEntryList()
        {
            var a = _sellerProductEntryService.GetSellerProductEntryList();
            return Ok(a);
        }
        [HttpGet("{sellerProductEntryId}/{DeletedBy}")]
        public ActionResult DeleteSellerProductEntry(Int64 sellerProductEntryId, Int64 DeletedBy)
        {
            var a = _sellerProductEntryService.DeleteSellerProductEntry(sellerProductEntryId, DeletedBy);
            return Ok(a);
        }
        
    }
}
