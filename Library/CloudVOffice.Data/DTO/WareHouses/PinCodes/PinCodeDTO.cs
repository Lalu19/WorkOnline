using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.PinCodes
{
    public class PinCodeDTO
    {
        public Int64? PinCodeId { get; set; }
        public string Pin { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
		public bool IsActive { get; set; }
		public Int64 CreatedBy { get; set; }
    }
}
