using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.PurchaseOrders
{
    public class PurchaseOrderParentDTO
    {
        public Int64? PurchaseOrderParentId { get; set; }
        public Int64 WareHuoseId { get; set; }
        public double? TotalAmount { get; set; }
        public double? TotalQuantity { get; set; }
        public Int64? SellerRegistrationId { get; set; }
        public bool OrderShipped { get; set; }
        public string? POPUniqueNumber { get; set; }
        public Int64 CreatedBy { get; set; }
        //public List<int>? Item { get; set; }
    }
	
}
