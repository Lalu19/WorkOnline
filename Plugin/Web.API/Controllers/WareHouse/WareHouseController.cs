using CloudVOffice.Data.DTO.WareHouses;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Services.WareHouses;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.WareHouse
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WareHouseController : Controller
    {
        private readonly IWareHouseService _warehouseService;
        public WareHouseController(IWareHouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        [HttpPost]
        public IActionResult WareHouseCreate(WareHouseDTO wareHouseDTO)
        {
            try
            {
                var a = _warehouseService.WareHouseCreate(wareHouseDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult WareHouseList()
        {
            var a = _warehouseService.GetWareHouseList();
            return Ok(a);
        }
        [HttpGet("{warehouseId}")]
        public IActionResult SingleWareHouseListbyId(Int64 warehouseId)
        {
            var a = _warehouseService.GetWareHousebyWareHuoseId(warehouseId);
            return Ok(a);
        }

    }
}
