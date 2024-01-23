using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Months;

namespace CloudVOffice.Core.Domain.Sales
{
    public class SalesAdminTarget : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 SalesAdminTargetId { get; set; }
        public Int64? SalesManagerId { get; set; }
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
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("MonthId")]
        public Month Month { get; set; }

		[ForeignKey("SalesManagerId")]
		public SalesManager SalesManager { get; set; }

	}
}
