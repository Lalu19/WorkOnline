using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.States
{
	public class StateDTO
	{
		public Int64? StateId { get; set; }
		public string? StateName { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
