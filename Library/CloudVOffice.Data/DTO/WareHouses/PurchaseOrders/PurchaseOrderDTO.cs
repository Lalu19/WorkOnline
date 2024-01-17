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
		public Int64? ItemId { get; set; }
		public double? Quantity { get; set; }
		public Int64 CreatedBy { get; set; }
	}

	//public class PurchaseOrderLoopDTO
	//{
	//	public Int64? PurchaseOrderId { get; set; }
	//	public Int64 SellerRegistrationId { get; set; }
	//	public Int64 ItemId { get; set; }
	//	public double Quantity { get; set; }
	//	public Int64 CreatedBy { get; set; }
	//}

	public class PurchaseOrderMasterDTO
	{
		public List<PurchaseOrderDTO> Orders { get; set; }
	}

}
