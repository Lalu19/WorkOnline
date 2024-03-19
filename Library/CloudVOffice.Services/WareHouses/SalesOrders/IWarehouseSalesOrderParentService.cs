using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public interface IWarehouseSalesOrderParentService
    {
        public WarehouseSalesOrderParent CreateWarehouseSalesOrderParent(WarehouseSalesOrderParentDTO warehouseSalesOrderParentDTO);
    }
}
