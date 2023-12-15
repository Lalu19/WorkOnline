using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.Items
{
	public class DamageItem
	{
		public Int64 DamageItemId { get; set; }
		public string? WareHouseName { get; set; }
		public string? DistrictName { get; set; }
		public string? VendorName { get; set; }
		public string? EmployeeName { get; set; }
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
		public string? Reason { get; set; }
		public string? DamagePic { get; set; }
		public double? DamageUnits { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
