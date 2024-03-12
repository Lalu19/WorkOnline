using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Sales
{
	public class SalesExecutiveDTO
	{
		public Int64? SalesExecutiveTargetId { get; set; }
		public Int64? MonthId { get; set; }
		public Int64? SectorId { get; set; }
		public Int64? CategoryId { get; set; }
		public Int64? BrandId { get; set; }
		public Int64? SalesExecutiveRegistrationId { get; set; }
		public double? MonthlyCategoryWiseTarget { get; set; }
		public double? MonthlySectorWiseTarget { get; set; }
		public double? MonthlyBrandWiseTarget { get; set; }

		public Int64 CreatedBy { get; set; }
	}

	public class SalesExecutiveTargetDTO
	{
		public Int64? SalesExecutiveTargetId { get; set; }
		public Int64? SalesExecutiveRegistrationId { get; set; }
		public string? Sector { get; set; }
		public string? Category { get; set; }
		public Int64 MonthId { get; set; }
		public double? MonthlyCategoryWiseTarget { get; set; }
		public Int64 CreatedBy { get; set; }
	}
	public class SalesExecutiveTargetMasterDTO
	{
		public List<SalesExecutiveTargetDTO> Targets { get; set; }
	}

}
