using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Distributors
{
    public interface IDSOService
    {
        public List<DSO> GetDSOList(Int64 DistributorId);
        public MessageEnum DeleteDSOrder(Int64 DSOId, Int64 DeletedBy);
    }
}
