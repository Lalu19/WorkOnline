using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.Banners
{
	public class Banner  : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 BannerId { get; set; }
		public string? BannerName { get; set; }
		public string BannerImage { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
