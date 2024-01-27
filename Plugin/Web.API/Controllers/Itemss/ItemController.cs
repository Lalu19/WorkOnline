using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Itemss;
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

    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost]
        public IActionResult ItemCreate(ItemDTO itemDTO)
        {
            try
            {
                var a = _itemService.CreateItem(itemDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult ItemList()
        {
            var a = _itemService.GetItemList();
            return Ok(a);
        }
        [HttpGet("{itemId}")]
        public IActionResult SingleItemListbyItemId(Int64 itemId)
        {
            var a = _itemService.GetItemByItemId(itemId);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateItem(ItemDTO itemDTO)
        {
            try
            {
                var a = _itemService.UpdateItem(itemDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{itemId}/{DeletedBy}")]
        public ActionResult DeleteItem(Int64 itemId, Int64 DeletedBy)
        {
            var a = _itemService.DeleteItem(itemId, DeletedBy);
            return Ok(a);
        }
        [HttpGet("{BrandId}")]
        public IActionResult GetItemsByBrandId(Int64 BrandId)
        {
            var a = _itemService.GetItemlistByBrandId(BrandId);
            return Ok(a);
        }
        [HttpGet("{SectorId}")]
        public IActionResult GetItemsBySectorId(int SectorId)
        {
            var a = _itemService.GetItemlistBySectorId(SectorId);
            return Ok(a);
        }
        [HttpGet("{CategoryId}")]
        public IActionResult GetItemsByCategoryId(int CategoryId)
        {
            var a = _itemService.GetItemlistByCategoryId(CategoryId);
            return Ok(a);
        }
        [HttpGet("{SubCategory1Id}")]
        public IActionResult GetItemsBySubCategory1Id(int SubCategory1Id)
        {
            var a = _itemService.GetItemlistBySubCategory1Id(SubCategory1Id);
            return Ok(a);
        }
        [HttpGet("{SubCategory2Id}")]
        public IActionResult GetItemsBySubCategory2Id(int SubCategory2Id)
        {
            var a = _itemService.GetItemlistBySubCategory2Id(SubCategory2Id);
            return Ok(a);
        }
       
    }
}
