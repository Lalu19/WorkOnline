using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.HandlingTypes
{
    public class HandlingTypeDTO
    {
        public int? HandlingTypeId { get; set; }
        public string? HandlingTypeName { get; set; }


        public bool IsActive { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
