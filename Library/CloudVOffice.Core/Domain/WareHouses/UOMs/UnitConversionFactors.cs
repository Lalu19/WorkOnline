using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.UOMs
{
	public class UnitConversionFactors
	{
		public Int64 UnitConversionFactorsId { get; set; }
		public Int64 FromUnitId { get; set; }
		public Int64 ToUnitId { get; set; }
		public double Value { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }

		[ForeignKey("FromUnitId")]
		public Unit Unit { get; set; }

	}
}
