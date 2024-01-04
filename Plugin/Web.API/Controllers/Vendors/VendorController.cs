using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Vendors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Vendors
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;
        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }
        [HttpPost]
        public IActionResult VendorCreate(VendorDTO vendorDTO)
        {
            try
            {
                var a = _vendorService.VendorCreate(vendorDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult VendorList()
        {
            var a = _vendorService.GetVendorList();
            return Ok(a);
        }
        [HttpGet("{vendorId}")]
        public IActionResult SingleVendorListbyId(Int64 vendorId)
        {
            var a = _vendorService.GetVendorByVendorId(vendorId);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateVendor(VendorDTO vendorDTO)
        {
            try
            {
                var a = _vendorService.VendorUpdate(vendorDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{vendorId}/{DeletedBy}")]
        public ActionResult DeleteVendor(Int64 vendorId, int DeletedBy)
        {
            var a = _vendorService.VendorDelete(vendorId, DeletedBy);
            return Ok(a);
        }
    }
}
