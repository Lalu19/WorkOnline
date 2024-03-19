using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public interface ISalesOrderItemService
    {
        public MessageEnum SalesOrderItemCreate(Int64 salesParentOrderId, Int64 createdBy , List<SalesOrderItemDTO> salesOrderItemDTO);

        public List<SalesOrderItem> GetSalesOrderItemByParentId(Int64 SalesOrderParentId);
        public List<SalesOrderItem> GetSalesOrderItemList();
        public SalesOrderItem GetSalesOrderItemById(int salesOrderItemId);

	}
}
