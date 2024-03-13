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
        public string GSTNumber { get; set; }
        public string? Mobile { get; set; }
        public string? WareHouseName { get; set; }
        public string? Telephone { get; set; }
        public string Area { get; set; }
        public string Address { get; set; }
        public Int64 StateId { get; set; }

        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
