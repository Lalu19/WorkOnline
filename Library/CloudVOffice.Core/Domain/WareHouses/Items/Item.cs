using CloudVOffice.Core.Domain.WareHouses.Brands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.Items
{
    public class Item : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 ItemId { get; set; }
        public string? ItemCode { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategory1Id { get; set; }
        public int? SubCategory2Id { get; set; }
        public int? WareHuoseId { get; set; }
        public string? WareHouseName { get; set; }
        public int? AddDistrictId { get; set; }
        public string? DistrictName { get; set; }
        public int? VendorId { get; set; }
        public string? VendorName { get; set; }
        public int? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
		public string? SectorName { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategory1Name { get; set; }
        public string? SubCategory2Name { get; set; }
        public string? HSN { get; set; }
        public string ItemName { get; set; }
        public string? CompanyName { get; set; }
        public Int64? BrandId { get; set; }
        public string? BrandName { get; set; }
        public double ProductWeight { get; set; }
        public Int64? UnitId { get; set; }
		public string? ShortName { get; set; }
		public string? SellerMargin { get; set; }
		public double? CaseWeight { get; set; }
        public double? UnitPerCase { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Barcode { get; set; }
        public bool BarCodeNotAvailable { get; set; }
        public double MRP { get; set; }
        public double? MRPCaseCost { get; set; }
        public double PurchaseCost { get; set; }
        public double? PurchaseCaseCost { get; set; }
        public double SalesCost { get; set; }
        public double? SalesCaseCost { get; set; }
        public double PartnerSalesCost { get; set; }
        public double? PartnerSalesCaseCost { get; set; }
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public double? IGST { get; set; }
		public Int64? SellerRegistrationId { get; set; }
        public double? PurchaseLandingCost { get; set; }
        public double? DistributorCost { get; set; }
        public double? DistributorLandingCost { get; set; }
        public double? DistributorCaseCost { get; set; }
        public double? RetailerCost { get; set; }
        public double? RetailerLandingCost { get; set; }
        public double? RetailerCaseCost { get; set; }

        public string? DistributorMargin { get; set; }
        public string? RetailerMargin { get; set; }
        public double? PurchaseCGSTValue { get; set; }
        public double? PurchaseSGSTValue { get; set; }
        public double? PurchaseIGSTValue { get; set; }
        public double? DistributorCGSTValue { get; set; }
        public double? DistributorSGSTValue { get; set; }
        public double? RetailerCGSTValue { get; set; }
        public double? RetailerSGSTValue { get; set; }

        public int? HandlingTypeId { get; set; }
        public string? HandlingType { get; set; }
		public string? Images { get; set; }
        public string? Thumbnail { get; set; }
        public string? Videos { get; set; }
		public string? InvoiceNo { get; set; }
		public DateTime? ReceivedDate { get; set; }
		public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brands { get; set; }
    }
}
