using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.Items
{
    public class DamageItemDTO
    {
        public Int64? DamageItemId { get; set; }
        public Int64? ItemId { get; set; }
        public string? ItemName { get; set; }
        public string? WareHouseName { get; set; }
        public string? DistrictName { get; set; }
        public string? VendorName { get; set; }
        public string? EmployeeName { get; set; }
		public Int64? UnitId { get; set; }
		public string? ShortName { get; set; }
		public string? CompanyName { get; set; }
        public string? BrandName { get; set; }
        public double ProductWeight { get; set; }
	
        public double? CaseWeight { get; set; }
        public double? UnitPerCase { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        
        public double MRP { get; set; }
        public double PurchaseCost { get; set; }
        public double SalesCost { get; set; }
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public string? HandlingType { get; set; }
        public string? InvoiceNo { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Reason { get; set; }
		public string? DamagePics { get; set; }
		//public List<string> DamagePic { get; set; } = new List<string>();
		public double? DamageUnits { get; set; }
        public Int64 CreatedBy { get; set; }
		public IFormFile? DamagePic { get; set; }
	}
}
