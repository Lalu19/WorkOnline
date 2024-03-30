using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.SalesOrders
{
    public class WareHouseSalesOrderItem : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 WareHouseSalesOrderItemId { get; set; }
        public Int64 WarehouseSalesOrderParentId { get; set; }
        //public Int64? WareHuoseId { get; set; }
        public Int64? ItemId { get; set; }
        public double? Quantity { get; set; }
        public double? Amount { get; set; }

        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
