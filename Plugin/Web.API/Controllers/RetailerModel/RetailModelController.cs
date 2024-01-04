using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.RetailerModel;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.RetailerModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.RetailerModel
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RetailModelController : Controller
    {
        private readonly IRetailModelService _retailModelService;
        public RetailModelController(IRetailModelService retailModelService)
        {
            _retailModelService = retailModelService;
        }
        [HttpPost]
        public IActionResult RetailModelCreate(RetailModelDTO retailModelDTO)
        {
            try
            {
                var a = _retailModelService.RetailModelCreate(retailModelDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult RetailModelList()
        {
            var a = _retailModelService.GetRetailModelList();
            return Ok(a);
        }
        [HttpGet("{RetailModelId}")]
        public IActionResult SingleRetailModelListbyId(int RetailModelId)
        {
            var a = _retailModelService.GetRetailModelById(RetailModelId);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateRetailModel(RetailModelDTO retailModelDTO)
        {
            try
            {
                var a = _retailModelService.RetailModelUpdate(retailModelDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{RetailModelId}/{DeletedBy}")]
        public ActionResult DeleteRetailModel(int RetailModelId, int DeletedBy)
        {
            var a = _retailModelService.DeleteRetailModel(RetailModelId, DeletedBy);
            return Ok(a);
        }

    }
}
