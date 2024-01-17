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
    public class SubCategory3Controller : BasePluginController
    {
        private readonly ISubCategory3Service _subcategory3Service;
        private readonly ISubCategory2Service _subcategory2Service;
        private readonly ISubCategory1Service _subcategory1Service;
        private readonly ISectorService _sectorService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SubCategory3Controller(ISubCategory2Service subcategory2Service, ISubCategory1Service subcategory1Service, ISectorService sectorService, ISubCategory3Service subcategory3Service, IWebHostEnvironment hostingEnvironment)
        {
            _subcategory2Service = subcategory2Service;
            _subcategory1Service = subcategory1Service;
            _sectorService = sectorService;
            _subcategory3Service = subcategory3Service;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult SubCategory3Create(int? SubCategory3Id)
        {
            ViewBag.SectorList = _sectorService.GetSectorList();
            ViewBag.SubCategories2 = _subcategory2Service.GetSubCategory2List();
            ViewBag.subcategory1List = _subcategory1Service.GetSubCategory1List();
            SubCategory3DTO subcategory3DTO = new SubCategory3DTO();

            if (SubCategory3Id != null)
            {
                SubCategory3 d = _subcategory3Service.GetSubCategory3ById(int.Parse(SubCategory3Id.ToString()));

                subcategory3DTO.SectorId = d.SectorId;
                subcategory3DTO.CategoryId = d.CategoryId;
                subcategory3DTO.SubCategory1Id = d.SubCategory1Id;
                subcategory3DTO.SubCategory2Id = d.SubCategory2Id;
                subcategory3DTO.SubCategory3Name = d.SubCategory3Name;
                subcategory3DTO.SubCategory3Image = d.SubCategory3Image;

            }
            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory3Create.cshtml", subcategory3DTO);
        }
        [HttpPost]
        public IActionResult SubCategory3Create(SubCategory3DTO subcategory3DTO)
        {
            subcategory3DTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());
            if (ModelState.IsValid)
            {
                if (subcategory3DTO.SubCategory3ImageUp != null)
                {
                    FileInfo fileInfo = new FileInfo(subcategory3DTO.SubCategory3ImageUp.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Subcategory3");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    subcategory3DTO.SubCategory3ImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
                    subcategory3DTO.SubCategory3Image = uniqueFileName;
                }
                if (subcategory3DTO.SubCategory3Id == null)
                {
                    var a = _subcategory3Service.SubCategory3Create(subcategory3DTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/SubCategory3/SubCategory3View");
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
                    var a = _subcategory3Service.SubCategory3Update(subcategory3DTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/SubCategory3/SubCategory3View");

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
            ViewBag.SubCategories2 = _subcategory2Service.GetSubCategory2List();
            ViewBag.subcategory1List = _subcategory1Service.GetSubCategory1List();
            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory3Create.cshtml", subcategory3DTO);

        }
        public IActionResult SubCategory3View()
        {
            ViewBag.SubCategories3 = _subcategory3Service.GetSubCategory3List();

            return View("~/Plugins/Warehouse.Management/Views/ProductCategories/SubCategory3View.cshtml");
        }

        [HttpGet]
        public IActionResult DeleteSubCategory3(int SubCategory3Id)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _subcategory3Service.DeleteSubCategory3(SubCategory3Id, DeletedBy);
            return Redirect("/WareHouse/SubCategory3/SubCategory3View");
        }

        public JsonResult GetSubCategory3BySubCategory2Id(int SubCategory2Id)
        {
            return Json(_subcategory3Service.GetSubCategory3BySubCategory2Id(SubCategory2Id));
        }
    }
}
