using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.Persistence;
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
		private readonly ApplicationDBContext _dbContext;
		public CategoryController(ICategoryService categoryService, ApplicationDBContext dbContext)
        {
            _categoryService = categoryService;
			_dbContext = dbContext;
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

		[HttpGet("{SectorId}")]
		public IActionResult GetCategoryByFarmingSectorId(int SectorId)
		{
			var a = _categoryService.GetCategoryForFarmingSector(SectorId);

			return Ok(a);
		}


        [HttpGet("{CategoryId}")]
		public IActionResult AllItemListByCategory(int CategoryId)
		{
			var categoryData = _dbContext.Categories
	   .Where(c => c.CategoryId == CategoryId)
	   .Select(category => new
	   {
		   Category = new
		   {
			   category.CategoryId,
			   category.SectorId,
			   category.CategoryName,
			   category.CategoryImage,
			   category.CreatedBy,
			   category.CreatedDate,
			   category.UpdatedBy,
			   category.UpdatedDate,
			   category.Deleted
		   },
		   SubCategories1 = _dbContext.SubCategories1
			   .Where(sub => sub.CategoryId == category.CategoryId)
			   .Select(sub => new
			   {
				   sub.SubCategory1Id,
				   sub.SubCategory1Name,
				   sub.SubCategory1Image,
				   sub.SectorId,
				   sub.CategoryId,
				   sub.GSTId,
				   sub.HSN,
				   sub.CreatedBy,
				   sub.CreatedDate,
				   sub.UpdatedBy,
				   sub.UpdatedDate,
				   sub.Deleted,
				   SubCategories2 = _dbContext.SubCategories2
					   .Where(sub2 => sub2.SubCategory1Id == sub.SubCategory1Id)
					   .Select(sub2 => new
					   {
						   sub2.SubCategory2Id,
						   sub2.SubCategory2Name,
						   sub2.SubCategory2Image,
						   sub2.SectorId,
						   sub2.CategoryId,
						   sub2.SubCategory1Id,
						   sub2.CreatedBy,
						   sub2.CreatedDate,
						   sub2.UpdatedBy,
						   sub2.UpdatedDate,
						   sub2.Deleted,
					   })
					   .ToList()
			   })
			   .ToList()
	   })
	   .SingleOrDefault(); 

			if (categoryData == null)
			{
				return NotFound(); 
			}

			return Ok(categoryData);
		}
	}
}
