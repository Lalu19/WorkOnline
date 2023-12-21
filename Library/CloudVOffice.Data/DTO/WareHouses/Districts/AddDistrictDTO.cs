using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.Districts
{
	public class AddDistrictDTO
	{
		public Int64? AddDistrictId { get; set; }
		public string? DistrictName { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
