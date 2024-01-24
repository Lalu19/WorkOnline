using CloudVOffice.Core.Domain.ProductCategories;
using CloudVOffice.Core.Domain.WareHouses.Brands;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.UOMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Sellers
{
    public class SellerFarmingProduct : IAuditEntity, ISoftDeletedEntity
    {
        public Int64 SellerFarmingProductId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategory1Id { get; set; }
        public int? SubCategory2Id { get; set; }
        public string ProductName { get; set; }
        public double? MinQty { get; set; }
        public Int64? GSTId { get; set; }
        public string? HSN { get; set; }
        public double? Price { get; set; }
        public double? QtyPerKg { get; set; }
        public string? CompanyName { get; set; }
        public Int64? BrandId { get; set; }
        public double ProductWeight { get; set; }
        public Int64? UnitId { get; set; }
        public string? Thumbnail { get; set; }
        public string? Images { get; set; }
        public DateTime? HarvestDate { get; set; }
        public Int64 CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ForeignKey("SubCategory1Id")]
        public SubCategory1 SubCategory1 { get; set; }

        [ForeignKey("SubCategory2Id")]
        public SubCategory2 SubCategory2 { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }

        [ForeignKey("GSTId")]
        public GST GST { get; set; }

    }
}
