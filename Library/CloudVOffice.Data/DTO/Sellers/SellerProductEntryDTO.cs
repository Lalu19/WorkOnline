using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Sellers
{
    public class SellerProductEntryDTO
    {
        public Int64? SellerProductEntryId { get; set; }
        public string? SellerProductCode { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategory1Id { get; set; }
        public int? SubCategory2Id { get; set; }
        public string ProductName { get; set; }
        public string? HSN { get; set; }
        public string? CompanyName { get; set; }
        public Int64? BrandId { get; set; }
        public double ProductWeight { get; set; }
        public Int64? UnitId { get; set; }
        public double? CaseWeight { get; set; }
        public double? UnitPerCase { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public double MRP { get; set; }
        public double? MRPCaseCost { get; set; }
        public double SalesCost { get; set; }
        public double? SalesCaseCost { get; set; }
        public Int64? GSTId { get; set; }
        public int? HandlingTypeId { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<IFormFile>? ImagesUp { get; set; }
        public string? Thumbnail { get; set; }
        public IFormFile? ThumbnailUp { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
