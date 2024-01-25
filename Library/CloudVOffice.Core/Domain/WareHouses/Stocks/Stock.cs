using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.WareHouses.Items;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using CloudVOffice.Core.Domain.ProductCategories;

namespace CloudVOffice.Core.Domain.WareHouses.Stocks
{
    public class Stock : IAuditEntity, ISoftDeletedEntity
    {
		public Int64 StockId { get; set; }
        public Int64? ItemId { get; set; }
        public int? SectorId { get; set; }
        public Int64? WareHuoseId { get; set; }
        public Int64? UnitId { get; set; }
        public double? Quantity { get; set; }

        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("ItemId")]
        public Item Item { get; set; }

        [ForeignKey("WareHuoseId")]
        public WareHuose WareHuose { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }


    }
}
