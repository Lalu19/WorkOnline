using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Distributor
{
    public class DPODTO
    {
        public Int64? DPOId { get; set; }
        public string DPOUniqueNo { get; set; }
        public Int64 WareHuoseId { get; set; }
        public Int64 DistributorId { get; set; }
        public double TotalAmount { get; set; }
        public int TotalQuantity { get; set; }
        public double TotalWeight { get; set; }
        public string? OrderStatus { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

		public List<DPOItemsDTO> Items { get; set; }
    }
}
