using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Company;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouse.PinCodes
{
    public interface IPinCodeService
    {
        public MessageEnum PinCodeCreate(PinCodeDTO pinCodeDTO);
        public PinCode GetPinByPinCodeId(Int64 pinCodeId);
        public List<PinCode> GetPinList();
        public MessageEnum PinUpdate(PinCodeDTO pinCodeDTO);
        public MessageEnum PinDelete(Int64 pinCodeId, Int64 DeletedBy);
    }
}
