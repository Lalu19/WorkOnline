using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.PurchaseOrders
{
	public class PurchaseOrderDTO
	{
		public Int64? PurchaseOrderId { get; set; }
		public Int64? SellerRegistrationId { get; set; }
		public Int64? PurchaseOrderParentId { get; set; }
		public Int64? ItemId { get; set; }
        public double? Quantity { get; set; }
		public double? TotalQuantity { get; set; }
		public double? TotalValue { get; set; }
		public Int64? UnitId { get; set; }
		public double Value { get; set; }
		public Int64 CreatedBy { get; set; }
	}

	//public class PurchaseOrderEntryDTO
	//{
	//	public Int64? PurchaseOrderId { get; set; }
	//	public Int64 SellerRegistrationId { get; set; }
	//	public Int64 ItemId { get; set; }
	//	public double Quantity { get; set; }
	//	public Int64? UnitId { get; set; }
	//	public double Value { get; set; }
	//	public Int64 CreatedBy { get; set; }
	//}

	public class PurchaseOrderMasterDTO
	{
		public List<PurchaseOrderDTO> Orders { get; set; }
		//public List<PurchaseOrderParentDTO> Parents { get; set; }
		public PurchaseOrderParentDTO Parent { get; set; }
	}

}
