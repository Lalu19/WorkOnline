using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
//using CloudVOffice.Data.Migrations;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.GSTs;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Management.Controllers
{
	[Area(AreaNames.WareHouse)]
	public class SubCategory1Controller : BasePluginController
	{
		private readonly ISubCategory1Service _subcategory1Service;
		private readonly ICategoryService _categoryService;
		private readonly ISectorService _sectorService;
		private readonly IGSTService _gstService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SubCategory1Controller(ISubCategory1Service subcategory1Service, ICategoryService categoryService , ISectorService sectorService , IGSTService gSTService, IWebHostEnvironment hostingEnvironment)
		{

			_subcategory1Service = subcategory1Service;
			_categoryService = categoryService;
            _sectorService = sectorService;
            _gstService = gSTService;
            _hostingEnvironment = hostingEnvironment;

        }
		[HttpGet]
		public IActionResult SubCategory1Create(int? SubCategory1Id)
		{
            ViewBag.SectorList = _sectorService.GetSectorList();
            ViewBag.categoryList = _categoryService.GetCategoryList();
            ViewBag.GstList = _gstService.GetGSTList();
			SubCategory1DTO subcategory1DTO = new SubCategory1DTO();

			if (SubCategory1Id != null)
			{
				SubCategory1 d = _subcategory1Service.GetSubCategory1ById(int.Parse(SubCategory1Id.ToString()));

				subcategory1DTO.SectorId = d.SectorId;
				subcategory1DTO.CategoryId = d.CategoryId;
				subcategory1DTO.SubCategory1Name = d.SubCategory1Name;
				subcategory1DTO.SubCategory1Image = d.SubCategory1Image;
				subcategory1DTO.GSTId = d.GSTId;
				subcategory1DTO.HSN = d.HSN;

			}
			return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory1Create.cshtml", subcategory1DTO);
		}
		[HttpPost]
		public IActionResult SubCategory1Create(SubCategory1DTO subCategory1DTO)
		{
			subCategory1DTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            if (ModelState.IsValid)
			{
                if (subCategory1DTO.SubCategory1ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(subCategory1DTO.SubCategory1ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Subcategory1");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    subCategory1DTO.SubCategory1ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    subCategory1DTO.SubCategory1Image = uniqueFileName;
                }
                if (subCategory1DTO.SubCategory1Id == null)
				{
					var a = _subcategory1Service.SubCategory1Create(subCategory1DTO);

					if (a == MessageEnum.Success)
					{
						TempData["msg"] = MessageEnum.Success;
						return Redirect("/WareHouse/SubCategory1/SubCategory1View");
					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "SubCategory Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
				else
				{
					var a = _subcategory1Service.SubCategory1Update(subCategory1DTO);
					if (a == MessageEnum.Updated)
					{
						TempData["msg"] = MessageEnum.Updated;
						return Redirect("/WareHouse/SubCategory1/SubCategory1View");

					}
					else if (a == MessageEnum.Duplicate)
					{
						TempData["msg"] = MessageEnum.Duplicate;
						ModelState.AddModelError("", "SubCategory Already Exists");
					}
					else
					{
						TempData["msg"] = MessageEnum.UnExpectedError;
						ModelState.AddModelError("", "Un-Expected Error");
					}
				}
			}
            ViewBag.GstList = _gstService.GetGSTList();
            ViewBag.SectorList = _sectorService.GetSectorList();
            ViewBag.categoryList = _categoryService.GetCategoryList();
			return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory1Create.cshtml", subCategory1DTO);

		}

        public IActionResult SubCategory1View()
        {
            ViewBag.SubCategories1 = _subcategory1Service.GetSubCategory1List();

            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory1View.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteSubCategory1(int SubCategory1Id)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _subcategory1Service.DeleteSubCategory1(SubCategory1Id, DeletedBy);
            return Redirect("/WareHouse/SubCategory1/SubCategory1View");
        }

        public JsonResult GetSubCategoryByCategoeyId(int CategoryId)
        {
            return Json(_subcategory1Service.GetSubCategoryByCategoeyId(CategoryId));
        }

        public JsonResult GetSubCategory1ById(int SubCategory1Id)
        {
            return Json(_subcategory1Service.GetSubCategory1ById(SubCategory1Id));
        }


    }
}
