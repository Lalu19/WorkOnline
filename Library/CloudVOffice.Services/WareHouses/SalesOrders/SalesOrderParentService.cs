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

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public class SalesOrderParentService
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
                //var objCheck = _dbContext.PurchaseOrders.FirstOrDefault(p => p.PurchaseOrderId == purchaseOrderDTO.PurchaseOrderId);


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


        //public MessageEnum SalesOrderParentUpdate(SalesOrderParentDTO salesOrderParentDTO)
        //{
        //    try
        //    {
        //        var updateSalesOrderParent = _dbContext.SalesOrderParents.Where(x => x.SalesOrderParentId != salesOrderParentDTO.SalesOrderParentId && x.Deleted == false).FirstOrDefault();

        //        if (updateSalesOrderParent == null)
        //        {
        //            // var a = _dbContext.PurchaseOrderParents.Where(x => x.PurchaseOrderParentId == purchaseOrderParentDTO.PurchaseOrderParentId).FirstOrDefault();
        //            var order = _dbContext.SalesOrderParents.FirstOrDefault(o => o.SalesOrderParentId == salesOrderParentDTO.SalesOrderParentId);
        //            if (order != null)
        //            {
        //                order.TotalAmount = purchaseOrderParentDTO.TotalAmount;
        //                order.TotalQuantity = purchaseOrderParentDTO.TotalQuantity;
        //                order.SellerRegistrationId = purchaseOrderParentDTO.SellerRegistrationId;
        //                order.OrderShipped = purchaseOrderParentDTO.OrderShipped;
        //                order.UpdatedBy = purchaseOrderParentDTO.CreatedBy;
        //                order.UpdatedDate = DateTime.Now;
        //                _dbContext.SaveChanges();
        //                return MessageEnum.Updated;
        //            }
        //            else
        //                return MessageEnum.Invalid;
        //        }
        //        else
        //        {
        //            return MessageEnum.Duplicate;
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

    }
}
