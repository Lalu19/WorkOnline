using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.Itemss;
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
        public SellerProductEntryController(ISellerProductEntryService sellerProductEntryService)
        {
            _sellerProductEntryService = sellerProductEntryService;
        }
        [HttpPost]
        public IActionResult CreateSellerProductEntry(SellerProductEntryDTO sellerProductEntryDTO)
        {
            try
            {
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
