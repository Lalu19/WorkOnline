using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.UOMs
{
	public class UnitDTO
	{
		public Int64? UnitId { get; set; }
		public string UnitName { get; set; }
		public string ShortName { get; set; }
		public Int64 UnitGroupId { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
