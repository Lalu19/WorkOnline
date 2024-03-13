using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.SalesOrders
{
    public class SalesOrderParentDTO
    {
        public Int64? SalesOrderParentId { get; set; }
        public string? SalesOrderUniqueNumber { get; set; }
        public Int64? WareHuoseId { get; set; }
        public string? POPUniqueNumber { get; set; }
        public double? TotalQuantity { get; set; }
        public double? TotalAmount { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
