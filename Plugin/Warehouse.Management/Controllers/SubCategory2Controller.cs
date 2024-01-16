using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Services.ProductCategories;
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
    public class SubCategory2Controller : BasePluginController
    {
        private readonly ISubCategory2Service _subcategory2Service;
        private readonly ISubCategory1Service _subcategory1Service;
        private readonly ISectorService _sectorService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SubCategory2Controller(ISubCategory2Service subcategory2Service, ISubCategory1Service subcategory1Service, ISectorService sectorService, IWebHostEnvironment hostingEnvironment)
        {
            _subcategory2Service = subcategory2Service;
            _subcategory1Service = subcategory1Service;
            _sectorService = sectorService;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult SubCategory2Create(int? SubCategory2Id)
        {
            ViewBag.SectorList = _sectorService.GetSectorList();

            ViewBag.subcategory1List = _subcategory1Service.GetSubCategory1List();
            SubCategory2DTO subcategory2DTO = new SubCategory2DTO();

            if (SubCategory2Id != null)
            {
                SubCategory2 d = _subcategory2Service.GetSubCategory2ById(int.Parse(SubCategory2Id.ToString()));

                subcategory2DTO.SectorId = d.SectorId;
                subcategory2DTO.CategoryId = d.CategoryId;
                subcategory2DTO.SubCategory1Id = d.SubCategory1Id;
                subcategory2DTO.SubCategory2Name = d.SubCategory2Name;
                subcategory2DTO.SubCategory2Image = d.SubCategory2Image;

            }
            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory2Create.cshtml", subcategory2DTO);
        }
        [HttpPost]
        public IActionResult SubCategory2Create(SubCategory2DTO subcategory2DTO)
        {
            subcategory2DTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            if (ModelState.IsValid)
            {
                if (subcategory2DTO.SubCategory2ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(subcategory2DTO.SubCategory2ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Subcategory2");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    subcategory2DTO.SubCategory2ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    subcategory2DTO.SubCategory2Image = uniqueFileName;
                }
                if (subcategory2DTO.SubCategory2Id == null)
                {
                    var a = _subcategory2Service.SubCategory2Create(subcategory2DTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/SubCategory2/SubCategory2View");
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
                    var a = _subcategory2Service.SubCategory2Update(subcategory2DTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/SubCategory2/SubCategory2View");

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
            ViewBag.SectorList = _sectorService.GetSectorList();

            ViewBag.subcategory1List = _subcategory1Service.GetSubCategory1List();
            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory2Create.cshtml", subcategory2DTO);

        }
        public IActionResult SubCategory2View()
        {
            ViewBag.SubCategories2 = _subcategory2Service.GetSubCategory2List();

            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory2View.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteSubCategory2(int SubCategory2Id)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _subcategory2Service.DeleteSubCategory2(SubCategory2Id, DeletedBy);
            return Redirect("/WareHouse/SubCategory2/SubCategory2View");
        }

		public JsonResult GetSubCategory2BySubCategory1Id(int SubCategory1Id)
		{
			return Json(_subcategory2Service.GetSubCategory2BySubCategory1Id(SubCategory1Id));
		}
	}
}
