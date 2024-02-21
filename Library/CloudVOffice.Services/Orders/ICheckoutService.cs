using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Data.DTO.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Orders
{
	public interface ICheckoutService
	{
		public MessageEnum CheckoutCreate(CheckoutDTO checkoutDTO);
		public List<Checkout> CheckoutList();
		public MessageEnum CheckoutUpdate(CheckoutDTO checkoutDTO);
		public Checkout CheckoutById(Int64 CheckoutId);
		public MessageEnum CheckoutDelete(Int64 CheckoutId, Int64 DeletedBy);
		public MessageEnum CheckOutPlusUpdate(Int64 CheckoutId, Int64 Createdby);
		public MessageEnum CheckOutMinusUpdate(Int64 CheckoutId, Int64 Createdby);
		public MessageEnum CheckOutDeleteAfterOrder(Int64 ItemId, Int64 DeletedBy, Int64 Createdby);
		//public MessageEnum CheckOutUpdate(Int64 CheckoutId, int Quantity, Int64 UpdatedBy);
		public List<Checkout> CheckOutListbyUserId(Int64 CreatedBy);

    }
}
