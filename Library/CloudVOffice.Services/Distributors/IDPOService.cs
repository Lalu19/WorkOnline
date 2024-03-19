using CloudVOffice.Core.Domain.Common;
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
		public List<DPO> GetDPOList(Int64 DistributorId);
		public MessageEnum DeleteDPOrder(Int64 DPOId, Int64 DeletedBy);
        public List<DPO> GetDPOListByWareHouseId(Int64 WareHouseId);
        public List<DPO> GetAllDPOList();
        public List<DPO> GetAllDPOListbyParentId(int parentId);



    }
}
