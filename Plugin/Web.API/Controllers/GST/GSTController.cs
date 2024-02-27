using CloudVOffice.Data.DTO.WareHouses.GSTs;
using CloudVOffice.Services.WareHouses.GSTs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.GST
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class GSTController : Controller
    {
        private readonly IGSTService _gSTService;
        public GSTController(IGSTService gSTService)
        {
            _gSTService = gSTService;
        }

        [HttpPost]
        public IActionResult GSTCreate(GSTDTO gSTDTO)
        {
            try
            {
                var a = _gSTService.GSTCreate(gSTDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GSTList()
        {
            var a = _gSTService.GetGSTList();
            return Ok(a);
        }

        [HttpGet("{gstId}")]
        public IActionResult GetUnitbyId(Int64 gstId)
        {
            var a = _gSTService.GetGSTByGSTId(gstId);
            return Ok(a);
        }
    }

}
