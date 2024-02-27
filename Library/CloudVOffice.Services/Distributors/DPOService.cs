using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Core.Domain.Orders;
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
        public DPO DPOCreate(DPODTO DPODTO)
        {

            try
            {
                Random random = new Random();
                DPO DPO = new DPO();
                DPO.DPOUniqueNo = random.Next(100000, 1000000).ToString();
                DPO.TotalAmount = DPODTO.TotalAmount;
                DPO.TotalQuantity = DPODTO.TotalQuantity;
                DPO.OrderStatus = "Order Placed";
                DPO.CreatedBy = DPODTO.CreatedBy;
                DPO.WareHuoseId = DPODTO.WareHuoseId;
                DPO.DistributorId = DPODTO.DistributorId;
                DPO.CreatedDate = System.DateTime.Now;

                var obj = _DPORepo.Insert(DPO);
                int Quaninty = 0;
                for (int i = 0; i < DPODTO.Items.Count; i++)
                {

                    Quaninty += DPODTO.Quantity[i];
                    _DPOItemsService.DPOItemsCreate(obj.DPOId, DPODTO.Items[i], DPODTO.Quantity[i], DPODTO.CreatedBy);
                }
                return obj;
            }
            catch
            {
                throw;
            }
        }

        public List<DPO> GetDPOLIstbyDistributorId(int DistributorId)
        {
            return _dbContext.DPO
               .Include(s => s.DPOItems.Where(x => x.Deleted == false))
               .ThenInclude(s => s.Item)
               .Where(x => x.Deleted == false && x.DistributorId == DistributorId).ToList();
        }
    }
}
