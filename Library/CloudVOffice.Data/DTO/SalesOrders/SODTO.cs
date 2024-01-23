using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.SalesOrders
{
	public class SODTO
	{
		public Int64? SOId { get; set; }
		public Int64? PurchaseOrderParentId { get; set; }
		public Int64? PurchaseOrderId { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
