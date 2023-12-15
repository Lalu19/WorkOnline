using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CloudVOffice.Data.DTO.WareHouses.Items
{
    public class ItemDTO
    {
        public Int64? ItemId { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategory1Id { get; set; }
		public int? SubCategory2Id { get; set; }
		public string? WareHouseName { get; set; }
		public string? DistrictName { get; set; }
		public string? VendorName { get; set; }
		public string? EmployeeName { get; set; }
		public string? SectorName { get; set; }
		public string? CategoryName { get; set; }
		public string? SubCategory1Name { get; set; }
		public string? SubCategory2Name { get; set; }
		public string? HSN { get; set; }
		public string? ItemName { get; set; }
        public string? CompanyName { get; set; }
        public string? BrandName { get; set; }
        public double ProductWeight { get; set; }
        public Int64? UnitId { get; set; }
        public double? CaseWeight { get; set; }
        public double? UnitPerCase { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? Barcode { get; set; }
		public bool BarCodeNotAvailable { get; set; }
		public double MRP { get; set; }
        public double PurchaseCost { get; set; }
        public double SalesCost { get; set; }
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public string? HandlingType { get; set; }
		public string? InvoiceNo { get; set; }
		public DateTime? ReceivedDate { get; set; }
		public string? Thumbnail { get; set; }
        public IFormFile? ThumbnailUp { get; set; }
        public List<string> Images { get; set; } = new List<string>();
		public List<IFormFile>? ImagesUp { get; set; }
        public string? Videos { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
