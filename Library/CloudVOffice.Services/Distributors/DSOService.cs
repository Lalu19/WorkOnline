using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Distributors
{
    public class DSOService : IDSOService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<DSO> _DSORepo;
        private readonly IItemService _ItemService;
        private readonly IDSOItemsService _DSOItemsServiceService;
        public DSOService(ApplicationDBContext dbContext,
            ISqlRepository<DSO> DSORepo,
            IItemService ItemService,
            IDSOItemsService DSOItemsServiceService)
        {
            _dbContext = dbContext;
            _DSORepo = DSORepo;
            _ItemService = ItemService;
            _DSOItemsServiceService = DSOItemsServiceService;
        }
        public List<DSO> GetDSOList(Int64 DistributorId)
        {
            return _dbContext.DSO
                .Include(s => s.DSOItems.Where(x => x.Deleted == false))
                .ThenInclude(s => s.Item)
                .Where(x => x.Deleted == false && x.DistributorId == DistributorId).ToList();

        }
        public MessageEnum DeleteDSOrder(Int64 DSOId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.DSO.FirstOrDefault(a => a.DSOId == DSOId);
                var child = _dbContext.DSOItems.Where(a => a.DSOId == DSOId).ToList();

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
    }
}
