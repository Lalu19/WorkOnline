using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Management.ViewModel;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class CategoryController : BasePluginController
    {
        private readonly ICategoryService _categoryService;
        private readonly ISectorService _sectorService;
       // private readonly IWebHostEnvironment _hostingEnvironment;
        public CategoryController(ICategoryService categoryService, ISectorService sectorService)
        {

            _categoryService = categoryService;
            _sectorService = sectorService;
           // _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult CategoryCreate(int? CategoryId)
        {
            ViewBag.SectorList = _sectorService.GetSectorList();
            CategoryDTO categoryDTO = new CategoryDTO();

            if (CategoryId != null)
            {
                Category d = _categoryService.GetCategoryById(int.Parse(CategoryId.ToString()));

                categoryDTO.SectorId = d.SectorId;
                categoryDTO.CategoryName = d.CategoryName;
              
            }
            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/CategoryCreate.cshtml", categoryDTO);
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryDTO categoryDTO)
        {
            categoryDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
			if (ModelState.IsValid)
			{
				if (categoryDTO.CategoryId == null)
				{
					var a = _categoryService.CategoryCreate(categoryDTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/Category/CategoryView");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Category Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _categoryService.CategoryUpdate(categoryDTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/Category/CategoryView");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "Category Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
			
            ViewBag.SectorList = _sectorService.GetSectorList();
            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/CategoryCreate.cshtml", categoryDTO);

        }

        public IActionResult CategoryView()
        {
            ViewBag.Categories = _categoryService.GetCategoryList();

            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/CategoryView.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteCategory(int CategoryId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _categoryService.DeleteCategory(CategoryId, DeletedBy);
            return Redirect("/WareHouse/Category/CategoryView");
        }

        public JsonResult GetCategoryBySectorId(int SectorId)
        {
            return Json(_categoryService.GetCategoryBySectorId(SectorId));
        }



    }
}
