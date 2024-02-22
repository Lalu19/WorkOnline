using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Orders
{
    public class BuyerOrderItemsDTO 
    {
        public Int64 BuyerOrderItemsId { get; set; }
        public Int64 BuyerOrderId { get; set; }
        public int ItemId { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
