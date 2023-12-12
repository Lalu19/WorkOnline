using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.ProductCategories
{
	public class SubCategory1DTO
	{
		public int? SubCategory1Id { get; set; }
        public int SectorId { get; set; }
        public int CategoryId { get; set; }
		public string SubCategory1Name { get; set; }
        public double? GST { get; set; }
        public string? HSN { get; set; }
        public Int64 CreatedBy { get; set; }
	}
}
