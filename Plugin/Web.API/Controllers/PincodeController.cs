using CloudVOffice.Data.DTO.WareHouses;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Services.WareHouse.PinCodes;
using CloudVOffice.Services.WareHouses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PincodeController : Controller
    {
        private readonly IPinCodeService _pincodeService;
        public PincodeController(IPinCodeService pincodeService)
        {
            _pincodeService = pincodeService;
        }
        [HttpPost]
        public IActionResult PincodeCreate(PinCodeDTO pinCodeDTO)
        {
            try
            {
                var a = _pincodeService.PinCodeCreate(pinCodeDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult PIncodeList()
        {
            var a = _pincodeService.GetPinList();
            return Ok(a);
        }

        [HttpGet("{pincodeId}")]
        public IActionResult SinglePincodeListbyId(Int64 pincodeId)
        {
            var a = _pincodeService.GetPinByPinCodeId(pincodeId);
            return Ok(a);
        }



    }
}
