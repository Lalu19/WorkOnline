using CloudVOffice.Core.Domain.ProductCategories;
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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public IActionResult CategoryCreate(CategoryDTO categoryDTO)
        {
            try
            {
                var a = _categoryService.CategoryCreate(categoryDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var a = _categoryService.GetCategoryList();
            return Ok(a);
        }
        [HttpGet("{CategoryId}")]
        public IActionResult SingleCategoryListbyId(int CategoryId)
        {
            var a = _categoryService.GetCategoryById(CategoryId);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var a = _categoryService.CategoryUpdate(categoryDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{CategoryId}/{DeletedBy}")]
        public ActionResult DeleteCategory(int CategoryId, int DeletedBy)
        {
            var a = _categoryService.DeleteCategory(CategoryId, DeletedBy);
            return Ok(a);
        }
        [HttpGet("{SectorId}")]
        public IActionResult GetCategoryBySectorId(int SectorId)
        {
            var a = _categoryService.GetCategoryBySectorId(SectorId);
            return Ok(a);
        }
    }
}
