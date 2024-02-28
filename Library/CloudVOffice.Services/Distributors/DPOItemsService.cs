using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Distributors
{
    public class DPOItemsService : IDPOItemsService
    {
        private readonly ApplicationDBContext _Context;
        private readonly ISqlRepository<DPOItems> _DPOItemsRepo;
        public DPOItemsService(ApplicationDBContext Context,
                                    ISqlRepository<DPOItems> DPOItemsRepo)
        {
            _Context = Context;
            _DPOItemsRepo = DPOItemsRepo;
        }
        public MessageEnum DPOItemsCreate(Int64 DPOId, int ItemId, Int64 Quantity, Int64 createdBy)
        {
            DPOItems DPOItems = new DPOItems();
            DPOItems.ItemId = ItemId;
            DPOItems.Quantity = Quantity;
            DPOItems.DPOId = DPOId;
            DPOItems.CreatedBy = createdBy;
            DPOItems.CreatedDate = DateTime.Now;
            _DPOItemsRepo.Insert(DPOItems);
            return MessageEnum.Success;
        }
    }
}
