using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses;
using CloudVOffice.Services.WareHouse;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;

namespace CloudVOffice.Services.WareHouses
{
    public interface IWareHouseService
    {
        public MessageEnum WareHouseCreate (WareHouseDTO wareHouseDTO);
        public MessageEnum WareHouseUpdate (WareHouseDTO wareHouseDTO);
        public WareHuose GetWareHousebyWareHuoseId(Int64 WareHuoseId);
        public List<WareHuose> GetWareHouseList();
        public MessageEnum WareHouseDelete(Int64 pinCodeId, Int64 DeletedBy);
    }
}
