using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.PinCodes
{
	public class PinCodeMappingDTO
	{
		public Int64 PinCodeMappingId { get; set; }
		public List<Int64> PinCodeId { get; set; }
		public Int64 WareHuoseId { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
