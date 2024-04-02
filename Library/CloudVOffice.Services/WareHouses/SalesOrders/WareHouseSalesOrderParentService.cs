using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.DeliveryPartners;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public class WarehouseSalesOrderParentService : IWarehouseSalesOrderParentService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<WarehouseSalesOrderParent> _warehouseSalesOrderParentRepo;
        private readonly IDATasksWarehouseService _dATasksWarehouseService;
        

        public WarehouseSalesOrderParentService(ApplicationDBContext dbContext,
                                   ISqlRepository<WarehouseSalesOrderParent> warehouseSalesOrderParentRepo, IDATasksWarehouseService dATasksWarehouseService
									)
        {
            _dbContext = dbContext;
            _warehouseSalesOrderParentRepo = warehouseSalesOrderParentRepo;
			_dATasksWarehouseService = dATasksWarehouseService;

		}

        public WarehouseSalesOrderParent CreateWarehouseSalesOrderParent(WarehouseSalesOrderParentDTO warehouseSalesOrderParentDTO)
        {
            try
            {
                //var objcheck = _dbContext.WarehouseSalesOrderParents.Where(a => a.DPOUniqueNo == warehouseSalesOrderParentDTO.DPOUniqueNo && a.Deleted == false).FirstOrDefault();

                //if (objcheck == null)
                //{
                    WarehouseSalesOrderParent WHSOParent = new WarehouseSalesOrderParent();

                    Random random = new Random();

                    WHSOParent.WarehouseSalesOrderUniqueNumber = random.Next(100000, 1000000).ToString();
					WHSOParent.DPOUniqueNo = warehouseSalesOrderParentDTO.DPOUniqueNo;

                    var dpo = _dbContext.DPO.FirstOrDefault(a => a.DPOUniqueNo == warehouseSalesOrderParentDTO.DPOUniqueNo);

                    dpo.OrderStatus = "Order Accepted";
                    _dbContext.SaveChanges();

                    WHSOParent.DistributorRegistrationId = dpo.DistributorId;
                    WHSOParent.TotalQuantity = warehouseSalesOrderParentDTO.TotalQuantity;
                    WHSOParent.TotalAmount = warehouseSalesOrderParentDTO.TotalAmount;
                    WHSOParent.CreatedBy = warehouseSalesOrderParentDTO.CreatedBy;

                    var obj = _warehouseSalesOrderParentRepo.Insert(WHSOParent);


                    _dATasksWarehouseService.CreateDATasksWarehouse(warehouseSalesOrderParentDTO, WHSOParent.DistributorRegistrationId);

                    return obj;
                //}
                //else
                //{
                //    return null;
                //}
            }
            catch
            {
                throw;
            }
        }

        public List<WarehouseSalesOrderParent> GetWarehouseSalesOrderParentList()
        {
            try
            {
                var list = _dbContext.WarehouseSalesOrderParents.Where(a=>a.Deleted == false).ToList();
                return list;
            }
            catch
            {
                throw;
            }
        }

    }
}
