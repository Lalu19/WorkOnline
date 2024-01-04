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
    public class SubCategory1Controller : Controller
    {
        private readonly ISubCategory1Service _subCategory1Service;
        public SubCategory1Controller(ISubCategory1Service subCategory1Service)
        {
            _subCategory1Service = subCategory1Service;
        }
        [HttpPost]
        public IActionResult SubCategory1Create(SubCategory1DTO subCategory1DTO)
        {
            try
            {
                var a = _subCategory1Service.SubCategory1Create(subCategory1DTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult SubCategory1List()
        {
            var a = _subCategory1Service.GetSubCategory1List();
            return Ok(a);
        }
        [HttpGet("{SubCategory1Id}")]
        public IActionResult SingleSubCategory1ListbyId(int SubCategory1Id)
        {
            var a = _subCategory1Service.GetSubCategory1ById(SubCategory1Id);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateSubCategory1(SubCategory1DTO subCategory1DTO)
        {
            try
            {
                var a = _subCategory1Service.SubCategory1Update(subCategory1DTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{SubCategory1Id}/{DeletedBy}")]
        public ActionResult DeleteSubCategory1(int SubCategory1Id, int DeletedBy)
        {
            var a = _subCategory1Service.DeleteSubCategory1(SubCategory1Id, DeletedBy);
            return Ok(a);
        }
        [HttpGet("{CategoryId}")]
        public IActionResult GetSubCategoryByCategoryId(int CategoryId)
        {
            var a = _subCategory1Service.GetSubCategoryByCategoeyId(CategoryId);
            return Ok(a);
        }
    }
}
