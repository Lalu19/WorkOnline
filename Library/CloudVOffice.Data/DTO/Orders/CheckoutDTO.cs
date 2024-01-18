using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.Orders
{
	public class CheckoutDTO
	{
		public Int64 CheckoutId { get; set; }
		public Int64 ItemId { get; set; }
		public int Quantity { get; set; }
		public Int64 CreatedBy { get; set; }
	}
}
