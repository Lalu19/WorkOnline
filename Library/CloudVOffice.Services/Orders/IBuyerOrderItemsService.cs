using CloudVOffice.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Orders
{
    public interface IBuyerOrderItemsService
    {
        public MessageEnum BuyerOrderItemsCreate(Int64 BuyerOrderId, int ItemId, Int64 Quantity, Int64 createdBy);
    }
}
