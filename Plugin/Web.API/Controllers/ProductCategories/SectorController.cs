using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Services.ProductCategories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.ProductCategories
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SectorController : Controller
    {
        private readonly ISectorService _sectorService;
        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }
        [HttpPost]
        public IActionResult SectorCreate(SectorDTO sectorDTO)
        {
            try
            {
                var a = _sectorService.SectorCreate(sectorDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult SectorList()
        {
            var a = _sectorService.GetSectorList();
            return Ok(a);
        }

    }
}
