using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Data.DTO.WareHouses.Vendors;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Services.WareHouses.Vendors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Itemss
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemMasterFarmingController : Controller
    {
        private readonly IItemMasterForFarmingService _itemMasterForFarmingService;
        public ItemMasterFarmingController(IItemMasterForFarmingService itemMasterForFarmingService)
        {
            _itemMasterForFarmingService = itemMasterForFarmingService;
        }
        [HttpPost]
        public IActionResult ItemMasterFarmingCreate(ItemMasterForFarmingDTO itemMasterForFarmingDTO)
        {
            try
            {
                var a = _itemMasterForFarmingService.CreateItemMasterForFarming(itemMasterForFarmingDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult ItemMasterFarmingList()
        {
            var a = _itemMasterForFarmingService.GetItemMasterForFarmingList();
            return Ok(a);
        }
        [HttpGet("{itemMasterForFarmingId}")]
        public IActionResult SingleItemMasterFarmingListbyId(Int64 itemMasterForFarmingId)
        {
            var a = _itemMasterForFarmingService.GetItemMasterForFarmingByItemMasterForFarmingId(itemMasterForFarmingId);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateItemMasterFarming(ItemMasterForFarmingDTO itemMasterForFarmingDTO)
        {
            try
            {
                var a = _itemMasterForFarmingService.UpdateItemMasterForFarming(itemMasterForFarmingDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{itemMasterForFarmingId}/{DeletedBy}")]
        public ActionResult DeleteItemMasterFarming(Int64 itemMasterForFarmingId, int DeletedBy)
        {
            var a = _itemMasterForFarmingService.DeleteItemMasterForFarming(itemMasterForFarmingId, DeletedBy);
            return Ok(a);
        }

        [HttpGet("{SellerRegistrationId}")]
        public IActionResult GetItemsForFarmingBySellerRegistrationId(Int64 SellerRegistrationId)
        {
            var a = _itemMasterForFarmingService.GetItemsForFarmingBySellerRegistrationId(SellerRegistrationId);
            return Ok(a);
        }


    }
}
