using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.UOMs;

namespace CloudVOffice.Core.Domain.WareHouses.PurchaseOrders
{
	public class PurchaseOrder : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 PurchaseOrderId { get; set; }
		//public string? WareHouseDetails { get; set; }
		public Int64? PurchaseOrderParentId { get; set; }
		public Int64? SellerRegistrationId { get; set; }
		public Int64? ItemId { get; set; }
		public double? Quantity { get; set; }
		public Int64? UnitId { get; set; }
		public double Value { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }

		[ForeignKey("ItemId")]
		public Item Item { get; set; }

		[ForeignKey("SellerRegistrationId")]
		public SellerRegistration SellerRegistration { get; set; }

		[ForeignKey("UnitId")]
		public Unit Unit { get; set; }
	}
}
