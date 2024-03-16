using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public interface ISalesOrderParentService
    {
        public SalesOrderParent SalesOrderParentCreate(SalesOrderParentDTO salesOrderParentDTO);
        public List<SalesOrderParent> GetSalesOrderParentList();
        public SalesOrderParent GetSalesOrderParentById(Int64 salesOrderParentId);
        public MessageEnum DeleteSalesOrderParent(Int64 SalesOrderParentId, Int64 DeletedBy);
        public List<SalesOrderParent> GetSaleOrderListByDateAndStateId(Int64 StateId, DateTime FromDate, DateTime ToDate);

	}
}
