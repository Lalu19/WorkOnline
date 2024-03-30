using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.SalesOrders
{
    public class WarehouseSalesOrderParentDTO
    {
        public Int64? WarehouseSalesOrderParentId { get; set; }
        public string WarehouseSalesOrderUniqueNumber { get; set; }
        //public Int64? WareHuoseId { get; set; }
        public string DPOUniqueNo { get; set; }
        public Int64 DistributorRegistrationId { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalAmount { get; set; }

        public Int64 CreatedBy { get; set; }
    }
}
