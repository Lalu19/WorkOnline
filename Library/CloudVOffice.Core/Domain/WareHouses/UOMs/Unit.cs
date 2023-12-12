using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.UOMs
{
	public class Unit
	{
		public Int64 UnitId { get; set; }
		public string UnitName { get; set; }
		public string ShortName { get; set; }
		public Int64 UnitGroupId { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }

		[ForeignKey("UnitGroupId")]
		public UnitGroup UnitGroup { get; set; }
	}
}
