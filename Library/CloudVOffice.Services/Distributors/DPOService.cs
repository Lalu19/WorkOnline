using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.WareHouses.PurchaseOrders;
using CloudVOffice.Data.DTO.Distributor;
using CloudVOffice.Data.DTO.Orders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Orders;
using CloudVOffice.Services.WareHouses.Itemss;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Distributors
{
    public class DPOService : IDPOService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<DPO> _DPORepo;
        private readonly IItemService _ItemService;
        private readonly IDPOItemsService _DPOItemsService;
        public DPOService(ApplicationDBContext dbContext,
            ISqlRepository<DPO> DPORepo,
            IItemService ItemService,
            IDPOItemsService DPOItemsService)
        {
            _dbContext = dbContext;
            _DPORepo = DPORepo;
            _ItemService = ItemService;
            _DPOItemsService = DPOItemsService;
        }
		public List<DPO> GetDPOList(Int64 DistributorId)
		{
			return _dbContext.DPO
			    .Include(s => s.DPOItems.Where(x=> x.Deleted == false))
			    .ThenInclude(s => s.Item)
			    .Where(x => x.Deleted == false && x.DistributorId == DistributorId).ToList();
			
		}
		public MessageEnum DeleteDPOrder(Int64 DPOId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.DPO.FirstOrDefault(a => a.DPOId == DPOId);
				var child = _dbContext.DPOItems.Where(a => a.DPOId == DPOId).ToList();

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
