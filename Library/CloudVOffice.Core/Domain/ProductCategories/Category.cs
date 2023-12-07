using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.ProductCategories
{
	public class Category
	{
		public int CategoryId { get; set; }
		public int SectorId { get; set; }
		public string CategoryName { get; set; }

		//public string? IconPicture { get; set; }
		//public int? Parent { get; set; }
		//public bool IsActive { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
		//public List<Category> Children { get; set; }
	}
}
