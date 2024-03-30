using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.WareHouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Distributor
{
    public class DPO : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 DPOId { get; set; }
        public string DPOUniqueNo { get; set; }
        public Int64 WareHuoseId { get; set; }
        public Int64 DistributorId { get; set; }
        public double TotalAmount { get; set; }
        public int TotalQuantity { get; set; }
		public double TotalWeight { get; set; }
		public string? OrderStatus { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("WareHuoseId")]
        public WareHuose WareHuose { get; set; }
        public ICollection<DPOItems> DPOItems { get; set; }
    }
}
