using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.SalesOrders
{
    public class WarehouseSalesOrderParent : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 WarehouseSalesOrderParentId { get; set; }
        public string? WarehouseSalesOrderUniqueNumber { get; set; }
        public string? DPOUniqueNo { get; set; }
        public Int64 DistributorRegistrationId { get; set; }
        public Int64? WareHuoseId { get; set; }
        public double? TotalQuantity { get; set; }
        public double? TotalAmount { get; set; }


        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
