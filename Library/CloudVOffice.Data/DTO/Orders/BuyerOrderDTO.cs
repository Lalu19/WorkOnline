using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Orders
{
    public class BuyerOrderDTO
    {
        public Int64? BuyerOrderId { get; set; }
        public string OrderUniqueNo { get; set; }
        public double TotalAmount { get; set; }
        public int TotalQuantity { get; set; }
        public string? OrderStatus { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public Int64? Pincode { get; set; }
        public Int64 BuyerCustomerLoginID { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        
        public List<int>? Items { get; set; }
        public List<int>? Quantity { get; set; }
    }
}
