using Microsoft.AspNetCore.Http;

namespace CloudVOffice.Data.DTO.WareHouses.Items
{
    public class ItemMasterForFarmingDTO
    {
        public Int64? ItemMasterForFarmingId { get; set; }
		public string? WareHouseName { get; set; }
        public string? EmployeeName { get; set; }
        public string? VendorName { get; set; }
        public string? DistrictName { get; set; }
		public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategory1Id { get; set; }
        public int? SubCategory2Id { get; set; }
        public string? Sector { get; set; }
        public string? Category { get; set; }
        public string? SubCategory1 { get; set; }
        public string? SubCategory2 { get; set; }
        public string? Thumbnail { get; set; }
        public IFormFile? ThumbnailUp { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<IFormFile>? ImagesUp { get; set; }
		public string? Barcode { get; set; }
		public bool BarCodeNotAvailable { get; set; }

        public Int64? UnitId { get; set; }
        public string ProductName { get; set; }
        public double? QtyPerKg { get; set; }
        public double? Price { get; set; }
        public double? MinQty { get; set; }
        public double? GST { get; set; }
        public string? HSN { get; set; }
        public DateTime? HarvestDate { get; set; }
		public string? InvoiceNo { get; set; }
		public DateTime? ReceivedDate { get; set; }
		public Int64 CreatedBy { get; set; }
    }
}
