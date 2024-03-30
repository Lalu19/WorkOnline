using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Distributor
{
    public class DSOItemsDTO
    {
        public Int64 DSOItemsId { get; set; }
        public Int64 DSOId { get; set; }
        public Int64 ItemId { get; set; }
        public Int64 Quantity { get; set; }
        public Int64 CreatedBy { get; set; } 
    }
}
