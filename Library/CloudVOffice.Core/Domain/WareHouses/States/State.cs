using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Core.Domain.WareHouses.States
{
	public class State
	{
		public Int64 StateId { get; set; }
		public string StateName { get; set; }
		public DateTime CreatedDate { get; set; }
		public Int64? UpdatedBy { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public bool Deleted { get; set; }
		public long CreatedBy { get; set; }
	}
}
