using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.RetailerModel
{
	public class RetailLoginDTO
	{
		public Int64? RetailLoginId { get; set; }
		public string? UserMobileNumber { get; set; } //UserName For Login
		public string? Password { get; set; }
		public bool FirstLogin { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
