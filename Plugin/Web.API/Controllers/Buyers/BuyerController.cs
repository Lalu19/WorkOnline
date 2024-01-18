using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Web.API.DTO;
using Web.API.Model.Buyers;


namespace Web.API.Controllers.Buyers
{
    public class BuyerController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IBuyerProvider _buyerProvider;
        public BuyerController(IWebHostEnvironment hostingEnvironment,
                                            IBuyerProvider buyerProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _buyerProvider = buyerProvider;
        }
        [HttpPost]
        public IActionResult BuyerShopimageCreate(BuyerDTO buyerDTO)
        {
            if (buyerDTO.file != null)
            {
                string filename = ContentDispositionHeaderValue.Parse(buyerDTO.file.ContentDisposition).FileName.Trim('"');
                filename = EnsureCorrectFilename(filename);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                buyerDTO.file.CopyTo(new FileStream(imagePath, FileMode.Create));
                string photopath = "/images/" + uniqueFileName;
                BuyerNewDTO ag = new BuyerNewDTO();
                ag.Name = buyerDTO.Name;
               // ag.DateOfBirth = buyerDTO.DateOfBirth;
               // ag.Address = buyerDTO.Address;
               // ag.PinCodeId = buyerDTO.PinCodeId;
               // ag.Country = buyerDTO.Country;
               // ag.State = buyerDTO.State;
               // ag.PrimaryPhone = buyerDTO.PrimaryPhone;
               // ag.AlternatePhone = buyerDTO.AlternatePhone;
               // ag.MailId = buyerDTO.MailId;
               // ag.SalesRepresentativeId = buyerDTO.SalesRepresentativeId;
               // ag.SalesRepresentativeContact = buyerDTO.SalesRepresentativeContact;
               // ag.GSTNumber = buyerDTO.GSTNumber;
               // ag.WareHuoseId = buyerDTO.WareHuoseId;
               //// ag.FirstLogin = buyerDTO.FirstLogin;
               // ag.SectorId = buyerDTO.SectorId;
               // ag.ShopImage = photopath;
                ag.CreatedBy = buyerDTO.CreatedBy;

                var a = _buyerProvider.BuyerregCreate(ag);

                return Ok(a);
            }
            else
            {
                BuyerNewDTO ag = new BuyerNewDTO();
                ag.Name = buyerDTO.Name;
               // ag.DateOfBirth = buyerDTO.DateOfBirth;
               // ag.Address = buyerDTO.Address;
               // ag.PinCodeId = buyerDTO.PinCodeId;
               // ag.Country = buyerDTO.Country;
               // ag.State = buyerDTO.State;
               // ag.PrimaryPhone = buyerDTO.PrimaryPhone;
               // ag.AlternatePhone = buyerDTO.AlternatePhone;
               // ag.MailId = buyerDTO.MailId;
               // ag.SalesRepresentativeId = buyerDTO.SalesRepresentativeId;
               // ag.SalesRepresentativeContact = buyerDTO.SalesRepresentativeContact;
               // ag.GSTNumber = buyerDTO.GSTNumber;
               // ag.WareHuoseId = buyerDTO.WareHuoseId;
               //// ag.FirstLogin = buyerDTO.FirstLogin;
               // ag.SectorId = buyerDTO.SectorId;
               // //ag.AgentSelfie = photopath;
                ag.CreatedBy = buyerDTO.CreatedBy;

                var a = _buyerProvider.BuyerregCreate(ag);

                return Ok(a);
            }

        }
        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }
    }
}
