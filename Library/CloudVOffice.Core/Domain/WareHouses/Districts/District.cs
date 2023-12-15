using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.Districts
{
	public class District
	{
		public Int64 DistrictId { get; set; }
		public Int64 PinCodeId { get; set; }
		public string DistrictName { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
		public long CreatedBy { get; set; }
	}
}
