using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.MOMs
{
    public class MOM  : IAuditEntity, ISoftDeletedEntity
    {
        public int MOMId { get; set; }
        public int SectorId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategory1Id { get; set; }
        public string? Brand { get; set; }
        public string SkuGrowth { get; set; }
        public string Customer { get; set; }
        public string? NewCustomer { get; set; }
        public double PurchaseRate { get; set; }
        public string? BasketSize { get; set; }
        public double ChurnRate { get; set; }
        public double AvgLifeOfCustomer { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
