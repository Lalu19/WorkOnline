using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Services.Buyers;
using CloudVOffice.Services.Sales;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers.SalesExecutive
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalesExecutiveRegistrationController : Controller
    {
        private readonly ISalesExecutiveRegistrationService _salesExecutiveRegistrationService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SalesExecutiveRegistrationController(ISalesExecutiveRegistrationService salesExecutiveRegistrationService, IWebHostEnvironment hostingEnvironment)
        {
            _salesExecutiveRegistrationService = salesExecutiveRegistrationService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult SalesExecutiveRegistrationCreate([FromForm] SalesExecutiveRegistrationDTO salesExecutiveRegistrationDTO)
        {
            if (salesExecutiveRegistrationDTO.ImageUp != null)
            {
                FileInfo fileInfo = new FileInfo(salesExecutiveRegistrationDTO.ImageUp.FileName);
                string extn = fileInfo.Extension.ToLower();
                Guid id = Guid.NewGuid();
                string filename = id.ToString() + Path.GetExtension(salesExecutiveRegistrationDTO.ImageUp.FileName);

                //string filename = id.ToString() + extn;
                string newpath = DateTime.Today.Date.ToString("dd-MMM-yyyy");
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\SalesExec\" + salesExecutiveRegistrationDTO.CreatedBy.ToString());
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                string imagePath = Path.Combine(uploadsFolder, uniqueFileName);

                // Copy the uploaded image to the specified path
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    salesExecutiveRegistrationDTO.ImageUp.CopyTo(stream);
                }

                salesExecutiveRegistrationDTO.ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                //buyerRegistrationDTO.ShopImage = Path.Combine("uploads", "buyerregistrations", buyerRegistrationDTO.CreatedBy.ToString(), filename);
                //salesExecutiveRegistrationDTO.ImageUp = filename;
                //if (fileInfo.Exists)
                //{
                //    buyerRegistrationDTO.FileSize = fileInfo.Length;
                //}

            }
            var a = _salesExecutiveRegistrationService.CreateSalesExecutive(salesExecutiveRegistrationDTO);


            return Ok(a);
        }

        [HttpGet]
        public IActionResult GetSalesExecutiveList()
        {
            var a = _salesExecutiveRegistrationService.GetAllSalesExecutiveRegistrations();
            return Ok(a);
        }

        [HttpGet("{SalesExecutiveRegistrationId}")]
        public IActionResult GetSalesExecutiveRegistrationById(int SalesExecutiveRegistrationId)
        {
            var a = _salesExecutiveRegistrationService.GetSalesExecutiveRegistrationsById(SalesExecutiveRegistrationId);
            return Ok(a);
        }

        [HttpGet("{WareHouseId}")]
        public IActionResult GetSalesExecutiveByWareHouseId(int WareHouseId)
        {
            var a = _salesExecutiveRegistrationService.GetSalesExecutiveRegistrationByWarehouseId(WareHouseId);
            return Ok(a);
        }

        //[HttpGet("{SalesExecutiveRegistrationId}")]
        //public IActionResult GetBuyerRegistrationsBySalesExecutiveId(int SalesExecutiveRegistrationId)
        //{
        //    var a = _salesExecutiveRegistrationService.GetSalesExecutiveRegistrationByWarehouseId(SalesExecutiveRegistrationId);
        //    return Ok(a);
        //}

        [HttpGet("{SalesExecutiveUniqueNumber}")]
        public IActionResult GetBuyersBySalesExecutiveUniqueNumber(string SalesExecutiveUniqueNumber)
        {
            var a = _salesExecutiveRegistrationService.GetBuyerRegistrationsBySalesExecutiveUniqueNumber(SalesExecutiveUniqueNumber);
            return Ok(a);
        }

        [HttpGet("{SalesExecutiveRegistrationId}/{DeletedBy}")]
        public ActionResult DeleteSalesExecutive(Int64 SalesExecutiveRegistrationId, Int64 DeletedBy)
        {
            var a = _salesExecutiveRegistrationService.DeleteSalesExecutive(SalesExecutiveRegistrationId, DeletedBy);
            return Ok(a);
        }
    }
}
