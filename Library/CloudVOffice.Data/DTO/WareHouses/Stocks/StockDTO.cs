using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.Stocks
{
    public class StockDTO
    {
        public Int64? StockId { get; set; }
        public Int64? ItemId { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public Int64? BrandId { get; set; }
        public Int64? WareHuoseId { get; set; }
        public Int64? UnitId { get; set; }
        public double? Quantity { get; set; }

        public Int64 CreatedBy { get; set; }
    }

    public class BrandIdsDTO
    {
        public List<Int64> BrandIds { get; set; }
    }
}
