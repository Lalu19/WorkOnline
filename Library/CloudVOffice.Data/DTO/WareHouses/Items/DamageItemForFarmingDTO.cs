﻿using Microsoft.AspNetCore.Http;

namespace CloudVOffice.Data.DTO.WareHouses.Items
{
	public class DamageItemForFarmingDTO
    {
        public Int64? DamageItemForFarmingId { get; set; }
        public Int64? ItemMasterForFarmingId { get; set; }
        public string? WareHouseName { get; set; }
        public string? EmployeeName { get; set; }
        public string? VendorName { get; set; }
        public string? DistrictName { get; set; }
		public Int64? UnitId { get; set; }
		public string? ShortName { get; set; }
		public string ProductName { get; set; }
        public double? QtyPerKg { get; set; }
        public double? Price { get; set; }
        public double? MinQty { get; set; }
        public double? GST { get; set; }
        public string? HSN { get; set; }
        public DateTime? HarvestDate { get; set; }
        public string? Reason { get; set; }
        public string? DamagePic { get; set; }
        public double? DamageUnits { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public IFormFile? DamagePicUp { get; set; }
    }
}

