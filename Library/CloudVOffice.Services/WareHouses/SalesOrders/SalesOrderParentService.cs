using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.DTO.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public class SalesOrderParentService : ISalesOrderParentService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SalesOrderParent> _salesOrderParentRepo;

        public SalesOrderParentService(ApplicationDBContext dbContext,
                                   ISqlRepository<SalesOrderParent> salesOrderParentRepo
                                    )
        {
            _dbContext = dbContext;
            _salesOrderParentRepo = salesOrderParentRepo;
        }


        public SalesOrderParent SalesOrderParentCreate(SalesOrderParentDTO salesOrderParentDTO)
        {
            try
            {

                var objcheck = _dbContext.SalesOrderParents.FirstOrDefault(a=> a.SalesOrderParentId == salesOrderParentDTO.SalesOrderParentId);

                if (objcheck == null)
                {
                    SalesOrderParent salesOrderParent = new SalesOrderParent();
                    Random random = new Random();

                    salesOrderParent.SalesOrderUniqueNumber = random.Next(100000, 1000000).ToString();
                    //salesOrderParent.WareHuoseId = salesOrderParentDTO.WareHuoseId;
                    salesOrderParent.POPUniqueNumber = salesOrderParentDTO.POPUniqueNumber;
                    salesOrderParent.TotalQuantity = salesOrderParentDTO.TotalQuantity;
                    salesOrderParent.TotalAmount = salesOrderParentDTO.TotalAmount;
                    salesOrderParent.CreatedBy = salesOrderParentDTO.CreatedBy;
                    salesOrderParent.CreatedDate = DateTime.Now;

                    var salesParent =  _salesOrderParentRepo.Insert(salesOrderParent);
                    return salesParent;
                }
                else
                {
                    return objcheck;
                }
            }
            catch
            {
                throw;
            }
        }

        public List<SalesOrderParent> GetSalesOrderParentList()
        {
            try
            {
                var list = _dbContext.SalesOrderParents.Where(a => a.Deleted == false).ToList();
                return list;
            }
            catch
            {
                throw;
            }
        }

        public SalesOrderParent GetSalesOrderParentById(Int64 salesOrderParentId)
        {
            try
            {
                var salesOrderParent = _dbContext.SalesOrderParents.FirstOrDefault(a => a.SalesOrderParentId == salesOrderParentId);
                return salesOrderParent;
            }
            catch
            {
                throw;
            }
        }


        public MessageEnum DeleteSalesOrderParent(Int64 SalesOrderParentId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.SalesOrderParents.FirstOrDefault(a => a.SalesOrderParentId == SalesOrderParentId);
                var child = _dbContext.SalesOrderItems.Where(a=> a.SalesOrderParentId==SalesOrderParentId).ToList();

                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;
                    _dbContext.SaveChanges();

                    foreach (var item in child)
                    {
                        item.Deleted = true;
                        item.UpdatedBy = DeletedBy;
                        item.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();
                    }
                    return MessageEnum.Deleted;
                }
                else
                {
                    return MessageEnum.Invalid;
                }                
            }
            catch
            {
                throw;
            }
        }

        //public List<SalesOrderParent> GetSaleOrderListByDateAndStateId(DateTime FromDate, DateTime ToDate)
        //{
        //    return _dbContext.SalesOrderParents
        //        .Include(s=>s.WareHuose.Where(x => x.Deleted == false))
        //        .Where(x => x.Deleted == false && x.CreatedDate.Date >= FromDate && x.CreatedDate.Date <= ToDate).ToList();
        //}

    }
}
