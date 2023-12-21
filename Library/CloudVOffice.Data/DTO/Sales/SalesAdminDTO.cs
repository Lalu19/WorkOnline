using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Sales
{
    public class SalesAdminDTO
    {
        public Int64? SalesAdminTargetId { get; set; }
		public double? SalesAdminTargetName { get; set; }
		public string? Month { get; set; }
		public Int64? SectorId { get; set; }
		public Int64? CategoryId { get; set; }
		public string? Sector { get; set; }
		public string? Category { get; set; }
		public double? MonthlyCategoryWiseTarget { get; set; }
		public double? MonthlySectorWiseTarget { get; set; }
		public double? MonthlyBrandWiseTarget { get; set; }
		public Int64? UnitId { get; set; }

		public Int64 CreatedBy { get; set; }
    }
}
