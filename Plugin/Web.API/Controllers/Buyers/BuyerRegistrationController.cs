using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Services.Buyers;
using CloudVOffice.Services.ProductCategories;
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
        public BuyerRegistrationController(IBuyerRegistrationService buyerRegistrationService)
        {
            _buyerRegistrationService = buyerRegistrationService;
        }
        [HttpPost]
        public IActionResult BuyerSigninCreate(BuyerRegistrationDTO buyerRegistrationDTO)
        {
            try
            {
                var a = _buyerRegistrationService.CreateBuyerRegistration(buyerRegistrationDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult BuyerSigninList()
        {
            var a = _buyerRegistrationService.GetBuyerRegistrationList();
            return Ok(a);
        }

    }
}
