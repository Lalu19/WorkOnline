using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Sales
{
	public class SalesExecutiveTarget : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 SalesExecutiveTargetId { get; set; }
		public Int64? MonthId { get; set; }
		public Int64? SectorId { get; set; }
		public Int64? CategoryId { get; set; }
		public Int64? BrandId { get; set; }
		public Int64? SalesExecutiveRegistrationId { get; set; }
		public double? MonthlyCategoryWiseTarget { get; set; }
		public double? MonthlySectorWiseTarget { get; set; }
		public double? MonthlyBrandWiseTarget { get; set; }

		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
