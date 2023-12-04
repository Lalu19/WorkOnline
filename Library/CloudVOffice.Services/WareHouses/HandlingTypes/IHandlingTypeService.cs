using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Core.Domain.WareHouses.HandlingTypes;
using CloudVOffice.Data.DTO.WareHouses.GSTs;
using CloudVOffice.Data.DTO.WareHouses.HandlingTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.HandlingTypes
{
    public interface IHandlingTypeService
    {
        public MessageEnum HandlingTypeCreate(HandlingTypeDTO handlingtypeDTO);
        public HandlingType GetHandlingTypeByHandlingTypeId(Int64 handlingTypeId);
        public List<HandlingType> GetHandlingTypeList();
        public MessageEnum HandlingTypeUpdate(HandlingTypeDTO handlingtypeDTO);
        public MessageEnum HandlingTypeDelete(Int64 handlintypeId, Int64 DeletedBy);
    }
}
