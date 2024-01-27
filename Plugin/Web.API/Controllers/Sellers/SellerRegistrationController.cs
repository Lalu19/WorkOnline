using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Services.Buyers;
using CloudVOffice.Services.Sellers;
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
    public class SellerRegistrationController : Controller
    {

        private readonly ISellerRegistrationService _sellerRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SellerRegistrationController(ISellerRegistrationService sellerRegistrationService, IWebHostEnvironment hostingEnvironment)
        {
            _sellerRegistrationService = sellerRegistrationService;
            _hostingEnvironment = hostingEnvironment;
        }
        //[HttpPost]
        //public IActionResult SellerSigninCreate(SellerRegistrationDTO sellerRegistrationDTO)
        //{
        //    try
        //    {
        //        var a = _sellerRegistrationService.SellerRegistrationCreate(sellerRegistrationDTO);
        //        return Ok(a);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpPost]
        public IActionResult SellerSigninCreate([FromForm] SellerRegistrationDTO sellerRegistrationDTO)
        {

            if (sellerRegistrationDTO.ImageUp != null)
            {
                FileInfo fileInfo = new FileInfo(sellerRegistrationDTO.ImageUp.FileName);
                string extn = fileInfo.Extension.ToLower();
                Guid id = Guid.NewGuid();
                string filename = id.ToString() + Path.GetExtension(sellerRegistrationDTO.ImageUp.FileName);

                //string filename = id.ToString() + extn;
                string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\SellerSnaps\" + sellerRegistrationDTO.CreatedBy.ToString());
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Copy the uploaded image to the specified path
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    sellerRegistrationDTO.ImageUp.CopyTo(stream);
                }

                sellerRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                //sellerRegistrationDTO.Image = Path.Combine("uploads", "buyerregistrations", sellerRegistrationDTO.CreatedBy.ToString(), filename);
                sellerRegistrationDTO.Image = filename;
                //if (fileInfo.Exists)
                //{
                //    sellerRegistrationDTO.FileSize = fileInfo.Length;
                //}

            }
            var a = _sellerRegistrationService.SellerRegistrationCreate(sellerRegistrationDTO);


            return Ok(a);
        }


        [HttpGet]
        public IActionResult SellerSigninList()
        {
            var a = _sellerRegistrationService.GetSellerRegistrationList();
            return Ok(a);
        }
    }
}
