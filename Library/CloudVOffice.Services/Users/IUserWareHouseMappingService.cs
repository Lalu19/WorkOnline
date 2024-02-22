using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Data.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Users
{
    public interface IUserWareHouseMappingService
    {
        public MessageEnum UserWareHouseMappingCreate(UserWareHouseMappingDTO UserWareHouseMappingDTO);
        public List<UserWareHouseMapping> UserWareHouseMappingList();
        public MessageEnum UserWareHouseMappingUpdate(UserWareHouseMappingDTO UserWareHouseMappingDTO);
        public UserWareHouseMapping UserWareHouseMappingById(int UserWareHouseMappingId);
        public MessageEnum UserWareHouseMappingDelete(int UserWareHouseMappingId, Int64 DeletedBy);

        public UserWareHouseMapping GetWareHouseByUserId(Int64 UserId);
        public UserWareHouseMapping GetListWareHouseByUserId(Int64 UserId);

        public List<UserWareHouseMapping> GetWareHouseByWareHuoseId(Int64 WareHuoseId);
    }
}
