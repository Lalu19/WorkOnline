using CloudVOffice.Core.Domain.WareHouses.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Distributor
{
    public class DPOItems : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 DPOItemsId { get; set; }
        public Int64 DPOId { get; set; }
        public Int64 ItemId { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
