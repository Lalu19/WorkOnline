using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses
{
    public class WareHouseDTO
    {
        public Int64? WareHuoseId { get; set; }
        public String WarehouseName { get; set; }
        public Int64 PinCodeId { get; set; }
        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
