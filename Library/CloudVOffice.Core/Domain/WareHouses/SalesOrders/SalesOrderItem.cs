using CloudVOffice.Core.Domain.WareHouses.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.SalesOrders
{
    public class SalesOrderItem : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 SalesOrderItemId { get; set; }
        public Int64 SalesOrderParentId { get; set; }
        public Int64 ItemId { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
