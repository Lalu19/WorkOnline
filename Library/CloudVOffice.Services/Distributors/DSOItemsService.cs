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
    public class DSOItemsService : IDSOItemsService
    {
        private readonly ApplicationDBContext _Context;
        private readonly ISqlRepository<DSOItems> _DSOItemsRepo;
        public DSOItemsService(ApplicationDBContext Context,
                                    ISqlRepository<DSOItems> DSOItemsRepo)
        {
            _Context = Context;
            _DSOItemsRepo = DSOItemsRepo;
        }
    }
}
