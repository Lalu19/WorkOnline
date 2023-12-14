namespace CloudVOffice.Core.Domain.WareHouses.Items
{
    public class ItemMasterForFarming : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 ItemMasterForFarmingId { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategory1Id { get; set; }
        public string? Sector { get; set; }
        public string? Category { get; set; }
        public string? SubCategory1 { get; set; }
        public string? Thumbnail { get; set; }
        public string? Images { get; set; }
		public string? Barcode { get; set; }
		public bool BarCodeNotAvailable { get; set; }
		public int? UOMId { get; set; }
        public string ProductName { get; set; }
        public double? QtyPerKg { get; set; }
        public double? Price { get; set; }
        public double? MinQty { get; set; }
        public double? GST { get; set; }
        public string? HSN { get; set; }
        public DateTime? HarvestDate { get; set; }
        public Int64 CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
