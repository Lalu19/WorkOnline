using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;

namespace CloudVOffice.Services.DeliveryPartners
{
	public interface IDATasksWarehouseService
	{
        //public Task<MessageEnum> CreateDATasksWarehouse(WarehouseSalesOrderParentDTO warehouseSalesOrderParentDTO);
        public Task<MessageEnum> CreateDATasksWarehouse(WarehouseSalesOrderParentDTO warehouseSalesOrderParentDTO, Int64 DistributorRegistrationId);

        public List<DATasksWarehouse> GetTaskListByAssignedCode(string assignedCode);
        public List<DATasksWarehouse> GetDATasksWarehouseList();
        public List<DATasksWarehouse> GetDATasksWarehouseUnAcceptedList();
        public List<DATasksWarehouse> GetDATasksWarehouseAcceptedList();
        public List<DATasksWarehouse> GetDAAcceptedTasksWarehouseByDeliveryAgentId(Int64 DeliveryPartnerId);

    }
}
