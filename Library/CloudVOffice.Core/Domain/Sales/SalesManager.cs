using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Sales
{
	public class SalesManager
	{
		public Int64 SalesManagerId { get; set; }
		public string? SalesManagerName { get; set; }
		public Int64? StateId { get; set; }
		public string? Telephone { get; set; }
		public string? Address { get; set; }
		public string? EmailId { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }

	}
}
