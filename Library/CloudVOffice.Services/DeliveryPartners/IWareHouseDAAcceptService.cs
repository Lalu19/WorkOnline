using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Data.DTO.DeliveryPartners;

namespace CloudVOffice.Services.DeliveryPartners
{
	public interface IWareHouseDAAcceptService
	{
		public MessageEnum CreateWareHouseDAAccept(WareHouseDAAcceptDTO wareHouseDAAcceptDTO);
		public List<WareHouseDAAccept> GetWareHouseDAAcceptList();
		public WareHouseDAAccept GetWareHouseDAAcceptListById(Int64 WareHouseDAAcceptId);
		public List<WareHouseDAAccept> GetWareHouseDAAcceptListByDeliveryPartnerId(Int64 DeliveryPartnerId);
		public List<WareHouseDAAccept> GetWareHouseDAAcceptListByWarehouseTasks();
		public List<WareHouseDAAccept> GetWareHouseDAAcceptListByDistributorTasks();
		public WareHouseDAAccept GetWareHouseDAAcceptByDATasksWareHouseId(Int64 DATasksWareHouseId);
		public WareHouseDAAccept GetWareHouseDAAcceptByDATasksDistributorId(Int64 DATasksDistributorId);


	}
}
