using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses.Brands;
using CloudVOffice.Data.DTO.WareHouses.Months;
using CloudVOffice.Services.WareHouses.Brands;
using CloudVOffice.Services.WareHouses.Itemss;
using CloudVOffice.Services.WareHouses.Months;
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
    public class BrandController : BasePluginController
    {
        private readonly IBrandService _brandService;
        private readonly IItemService _itemService;
		private readonly IWebHostEnvironment _hostingEnvironment;
		public BrandController(IBrandService brandService, IItemService itemService, IWebHostEnvironment hostingEnvironment)
        {
            _brandService = brandService;
            _itemService = itemService;
			_hostingEnvironment = hostingEnvironment;
		}
        [HttpGet]
        public IActionResult BrandCreate(Int64? BrandId)
        {

            ViewBag.Items = _itemService.GetItemList();
            BrandDTO brandDTO = new BrandDTO();
            if (BrandId != null)
            {

                Brand d = _brandService.GetBrandById(int.Parse(BrandId.ToString()));

                brandDTO.BrandName = d.BrandName;
                brandDTO.BrandImage = d.BrandImage;
            }
            return View("~/Plugins/Warehouse.Management/Views/Brand/BrandCreate.cshtml", brandDTO);
        }

        [HttpPost]
        public IActionResult BrandCreate(BrandDTO brandDTO)
        {
            brandDTO.CreatedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
				if (brandDTO.BrandImageUp != null)
				{
					FileInfo fileInfo = new FileInfo(brandDTO.BrandImageUp.FileName);
					string extn = fileInfo.Extension.ToLower();
					Guid id = Guid.NewGuid();
					string filename = id.ToString() + extn;

					string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Brandimages");
					if (!Directory.Exists(uploadsFolder))
					{
						Directory.CreateDirectory(uploadsFolder);
					}
					string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
					string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
					brandDTO.BrandImageUp.CopyTo(new FileStream(imagePath, FileMode.Create));
					brandDTO.BrandImage = uniqueFileName;
				}
				if (brandDTO.BrandId == null)
                {
                    var a = _brandService.BrandCreate(brandDTO);

                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/Brand/BrandView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Brand Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _brandService.BrandUpdate(brandDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/Brand/BrandView");

                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Brand Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            ViewBag.ItemList = _itemService.GetItemList();
            return View("~/Plugins/Warehouse.Management/Views/Brand/BrandCreate.cshtml", brandDTO);

        }

        public IActionResult BrandView()
        {
            ViewBag.Brands = _brandService.GetBrandList();

            return View("~/Plugins/Warehouse.Management/Views/Brand/BrandView.cshtml");
        }

        [HttpGet]
        public IActionResult BrandDelete(Int64 BrandId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _brandService.BrandDelete(BrandId, DeletedBy);
            return Redirect("/WareHouse/Brand/BrandView");
        }
    }
}
