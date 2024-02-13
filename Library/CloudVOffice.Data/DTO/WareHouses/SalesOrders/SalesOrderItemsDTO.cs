using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;

namespace CloudVOffice.Data.DTO.WareHouses.SalesOrders
{
    public class SalesOrderItemsDTO
    {
        public Int64? SalesOrderItemsId { get; set; }
        public Int64? WareHuoseId { get; set; }
        public string? ItemName { get; set; }
        public string? ShortName { get; set; }
        public double? SalesCost { get; set; }
        public double? CaseWeight { get; set; }
        public double? MRP { get; set; }
        public double? CGST { get; set; }
        public double? SGST { get; set; }
        public double? Quantity { get; set; }
        public Int64? CreatedBy { get; set; }

    }

    public class SalesOrderMasterDTO
    {
        public List<SalesOrderItemsDTO> Orders { get; set; }
    }

}
