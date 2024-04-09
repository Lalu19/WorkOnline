using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Core.Domain.Distributors;
using CloudVOffice.Data.DTO.DeliveryPartners;
using CloudVOffice.Data.DTO.Distributor;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Notifications;
using Microsoft.EntityFrameworkCore;

namespace CloudVOffice.Services.DeliveryPartners
{
	public class DATasksDistributorService : IDATasksDistrbutorService
	{

		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<DATasksDistributor> _dATasksDistributorRepo;
		private readonly IDeliveryPartnerService _deliveryPartnerService;
		private readonly INotificationService _notificationService;


		public DATasksDistributorService(ApplicationDBContext dBContext, ISqlRepository<DATasksDistributor> dATasksDistributorRepo, IDeliveryPartnerService deliveryPartnerService, INotificationService notificationService)
		{
			_dbContext = dBContext;
			_dATasksDistributorRepo = dATasksDistributorRepo;
			_deliveryPartnerService = deliveryPartnerService;
			_notificationService = notificationService;
		}


		public async Task<MessageEnum> CreateDATasksDistributor(DSODTO dSODTO)
		{

			DATasksDistributor dATasksDistributor = new DATasksDistributor();

			dATasksDistributor.OrderAmount = dSODTO.TotalAmount;
			dATasksDistributor.Orderweight = dSODTO.TotalWaight;

			dATasksDistributor.AssignmentCode = _dbContext.DistributorRegistrations.Where(uwm => uwm.DistributorRegistrationId == dSODTO.CreatedBy)
			.Select(uwm => uwm.AssignmentCode)
			.FirstOrDefault();

			dATasksDistributor.ArrivalDate = DateTime.Today.AddDays(1);

			dATasksDistributor.DistributorRegistrationId = dSODTO.CreatedBy;

			//dATasksWarehouse.DistributorRegistrationId = warehouseSalesOrderParentDTO.DistributorRegistrationId;
			dATasksDistributor.BuyerRegistrationId = _dbContext.DSO.Include(uwm => uwm.BuyerOrder).Where(a=> a.BuyerOrderId == dSODTO.BuyerOrderId).Select(z=> z.CreatedBy).FirstOrDefault();
			

			var buyer = _dbContext.BuyerRegistrations.FirstOrDefault(a => a.BuyerRegistrationId == dATasksDistributor.BuyerRegistrationId);

			if(buyer != null)
			{
				dATasksDistributor.Address = buyer.Address;
				dATasksDistributor.Contact = buyer.PrimaryPhone;
			}

			dATasksDistributor.CreatedBy = dSODTO.CreatedBy;
			dATasksDistributor.CreatedDate = DateTime.Now;
			dATasksDistributor.NotificationSent = true;


			var obj = _dATasksDistributorRepo.Insert(dATasksDistributor);

			var agents = _deliveryPartnerService.GetDistributorDAByTaskId(obj.DATasksDistributorId);

			foreach (var agent in agents)
			{
				string fcm = _dbContext.PushNotifications.Where(a => a.AssignedCode == agent.AssignedCode).Select(z => z.FCMToken).FirstOrDefault();


				await _notificationService.SendNotification(fcm, $"Deliver to {obj.Address}", "OW");
			}

			return MessageEnum.Success;
		}



		//public List<DATasksWarehouse> GetTaskListByAssignedCode(string assignedCode)
		//{
		//	try
		//	{
		//		var delAgents = _dbContext.DeliveryPartners.Where(x => x.AssignedCode == assignedCode).ToList();

		//		if (delAgents != null)
		//		{
		//			List<DATasksWarehouse> dATasksWarehouses = new List<DATasksWarehouse>();

		//			foreach (var delAgent in delAgents)
		//			{
		//				if (delAgent != null && delAgent.Availability == true)
		//				{
		//					var tasks = _dbContext.DATasksWarehouses.Where(a => a.AssignmentCode == assignedCode).ToList();

		//					foreach (var task in tasks)
		//					{
		//						if (task.Orderweight <= delAgent.LoadCapacity && task.TaskAccepted == false)
		//						{
		//							dATasksWarehouses.Add(task);
		//						}
		//					}
		//				}
		//			}

		//			return dATasksWarehouses;
		//		}
		//		else
		//		{
		//			return null;
		//		}
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}


		public List<DATasksDistributor> GetDistributorTaskListByAssignedCode(string assignedCode)
		{
			try
			{
				var delAgents = _dbContext.DeliveryPartners.Where(x => x.AssignedCode == assignedCode).ToList();

				if (delAgents != null)
				{
					List<DATasksDistributor> dATasksWarehouses = new List<DATasksDistributor>();

					foreach (var delAgent in delAgents)
					{
						if (delAgent != null && delAgent.Availability == true)
						{
							var tasks = _dbContext.DATasksDistributors.Where(a => a.AssignmentCode == assignedCode).ToList();

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


		public List<DATasksDistributor> GetDATasksDistributorList()
		{
			try
			{

				var list = _dbContext.DATasksDistributors.Where(a=> a.Deleted == false).ToList();
				return list;
			}
			catch
			{
				throw;
			}
		}

		public List<DATasksDistributor> GetAcceptedTasksDistributorList()
		{
			try
			{
				var list = _dbContext.DATasksDistributors.Where(a=> a.TaskAccepted == true).ToList();
				return list;
			}
			catch
			{
				throw;
			}
		}

		public List<DATasksDistributor> GetUnAcceptedTasksDistributorList()
		{
			try
			{
				var list = _dbContext.DATasksDistributors.Where(a=> a.TaskAccepted == false).ToList();
				return list;
			}
			catch
			{
				throw;
			}
		}

		public List<DATasksDistributor> GetDAAcceptedTasksDistributorByDeliveryAgentId(Int64 DeliveryPartnerId)
		{
			try
			{
				var list = _dbContext.DATasksDistributors.Where(a=> a.DeliveryPartnerId == DeliveryPartnerId).ToList();
				return list;
			}
			catch
			{
				throw;
			}
		}

	}
}
