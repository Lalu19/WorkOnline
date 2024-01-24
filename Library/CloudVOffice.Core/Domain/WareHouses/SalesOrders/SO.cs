using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.SalesOrders
{
	public class SO : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 SOId { get; set; }
		public Int64? PurchaseOrderParentId { get; set; }
		public Int64? PurchaseOrderId { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
