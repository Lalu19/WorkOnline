using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.States;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Sales
{
    public class SalesManagerTarget : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 SalesManagerTargetId { get; set; }
        public Int64? StateId { get; set; }
        public Int64? MonthId { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public Int64? UnitId { get; set; }
        public Int64? BrandId { get; set; }
        public double? MonthlyCategoryWiseTarget { get; set; }
        public double? MonthlySectorWiseTargetByAdmin { get; set; }
        public double? MonthlyBrandWiseTarget { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("MonthId")]
        public Month Month { get; set; }

        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("StateId")]
        public State State { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
    }
}
