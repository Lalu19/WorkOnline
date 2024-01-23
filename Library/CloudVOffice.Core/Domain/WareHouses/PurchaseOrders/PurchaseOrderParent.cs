using CloudVOffice.Core.Domain.Sellers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Sellers;

namespace CloudVOffice.Core.Domain.WareHouses.PurchaseOrders
{
    public class PurchaseOrderParent : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 PurchaseOrderParentId { get; set; }
        public double? TotalAmount { get; set; }
        public double? TotalQuantity { get; set; }
        public Int64? SellerRegistrationId { get; set; }
        public bool OrderShipped { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("SellerRegistrationId")]
        public SellerRegistration SellerRegistration { get; set; }

        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }

    }
}
