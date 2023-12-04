using CloudVOffice.Core.Domain.Common;
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
    public class ProductController : BasePluginController
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment hostEnvironment)
        {

            _productService = productService;
            _hostingEnvironment = hostEnvironment;
        }
        [HttpGet]
        public IActionResult ProductsCreate(int? productId)
        {
            ProductDTO productDTO = new ProductDTO();
            var products = _productService.GetGroupProducts();
            ViewBag.ParentGroup = products;
            char[] value = { 'S', 'u', 'b', 'o', 'r', 'd', 'i', 'n', 'a', 't', 'e', 's' };

            string Child = new string(value);
            ViewBag.child = Child;

            if (productId != null)
            {

                var d = _productService.GetProductsById(int.Parse(productId.ToString()));

                productDTO.ProductName = d.ProductName;
                productDTO.ParentGroupId = d.ParentGroupId;
                productDTO.Image = d.Image;
            }

			return View("~/Plugins/Warehouse.Management/Views/ProductCategories/ProductsCreate.cshtml", productDTO);
		}

        [HttpPost]
        public IActionResult ProductsCreate(ProductDTO productDTO)
        {

            productDTO.CreatedBy = (int)Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            if (ModelState.IsValid)
            {
                if (productDTO.ImageUpload != null)
                {
                    FileInfo fileInfo = new FileInfo(productDTO.ImageUpload.FileName);
                    string extn = fileInfo.Extension.ToLower();
                    Guid id = Guid.NewGuid();
                    string filename = id.ToString() + extn;

                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/Category");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
					productDTO.ImageUpload.CopyTo(new FileStream(imagePath, FileMode.Create));
					productDTO.Image = uniqueFileName;
                }
                if (productDTO.ProductId == null)
                {
                    var a = _productService.CreateProduct(productDTO);
                    if (a == MessageEnum.Success)
                    {
                        TempData["msg"] = MessageEnum.Success;
                        return Redirect("/WareHouse/Product/ProductsView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Products Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
                else
                {
                    var a = _productService.ProductsUpdate(productDTO);
                    if (a == MessageEnum.Updated)
                    {
                        TempData["msg"] = MessageEnum.Updated;
                        return Redirect("/WareHouse/Product/ProductsView");
                    }
                    else if (a == MessageEnum.Duplicate)
                    {
                        TempData["msg"] = MessageEnum.Duplicate;
                        ModelState.AddModelError("", "Products Already Exists");
                    }
                    else
                    {
                        TempData["msg"] = MessageEnum.UnExpectedError;
                        ModelState.AddModelError("", "Un-Expected Error");
                    }
                }
            }
            var products = _productService.GetGroupProducts();
            ViewBag.ParentGroup = products;
            char[] value = { 'S', 'u', 'b', 'o', 'r', 'd', 'i', 'n', 'a', 't', 'e', 's' };

            string Child = new string(value);
            ViewBag.child = Child;
			return View("~/Plugins/Warehouse.Management/Views/ProductCategories/ProductsCreate.cshtml", productDTO);
        }

        public IActionResult ProductsView()
        {

            ViewBag.Products = _productService.GetProduct();
			return View("~/Plugins/Warehouse.Management/Views/ProductCategories/ProductsView.cshtml");
        }

        [HttpGet]
        public IActionResult ProductsDelete(int productId)
        {
            Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

            var a = _productService.ProductsDelete(productId, DeletedBy);
            TempData["msg"] = a;
            return Redirect("/WareHouse/Product/ProductsView");
        }

    }
}
