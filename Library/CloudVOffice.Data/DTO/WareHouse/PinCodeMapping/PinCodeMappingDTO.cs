using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouse.PinCodeMapping
{
	public class PinCodeMappingDTO
	{
		public Int64? PinCodeMappingId { get; set; }
		public Int64 PinCodeId { get; set; }
		public Int64 UserId { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
