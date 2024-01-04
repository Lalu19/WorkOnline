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
    public class SubCategory2Controller : Controller
    {
        private readonly ISubCategory2Service _subCategory2Service;
        public SubCategory2Controller(ISubCategory2Service subCategory2Service)
        {
            _subCategory2Service = subCategory2Service;
        }
        [HttpPost]
        public IActionResult SubCategory2Create(SubCategory2DTO subCategory2DTO)
        {
            try
            {
                var a = _subCategory2Service.SubCategory2Create(subCategory2DTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult SubCategory2List()
        {
            var a = _subCategory2Service.GetSubCategory2List();
            return Ok(a);
        }
        [HttpGet("{SubCategory2Id}")]
        public IActionResult SingleSubCategory2ListbyId(int SubCategory2Id)
        {
            var a = _subCategory2Service.GetSubCategory2ById(SubCategory2Id);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateSubCategory2(SubCategory2DTO subCategory2DTO)
        {
            try
            {
                var a = _subCategory2Service.SubCategory2Update(subCategory2DTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{SubCategory2Id}/{DeletedBy}")]
        public ActionResult DeleteSubCategory2(int SubCategory2Id, int DeletedBy)
        {
            var a = _subCategory2Service.DeleteSubCategory2(SubCategory2Id, DeletedBy);
            return Ok(a);
        }
        [HttpGet("{SubCategory1Id}")]
        public IActionResult GetSubCategory2BySubCategory1Id(int SubCategory1Id)
        {
            var a = _subCategory2Service.GetSubCategory2BySubCategory1Id(SubCategory1Id);
            return Ok(a);
        }
    }
}
