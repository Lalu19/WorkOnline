using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Sellers
{
	public class SellerFarmingProductDTO
	{
		public Int64? SellerFarmingProductId { get; set; }
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
		public IFormFile? ThumbnailUp { get; set; }
		public List<string> Images { get; set; } = new List<string>();
		public List<IFormFile>? ImagesUp { get; set; }
		public DateTime? HarvestDate { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
