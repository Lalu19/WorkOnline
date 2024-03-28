using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributors;
using CloudVOffice.Data.DTO.Distributor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Distributors
{
    public interface IDistributorsAssignService
    {
        public MessageEnum DistributorAssign(DistributorAssignDTO DistributorAssignDTO);
        public List<DistributorAssign> DAssignListbyWareHouseId(Int64 WareHuoseId);
        public MessageEnum DistributorAssignDelete(Int64 DistributorAssignId, Int64 DeletedBy);
        public List<DistributorAssign> DAssignListbyDistributor(Int64 DistributorRegistrationId);

	}
}
