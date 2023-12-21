using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.Districts
{
	public class DistrictMappingDTO
	{
		public Int64? DistrictMappingId { get; set; }
		public List<Int64> PinCodeId { get; set; }
        public Int64? AddDistrictId { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
