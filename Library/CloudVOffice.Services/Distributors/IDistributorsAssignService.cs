using CloudVOffice.Core.Domain.Common;
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
    }
}
