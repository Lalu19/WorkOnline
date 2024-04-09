using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Distributors;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public interface IWarehouseSalesOrderParentService
    {
        public WarehouseSalesOrderParent CreateWarehouseSalesOrderParent(WarehouseSalesOrderParentDTO warehouseSalesOrderParentDTO);
		public List<WarehouseSalesOrderParent> GetWarehouseParentList();
		public WarehouseSalesOrderParent GetWarehouseSalesOrderByWarehouseSalesOrderParentId(Int64 WarehouseSalesOrderParentId);
		public DistributorRegistration GetWarehouseOrderByCreatedBy(Int64 WarehouseSalesOrderParentId);
		public WarehouseSalesOrderParent GetWarehouseOrderByCreatedById(Int64 CreatedById);
	}
}
