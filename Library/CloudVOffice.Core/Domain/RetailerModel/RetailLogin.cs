using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.RetailerModel
{
	public class RetailLogin : IAuditEntity, ISoftDeletedEntity
	{
		public Int64 RetailLoginId { get; set; }
		public string? UserMobileNumber { get; set; } //UserName For Login
		public string? Password { get; set; }
		public bool FirstLogin { get; set; }
		public Int64 CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
	}
}
