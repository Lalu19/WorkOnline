using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Orders
{
    public class BuyerOrder : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 BuyerOrderId { get; set; }
        public string OrderUniqueNo { get; set; }
        public double TotalAmount { get; set; }
        public int TotalQuantity { get; set; }
        public string? OrderStatus { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public string? Pincode { get; set; }
        public Int64 BuyerCustomerLoginID { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        public ICollection<BuyerOrderItems> BuyerOrderItems { get; set; }
    }
}
