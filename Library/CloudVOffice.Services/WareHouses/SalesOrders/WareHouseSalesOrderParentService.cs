using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public class WarehouseSalesOrderParentService : IWarehouseSalesOrderParentService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<WarehouseSalesOrderParent> _warehouseSalesOrderParentRepo;

        public WarehouseSalesOrderParentService(ApplicationDBContext dbContext,
                                   ISqlRepository<WarehouseSalesOrderParent> warehouseSalesOrderParentRepo
                                    )
        {
            _dbContext = dbContext;
            _warehouseSalesOrderParentRepo = warehouseSalesOrderParentRepo;
        }

        public WarehouseSalesOrderParent CreateWarehouseSalesOrderParent(WarehouseSalesOrderParentDTO warehouseSalesOrderParentDTO)
        {
            try
            {
                var objcheck = _dbContext.WarehouseSalesOrderParents.Where(a => a.DPOUniqueNo == warehouseSalesOrderParentDTO.DPOUniqueNo && a.Deleted == false);

                if(objcheck == null)
                {
                    WarehouseSalesOrderParent WHSOParent = new WarehouseSalesOrderParent();

                    WHSOParent.WarehouseSalesOrderUniqueNumber = warehouseSalesOrderParentDTO.WarehouseSalesOrderUniqueNumber;
                    WHSOParent.DPOUniqueNo = warehouseSalesOrderParentDTO.DPOUniqueNo;
                    WHSOParent.DistributorRegistrationId = warehouseSalesOrderParentDTO.DistributorRegistrationId;
                    WHSOParent.TotalQuantity = warehouseSalesOrderParentDTO.TotalQuantity;
                    WHSOParent.TotalAmount = warehouseSalesOrderParentDTO.TotalAmount;
                    WHSOParent.CreatedBy = warehouseSalesOrderParentDTO.CreatedBy;

                    var obj = _warehouseSalesOrderParentRepo.Insert(WHSOParent);
                    return obj;
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

    }
}
