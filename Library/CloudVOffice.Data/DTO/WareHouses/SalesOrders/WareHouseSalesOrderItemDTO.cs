using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.SalesOrders
{
    public class WareHouseSalesOrderItemDTO
    {
        public Int64? WareHouseSalesOrderItemId { get; set; }
        public Int64 WarehouseSalesOrderParentId { get; set; }
        //public Int64? WareHuoseId { get; set; }
        public Int64 ItemId { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }

        public Int64 CreatedBy { get; set; }

    }

    public class WareHouseSalesOrderMasterDTO
    {
        public WarehouseSalesOrderParentDTO Parent { get; set; }
        public List<WareHouseSalesOrderItemDTO> Itemss { get; set; }
    }
}
