using CloudVOffice.Core.Domain.Distributor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Distributor
{
    public class DSODTO
    {
        public Int64? DSOId { get; set; }
        public string OrderUniqueNo { get; set; }
        public double TotalAmount { get; set; }
        public int TotalQuantity { get; set; }
        public string? OrderStatus { get; set; }
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public Int64 PincodeId { get; set; }
        public Int64 DistributorId { get; set; }
        public Int64 CreatedBy { get; set; }
       
        public ICollection<DSOItemsDTO> Items { get; set; }
    }
}
