using CloudVOffice.Core.Domain.Distributor;
using CloudVOffice.Data.DTO.Distributor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Distributors
{
    public interface IDPOService
    {
        public DPO DPOCreate(DPODTO DPODTO);
        public List<DPO> GetDPOLIstbyDistributorId(int DistributorId);
       
    }
}
