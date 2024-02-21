using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.ProductDescription
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductDescriptionController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ApplicationDBContext _dbContext;
        public ProductDescriptionController(IItemService itemService, ApplicationDBContext dbContext)
        {
            _itemService = itemService;
            _dbContext = dbContext;
        }

        [HttpGet("{itemId}")]
        public IActionResult ProductDescriptionbyItemId(Int64 itemId)
        {
            var item = _itemService.GetItemByItemId(itemId);
            if (item == null)
            {
                return NotFound(); // Or return an appropriate response
            }

            var itemsWithArrayOfObjectsImages = new List<object>

            { 
                new
                {
                    ItemId = item.ItemId,
                    ItemCode = item.ItemCode,
                    SectorId = item.SectorId,
                    CategoryId = item.CategoryId,
                    SubCategory1Id = item.SubCategory1Id,
                    SubCategory2Id = item.SubCategory2Id,
                    WareHuoseId = item.WareHuoseId,
                    WareHouseName = item.WareHouseName,
                    AddDistrictId = item.AddDistrictId,
                    DistrictName = item.DistrictName,
                    VendorId = item.VendorId,
                    VendorName = item.VendorName,
                    EmployeeId = item.EmployeeId,
                    EmployeeName = item.EmployeeName,
                    SectorName = item.SectorName,
                    CategoryName = item.CategoryName,
                    SubCategory1Name = item.SubCategory1Name,
                    SubCategory2Name = item.SubCategory2Name,
                    Hsn = item.HSN,
                    ItemName = item.ItemName,
                    CompanyName = item.CompanyName,
                    BrandId = item.BrandId,
                    BrandName = item.BrandName,
                    ProductWeight = item.ProductWeight,
                    UnitId = item.UnitId,
                    ShortName = item.ShortName,
                    SellerMargin = item.SellerMargin,
                    CaseWeight = item.CaseWeight,
                    UnitPerCase = item.UnitPerCase,
                    ManufactureDate = item.ManufactureDate,
                    ExpiryDate = item.ExpiryDate,
                    Barcode = item.Barcode,
                    BarCodeNotAvailable = item.BarCodeNotAvailable,
                    Mrp = item.MRP,
                    MrpCaseCost = item.MRPCaseCost,
                    PurchaseCost = item.PurchaseCost,
                    PurchaseCaseCost = item.PurchaseCaseCost,
                    SalesCost = item.SalesCost,
                    SalesCaseCost = item.SalesCaseCost,
                    PartnerSalesCost = item.PartnerSalesCost,
                    PartnerSalesCaseCost = item.PartnerSalesCaseCost,
                    Cgst = item.CGST,
                    sgst = item.SGST,
                    HandlingTypeId = item.HandlingTypeId,
                    HandlingType = item.HandlingType,
                    Images = item.Images?.Split(',').Select(image =>
                       new { Image = image.Trim() }) ?? Enumerable.Empty<object>(),
                    Thumbnail = item.Thumbnail,
                    Videos = item.Videos,
                    InvoiceNo = item.InvoiceNo,
                    ReceivedDate = item.ReceivedDate,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate,
                    UpdatedBy = item.UpdatedBy,
                    UpdatedDate = item.UpdatedDate,
                    Deleted = item.Deleted,

                  }
            };

            return Ok(itemsWithArrayOfObjectsImages);
        }



    }
}
