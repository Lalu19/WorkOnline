using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Data.DTO.ProductCategories;
using CloudVOffice.Data.DTO.WareHouses.Items;
using CloudVOffice.Services.ProductCategories;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers.Itemss
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost]
        public IActionResult ItemCreate(ItemDTO itemDTO)
        {
            try
            {
                var a = _itemService.CreateItem(itemDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }
        [HttpGet]
        public IActionResult ItemList()
        {
            var a = _itemService.GetItemList();
            return Ok(a);
        }
        [HttpGet("{itemId}")]
        public IActionResult SingleItemListbyItemId(Int64 itemId)
        {
            var a = _itemService.GetItemByItemId(itemId);
            return Ok(a);
        }
        [HttpPost]
        public IActionResult UpdateItem(ItemDTO itemDTO)
        {
            try
            {
                var a = _itemService.UpdateItem(itemDTO);
                return Ok(a);
            }
            catch (Exception ex)
            {
                return Accepted(new { Status = "error", ResponseMsg = ex.Message });
            }
        }

        [HttpGet("{itemId}/{DeletedBy}")]
        public ActionResult DeleteItem(Int64 itemId, Int64 DeletedBy)
        {
            var a = _itemService.DeleteItem(itemId, DeletedBy);
            return Ok(a);
        }

        [HttpGet("{BrandId}")]
        public IActionResult GetItemsByBrandId(Int64 BrandId)
        {
            var a = _itemService.GetItemlistByBrandId(BrandId);
            return Ok(a);
        }

        //[HttpGet("{SectorId}")]
        //public IActionResult GetItemsBySectorId(int SectorId)
        //{
        //    var a = _itemService.GetItemlistBySectorId(SectorId);
        //    return Ok(a);
        //}

        [HttpGet("{SectorId}")]
        public IActionResult GetItemsBySectorId(int SectorId)
        {
            var items = _itemService.GetItemlistBySectorId(SectorId);

            // Convert each item's comma-separated string of images to an array of objects
            var itemsWithArrayOfObjectsImages = items.Select(item =>
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

                }).ToList();

            return Ok(itemsWithArrayOfObjectsImages);
        }

        //[HttpGet("{CategoryId}")]
        //public IActionResult GetItemsByCategoryId(int CategoryId)
        //{
        //    var a = _itemService.GetItemlistByCategoryId(CategoryId);
        //    return Ok(a);
        //}

        [HttpGet("{CategoryId}")]
        public IActionResult GetItemsByCategoryId(int CategoryId)
        {
            var items = _itemService.GetItemlistByCategoryId(CategoryId);

            // Convert each item's comma-separated string of images to an array of objects
            var itemsWithArrayOfObjectsImages = items.Select(item =>
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

                }).ToList();

            return Ok(itemsWithArrayOfObjectsImages);
        }

        //[HttpGet("{SubCategory1Id}")]
        //public IActionResult GetItemsBySubCategory1Id(int SubCategory1Id)
        //{
        //    var a = _itemService.GetItemlistBySubCategory1Id(SubCategory1Id);
        //    return Ok(a);
        //}

        [HttpGet("{SubCategory1Id}")]
        public IActionResult GetItemsBySubCategory1Id(int SubCategory1Id)
        {
            var items = _itemService.GetItemlistBySubCategory1Id(SubCategory1Id);

            // Convert each item's comma-separated string of images to an array of objects
            var itemsWithArrayOfObjectsImages = items.Select(item =>
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
                   
                }).ToList();

            return Ok(itemsWithArrayOfObjectsImages);
        }

        //[HttpGet("{SubCategory2Id}")]
        //public IActionResult GetItemsBySubCategory2Id(int SubCategory2Id)
        //{
        //    var a = _itemService.GetItemlistBySubCategory2Id(SubCategory2Id);
        //    return Ok(a);
        //}

        [HttpGet("{SubCategory2Id}")]
        public IActionResult GetItemsBySubCategory2Id(int SubCategory2Id)
        {
            var items = _itemService.GetItemlistBySubCategory2Id(SubCategory2Id);

            // Convert each item's comma-separated string of images to an array of objects
            var itemsWithArrayOfObjectsImages = items.Select(item =>
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

                }).ToList();

            return Ok(itemsWithArrayOfObjectsImages);
        }

    }
}
