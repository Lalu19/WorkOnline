using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Core.Domain.Distributors;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.DeliveryPartners;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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

                if (dpo != null)
                {
                    dpo.OrderStatus = "Order Accepted";
                    _dbContext.SaveChanges();
                }


                WHSOParent.WareHuoseId = _dbContext.UserWareHouseMappings.Where(a=> a.UserId == warehouseSalesOrderParentDTO.CreatedBy).Select(z=> z.WareHuoseId).FirstOrDefault();
                WHSOParent.DistributorRegistrationId = dpo.DistributorId;
                WHSOParent.TotalQuantity = warehouseSalesOrderParentDTO.TotalQuantity;
                WHSOParent.TotalAmount = warehouseSalesOrderParentDTO.TotalAmount;
                WHSOParent.CreatedBy = warehouseSalesOrderParentDTO.CreatedBy;

                var obj = _warehouseSalesOrderParentRepo.Insert(WHSOParent);


                    _dATasksWarehouseService.CreateDATasksWarehouse(warehouseSalesOrderParentDTO);

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

        public DistributorRegistration GetWarehouseOrderByCreatedBy(Int64 createdBy)
        {
            var distributor = _dbContext.DistributorRegistrations.FirstOrDefault(a => a.DistributorRegistrationId == createdBy);
            return distributor;
        }

        public WarehouseSalesOrderParent GetWarehouseOrderByCreatedById(Int64 CreatedById)
        {
            return _dbContext.WarehouseSalesOrderParents
               .Include(x => x.DistributorRegistration)
               .Include(x => x.WareHouseSalesOrderItem.Where(s => s.Deleted == false))
               .ThenInclude(x => x.Item)
               .Where(x => x.Deleted == false && x.CreatedBy == CreatedById)
               .SingleOrDefault();
        }

        //public List<WarehouseSalesOrderParent> GetWarehouseParentList()
        //{
        //    try
        //    {
        //        var list = _dbContext.WarehouseSalesOrderParents.Where(a => a.Deleted == false).ToList();
        //        return list;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        public List<WarehouseSalesOrderParent> GetWarehouseParentList()
        {
            try
            {
                var list = _dbContext.WarehouseSalesOrderParents
                                     .Include(x => x.DistributorRegistration)
                                     .Include(y => y.WareHuose)
                                     .Include(z => z.WareHouseSalesOrderItem)
                                     .Where(a => a.Deleted == false)
                                     .ToList();
                return list;
            }
            catch
            {
                throw;
            }
        }


        public WarehouseSalesOrderParent GetWarehouseSalesOrderByWarehouseSalesOrderParentId(Int64 WarehouseSalesOrderParentId)
        {
            return _dbContext.WarehouseSalesOrderParents
                .Include(x => x.DistributorRegistration)
                .Include(x => x.WareHuose)
                .Include(x => x.WareHouseSalesOrderItem.Where(s => s.Deleted == false))
                .ThenInclude(x => x.Item)
                .Where(x => x.Deleted == false && x.WarehouseSalesOrderParentId == WarehouseSalesOrderParentId).SingleOrDefault();
        }

        public List<WarehouseSalesOrderParent> GetWarehouseSalesOrderParentList()
        {
            try
            {
                var list = _dbContext.WarehouseSalesOrderParents.Where(a => a.Deleted == false).ToList();
                return list;
            }
            catch
            {
                throw;
            }
        }

    }
}
