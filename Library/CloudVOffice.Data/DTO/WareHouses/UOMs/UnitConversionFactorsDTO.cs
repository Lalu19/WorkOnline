using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.UOMs
{
	public class UnitConversionFactorsDTO
	{
		public Int64? UnitConversionFactorsId { get; set; }
		public Int64 FromUnitId { get; set; }
		public Int64 ToUnitId { get; set; }
		public double Value { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
