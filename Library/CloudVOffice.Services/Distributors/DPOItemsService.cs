using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;
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
		
	}
}
