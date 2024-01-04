using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Services.Buyers;
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
    public class SellerRegistrationController : Controller
    {

        private readonly ISellerRegistrationService _sellerRegistrationService;
        public SellerRegistrationController(ISellerRegistrationService sellerRegistrationService)
        {
            _sellerRegistrationService = sellerRegistrationService;
        }
        [HttpPost]
        public IActionResult SellerSigninCreate(SellerRegistrationDTO sellerRegistrationDTO)
        {
            try
            {
                var a = _sellerRegistrationService.SellerRegistrationCreate(sellerRegistrationDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult SellerSigninList()
        {
            var a = _sellerRegistrationService.GetSellerRegistrationList();
            return Ok(a);
        }
    }
}
