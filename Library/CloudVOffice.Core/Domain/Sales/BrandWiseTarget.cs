using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Sales
{
    public class BrandWiseTarget : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 BrandWiseTargetId { get; set; }
        public int? SectorId { get; set; }
        public int? CategoryId { get; set; }
        public Int64? BrandId { get; set; }
        public Int64? MonthId { get; set; }
        public Int64? UnitId { get; set; }
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

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
    }
}
