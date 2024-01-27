using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Services.Buyers;
using CloudVOffice.Services.ProductCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Buyers  
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuyerRegistrationController : Controller
    {
        private readonly IBuyerRegistrationService _buyerRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public BuyerRegistrationController(IBuyerRegistrationService buyerRegistrationService, IWebHostEnvironment hostingEnvironment)
        {
            _buyerRegistrationService = buyerRegistrationService;
            _hostingEnvironment = hostingEnvironment;
        }
        //[HttpPost]
        //public IActionResult BuyerSigninCreate(BuyerRegistrationDTO buyerRegistrationDTO)
        //{
        //    try
        //    {
        //        var a = _buyerRegistrationService.CreateBuyerRegistration(buyerRegistrationDTO);
        //        return Ok(a);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        [HttpPost]
        public IActionResult BuyerSigninCreate([FromForm] BuyerRegistrationDTO buyerRegistrationDTO)
        {
           
            if (buyerRegistrationDTO.imageUpload != null)
            {
                FileInfo fileInfo = new FileInfo(buyerRegistrationDTO.imageUpload.FileName);
                string extn = fileInfo.Extension.ToLower();
                Guid id = Guid.NewGuid();
                string filename = id.ToString() + Path.GetExtension(buyerRegistrationDTO.imageUpload.FileName);

                //string filename = id.ToString() + extn;
                string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\BuyerSnaps\" + buyerRegistrationDTO.CreatedBy.ToString());
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Copy the uploaded image to the specified path
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    buyerRegistrationDTO.imageUpload.CopyTo(stream);
                }

                buyerRegistrationDTO.imageUpload.CopyTo(new FileStream(imagePath, FileMode.Create));
                //buyerRegistrationDTO.ShopImage = Path.Combine("uploads", "buyerregistrations", buyerRegistrationDTO.CreatedBy.ToString(), filename);
                buyerRegistrationDTO.ShopImage = filename;
                //if (fileInfo.Exists)
                //{
                //    buyerRegistrationDTO.FileSize = fileInfo.Length;
                //}

            }
            var a = _buyerRegistrationService.CreateBuyerRegistration(buyerRegistrationDTO);


            return Ok(a);
        }

        [HttpGet]
        public IActionResult BuyerSigninList()
        {
            var a = _buyerRegistrationService.GetBuyerRegistrationList();
            return Ok(a);
        }

    }
}
