using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Notifications;
using Microsoft.EntityFrameworkCore;

namespace CloudVOffice.Services.DeliveryPartners
{
	public class DATasksWarehouseService : IDATasksWarehouseService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly IDeliveryPartnerService _deliveryPartnerService;
		private readonly INotificationService _notificationService;
		private readonly ISqlRepository<DATasksWarehouse> _dATasksWarehouseRepo;

		public DATasksWarehouseService(ApplicationDBContext dbContext,
							   ISqlRepository<DATasksWarehouse> dATasksWarehouseRepo, IDeliveryPartnerService deliveryPartnerService, INotificationService notificationService)

		{
			_dbContext = dbContext;
			_dATasksWarehouseRepo = dATasksWarehouseRepo;
			_deliveryPartnerService = deliveryPartnerService;
			_notificationService = notificationService;
		}


		public async Task<MessageEnum> CreateDATasksWarehouse(WarehouseSalesOrderParentDTO warehouseSalesOrderParentDTO, Int64 DistributorRegistrationId)
		{

			//Int64 DeletedBy = Int64.Parse(User.Claims.FirstOrDefault(x => x.Type == "UserId").Value.ToString());

			DATasksWarehouse dATasksWarehouse = new DATasksWarehouse();

			dATasksWarehouse.OrderAmount = warehouseSalesOrderParentDTO.TotalAmount;
			dATasksWarehouse.Orderweight = _dbContext.DPO.Where(a => a.DPOUniqueNo == warehouseSalesOrderParentDTO.DPOUniqueNo).Select(z => z.TotalWeight).FirstOrDefault();

			dATasksWarehouse.AssignmentCode = _dbContext.UserWareHouseMappings
				.Include(uwm => uwm.WareHuose)
				.Where(uwm => uwm.UserId == warehouseSalesOrderParentDTO.CreatedBy)
				.Select(uwm => uwm.WareHuose.AssignmentCode)
				.FirstOrDefault();

			dATasksWarehouse.ArrivalDate = DateTime.Today.AddDays(1);

            dATasksWarehouse.WareHuoseId = _dbContext.UserWareHouseMappings.Where(a => a.UserId ==  warehouseSalesOrderParentDTO.CreatedBy).Select(z=> z.WareHuoseId).FirstOrDefault();

			//dATasksWarehouse.DistributorRegistrationId = warehouseSalesOrderParentDTO.DistributorRegistrationId;
			dATasksWarehouse.DistributorRegistrationId = DistributorRegistrationId;
			dATasksWarehouse.DPOUniqueNo = warehouseSalesOrderParentDTO.DPOUniqueNo;

			var distributor = _dbContext.DistributorRegistrations.FirstOrDefault(a => a.DistributorRegistrationId == DistributorRegistrationId);

			dATasksWarehouse.Address = distributor.Address;
			dATasksWarehouse.Contact = distributor.PrimaryPhone;

			dATasksWarehouse.CreatedBy = warehouseSalesOrderParentDTO.CreatedBy;
			dATasksWarehouse.CreatedDate = DateTime.Now;
			dATasksWarehouse.NotificationSent = true;


			var obj =_dATasksWarehouseRepo.Insert(dATasksWarehouse);

            


            var agents = _deliveryPartnerService.GetDAByTaskId(obj.DATasksWarehouseId);

			foreach (var agent in agents)
			{
				string fcm = _dbContext.PushNotifications.Where(a=> a.AssignedCode == agent.AssignedCode).Select(z=> z.FCMToken).FirstOrDefault();


				await _notificationService.SendNotification(fcm, $"Deliver to {obj.Address}", "OW");
			}

			return MessageEnum.Success;
		}


		//public (List<DATasksWarehouse>, List<DATasksDistributor>) GetTaskListByAssignedCode(string assignedCode)
		//{
		//	try
		//	{
		//		var delAgents = _dbContext.DeliveryPartners.Where(x => x.AssignedCode == assignedCode).ToList();

		//		if (delAgents != null)
		//		{
		//			List<DATasksWarehouse> dATasksWarehouses = new List<DATasksWarehouse>();
		//			List<DATasksDistributor> dATasksDistributor = new List<DATasksDistributor>();

		//			foreach (var delAgent in delAgents)
		//			{
		//				if (delAgent != null && delAgent.Availability == true)
		//				{
		//					var tasks = _dbContext.DATasksWarehouses.Where(a => a.AssignmentCode == assignedCode).ToList();
		//					var tasks1 = _dbContext.DATasksDistributors.Where(b => b.AssignmentCode == assignedCode).ToList();

		//					if (tasks != null)
		//					{
		//						foreach (var task in tasks)
		//						{
		//							if (task.Orderweight <= delAgent.LoadCapacity && task.TaskAccepted == false)
		//							{
		//								dATasksWarehouses.Add(task);
		//							}
		//						}
		//					}

		//					if (tasks1 != null)
		//					{
		//						foreach (var task in tasks1)
		//						{
		//							if (task.Orderweight <= delAgent.LoadCapacity && task.TaskAccepted == false)
		//							{
		//								dATasksDistributor.Add(task);
		//							}
		//						}
		//					}
		//				}
		//			}

		//			return (dATasksWarehouses, dATasksDistributor);
		//		}
		//		else
		//		{
		//			return (null, null);
		//		}
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}

		public List<DATasksWarehouse> GetWareHouseTaskListByAssignedCode(string assignedCode)
		{
			try
			{
				var delAgents = _dbContext.DeliveryPartners.Where(x => x.AssignedCode == assignedCode).ToList();

				if (delAgents != null)
				{
					List<DATasksWarehouse> dATasksWarehouses = new List<DATasksWarehouse>();

					foreach (var delAgent in delAgents)
					{
						if (delAgent != null && delAgent.Availability == true)
						{
							var tasks = _dbContext.DATasksWarehouses.Where(a => a.AssignmentCode == assignedCode).ToList();

							foreach (var task in tasks)
							{
								if (task.Orderweight <= delAgent.LoadCapacity && task.TaskAccepted == false)
								{
									dATasksWarehouses.Add(task);
								}
							}
						}
					}

					return dATasksWarehouses;
				}
				else
				{
					return null;
				}
			}
			catch
			{
				throw;
			}
		}




		public List<DATasksWarehouse> GetDATasksWarehouseList()
		{
			try
			{
				var tasks = _dbContext.DATasksWarehouses.Where(a=> a.Deleted == false).ToList();
				return tasks;
			}
			catch
			{
				throw;
			}
		}

		public List<DATasksWarehouse> GetDATasksWarehouseUnAcceptedList()
		{
			try
			{
				var tasks = _dbContext.DATasksWarehouses.Where(a=> a.TaskAccepted == false && a.Deleted == false).ToList();
				return tasks;
			}
			catch
			{
				throw;
			}
		}

        public List<DATasksWarehouse> GetDATasksWarehouseAcceptedList()
        {
            try
            {
                var tasks = _dbContext.DATasksWarehouses.Where(a => a.TaskAccepted == true && a.Deleted == false).ToList();
                return tasks;
            }
            catch
            {
                throw;
            }
        }

		public List<DATasksWarehouse> GetDAAcceptedTasksWarehouseByDeliveryAgentId(Int64 DeliveryPartnerId)
		{
			try
			{
				var list = _dbContext.DATasksWarehouses.Where(a=> a.DeliveryPartnerId == DeliveryPartnerId).ToList();
				return list;
			}
			catch
			{
				throw;
			}
		}
    }
}
