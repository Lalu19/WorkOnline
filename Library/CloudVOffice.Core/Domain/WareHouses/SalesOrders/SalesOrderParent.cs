using CloudVOffice.Core.Domain.Sellers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.SalesOrders
{
	public class SalesOrderParent : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 SalesOrderParentId { get; set; }
		//public Int64? PurchaseOrderParentId { get; set; }
		//public Int64? PurchaseOrderId { get; set; }

		public string? SalesOrderUniqueNumber { get; set; }
		public Int64 WareHuoseId { get; set; }
        public string? POPUniqueNumber { get; set; }
        public double? TotalQuantity { get; set; }
        public double? TotalAmount { get; set; }
        public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }

        [ForeignKey("WareHuoseId")]
        public WareHuose WareHuose { get; set; }

        public ICollection<SalesOrderItem> SalesOrderItems { get; set; }
    
    }
}
