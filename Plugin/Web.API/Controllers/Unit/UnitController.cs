using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Data.DTO.WareHouses.UOMs;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.UOMs;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers.Unit
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UnitController : Controller
    {
        private readonly IUnit _unitService;
        public UnitController(IUnit unitService)
        {
            _unitService = unitService;
        }

        [HttpPost]
        public IActionResult UnitCreate(UnitDTO unitDTO)
        {
            try
            {
                var a = _unitService.UnitCreate(unitDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult UnitList()
        {
            var a = _unitService.GetUnit();
            return Ok(a);
        }

        [HttpGet("{unitId}")]
        public IActionResult GetUnitbyId(Int64 unitId)
        {
            var a = _unitService.GetUnitByUnitId(unitId);
            return Ok(a);
        }
    }
}
