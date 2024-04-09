using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Data.DTO.DeliveryPartners;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.DeliveryPartners
{
	public class WareHouseDAAcceptService : IWareHouseDAAcceptService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<WareHouseDAAccept> _wareHouseDAAcceptRepo;

		public WareHouseDAAcceptService(ApplicationDBContext dbContext, ISqlRepository<WareHouseDAAccept> wareHouseDAAcceptRepo)
		{

			_dbContext = dbContext;
			_wareHouseDAAcceptRepo = wareHouseDAAcceptRepo;
		}


		//public MessageEnum CreateWareHouseDAAccept(WareHouseDAAcceptDTO wareHouseDAAcceptDTO)
		//{
		//	try
		//	{
		//		if (wareHouseDAAcceptDTO.DeliveryPartnerId != null && (wareHouseDAAcceptDTO.DATasksWarehouseId != null || wareHouseDAAcceptDTO.DATasksDistributorId != null))
		//		{
		//			object task = null;

		//			if (wareHouseDAAcceptDTO.DATasksWarehouseId != null)
		//			{
		//				task = _dbContext.DATasksWarehouses.Where(x => x.DATasksWarehouseId == wareHouseDAAcceptDTO.DATasksWarehouseId).FirstOrDefault();
		//			}
		//			else if (wareHouseDAAcceptDTO.DATasksDistributorId != null)
		//			{
		//				task = _dbContext.DATasksDistributors.Where(x => x.DATasksDistributorId == wareHouseDAAcceptDTO.DATasksDistributorId).FirstOrDefault();
		//			}



		//			if (task != null)
		//			{
		//				if (task.DeliveryPartnerId == null)
		//				{
		//					task.TaskAccepted = true;
		//					task.DeliveryPartnerId = wareHouseDAAcceptDTO.DeliveryPartnerId;
		//					_dbContext.SaveChanges();
		//				}
		//				else
		//				{
		//					return MessageEnum.Exists;
		//				}
		//			}
		//			else
		//			{
		//				return MessageEnum.Error;
		//			}
		//		}
		//		else
		//		{
		//			return MessageEnum.InvalidInput;
		//		}

		//		WareHouseDAAccept WHDAAccept = new WareHouseDAAccept();

		//		WHDAAccept.DATasksDistributorId = wareHouseDAAcceptDTO.DATasksDistributorId;
		//		WHDAAccept.DATasksWarehouseId = wareHouseDAAcceptDTO.DATasksWarehouseId;
		//		WHDAAccept.DeliveryPartnerId = wareHouseDAAcceptDTO.DeliveryPartnerId;
		//		WHDAAccept.StartTime = wareHouseDAAcceptDTO.StartTime;
		//		WHDAAccept.EndTime = wareHouseDAAcceptDTO.EndTime;
		//		WHDAAccept.StartKM = wareHouseDAAcceptDTO.StartKM;
		//		WHDAAccept.EndKM = wareHouseDAAcceptDTO.EndKM;
		//		WHDAAccept.StartMeterPhoto = wareHouseDAAcceptDTO.StartMeterPhoto;
		//		WHDAAccept.EndMeterPhoto = wareHouseDAAcceptDTO.EndMeterPhoto;
		//		WHDAAccept.CreatedBy = wareHouseDAAcceptDTO.CreatedBy;
		//		WHDAAccept.CreatedDate = DateTime.Now;

		//		_wareHouseDAAcceptRepo.Insert(WHDAAccept);

		//		return MessageEnum.Success;
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//}


		public MessageEnum CreateWareHouseDAAccept(WareHouseDAAcceptDTO wareHouseDAAcceptDTO)
		{
			try
			{
				if (wareHouseDAAcceptDTO.DeliveryPartnerId != null && (wareHouseDAAcceptDTO.DATasksWarehouseId != null || wareHouseDAAcceptDTO.DATasksDistributorId != null))
				{
					object task = null;

					if (wareHouseDAAcceptDTO.DATasksWarehouseId != null)
					{
						task = _dbContext.DATasksWarehouses.FirstOrDefault(x => x.DATasksWarehouseId == wareHouseDAAcceptDTO.DATasksWarehouseId);
					}
					else if (wareHouseDAAcceptDTO.DATasksDistributorId != null)
					{
						task = _dbContext.DATasksDistributors.FirstOrDefault(x => x.DATasksDistributorId == wareHouseDAAcceptDTO.DATasksDistributorId);
					}

					if (task != null)
					{
						if (task is DATasksWarehouse warehouseTask && warehouseTask.DeliveryPartnerId == null)
						{
							warehouseTask.TaskAccepted = true;
							warehouseTask.DeliveryPartnerId = wareHouseDAAcceptDTO.DeliveryPartnerId;
							_dbContext.SaveChanges();
						}
						else if (task is DATasksDistributor distributorTask && distributorTask.DeliveryPartnerId == null)
						{
							distributorTask.TaskAccepted = true;
							distributorTask.DeliveryPartnerId = wareHouseDAAcceptDTO.DeliveryPartnerId;
							_dbContext.SaveChanges();
						}
						else
						{
							return MessageEnum.Exists;
						}
					}
					else
					{
						return MessageEnum.Error;
					}
				}
				else
				{
					return MessageEnum.InvalidInput;
				}

				WareHouseDAAccept WHDAAccept = new WareHouseDAAccept();

				WHDAAccept.DATasksDistributorId = wareHouseDAAcceptDTO.DATasksDistributorId;
				WHDAAccept.DATasksWarehouseId = wareHouseDAAcceptDTO.DATasksWarehouseId;
				WHDAAccept.DeliveryPartnerId = wareHouseDAAcceptDTO.DeliveryPartnerId;
				WHDAAccept.StartTime = wareHouseDAAcceptDTO.StartTime;
				WHDAAccept.EndTime = wareHouseDAAcceptDTO.EndTime;
				WHDAAccept.StartKM = wareHouseDAAcceptDTO.StartKM;
				WHDAAccept.EndKM = wareHouseDAAcceptDTO.EndKM;
				WHDAAccept.StartMeterPhoto = wareHouseDAAcceptDTO.StartMeterPhoto;
				WHDAAccept.EndMeterPhoto = wareHouseDAAcceptDTO.EndMeterPhoto;
				WHDAAccept.CreatedBy = wareHouseDAAcceptDTO.CreatedBy;
				WHDAAccept.CreatedDate = DateTime.Now;

				_wareHouseDAAcceptRepo.Insert(WHDAAccept);

				return MessageEnum.Success;
			}
			catch
			{
				throw;
			}
		}




		public List<WareHouseDAAccept> GetWareHouseDAAcceptList()
		{
			try
			{
				var list = _dbContext.WareHouseDAAccepts.Where(a=> a.Deleted == false).ToList();
				return list;
			}
			catch
			{
				throw;
			}
		}


        public WareHouseDAAccept GetWareHouseDAAcceptListById(Int64 WareHouseDAAcceptId)
        {
			try
			{
				var Accept = _dbContext.WareHouseDAAccepts.Where(a=> a.Deleted == false).FirstOrDefault();
				return Accept;
			}
			catch
			{
				throw;
			}
        }

		/*public List<WareHouseDAAccept>*/   //by WarehouseTasks,DistributorTasks, DeliveryPartnerId. and in the deliveryPartnerController


		public List<WareHouseDAAccept> GetWareHouseDAAcceptListByDeliveryPartnerId(Int64 DeliveryPartnerId)
		{
			try
			{
				var accepts = _dbContext.WareHouseDAAccepts.Where(a=> a.DeliveryPartnerId == DeliveryPartnerId && a.Deleted == false).ToList();

				return accepts;
			}
			catch
			{
				throw;
			}
		}

		public List<WareHouseDAAccept> GetWareHouseDAAcceptListByWarehouseTasks()
		{
			try
			{
				var list = _dbContext.WareHouseDAAccepts.Where(a=> a.DATasksWarehouseId != null && a.Deleted == false).ToList();
				return list;
			}
			catch
			{
				throw;
			}
		}

		public List<WareHouseDAAccept> GetWareHouseDAAcceptListByDistributorTasks()
		{
			try
			{
				var list = _dbContext.WareHouseDAAccepts.Where(a => a.DATasksDistributorId != null && a.Deleted == false).ToList();
				return list;
			}
			catch
			{
				throw;
			}
		}

		public WareHouseDAAccept GetWareHouseDAAcceptByDATasksWareHouseId(Int64 DATasksWareHouseId)
		{
			try
			{
				var accept = _dbContext.WareHouseDAAccepts.Where(a=> a.DATasksWarehouseId == DATasksWareHouseId && a.Deleted == false).FirstOrDefault();
				return accept;
			}
			catch
			{
				throw;
			}
		}

		public WareHouseDAAccept GetWareHouseDAAcceptByDATasksDistributorId(Int64 DATasksDistributorId)
		{
			try
			{
				var accept = _dbContext.WareHouseDAAccepts.Where(a => a.DATasksDistributorId == DATasksDistributorId && a.Deleted == false).FirstOrDefault();

				return accept;
			}
			catch
			{
				throw;
			}
		}
	}
}
