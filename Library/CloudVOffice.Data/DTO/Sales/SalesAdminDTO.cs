using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Sales;

namespace CloudVOffice.Data.DTO.Sales
{
	public class SalesAdminDTO
	{
		public Int64? SalesAdminTargetId { get; set; }
		public string? SalesAdminTargetName { get; set; }
        public Int64 MonthId { get; set; }
        public Int64? SectorId { get; set; }
		public Int64? CategoryId { get; set; }
		public Int64? BrandId { get; set; }
		public string? Sector { get; set; }
		public string? Category { get; set; }
		public double? MonthlyCategoryWiseTarget { get; set; }
		public double? MonthlySectorWiseTarget { get; set; }
		public double? MonthlyBrandWiseTarget { get; set; }
		public Int64? UnitId { get; set; }
		public Int64 CreatedBy { get; set; }
	}

	public class SalesAdminTargetDTO
	{
		public Int64? SalesAdminTargetId { get; set; }
		public string? Sector { get; set; }
		public string? Category { get; set; }
        public Int64 MonthId { get; set; }
        //public string? Month { get; set; }
        public double? MonthlyCategoryWiseTarget { get; set; }
		public Int64 CreatedBy { get; set; }
	}

	public class SalesAdminTargetMasterDTO
	{
		public List<SalesAdminTargetDTO> Targets { get; set; }
	}

}
