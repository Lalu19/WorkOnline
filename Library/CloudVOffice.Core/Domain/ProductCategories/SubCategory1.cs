using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.ProductCategories
{
	public class SubCategory1
	{
		public int SubCategory1Id { get; set; }
		public int SectorId { get; set; }
		public int CategoryId { get; set; }
		public string SubCategory1Name { get; set; }
		public double? GST { get; set; }
		public string? HSN { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
