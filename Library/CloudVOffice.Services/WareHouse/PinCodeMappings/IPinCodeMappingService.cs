using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouse.PinCodeMapping;
using CloudVOffice.Data.DTO.WareHouse.PinCodeMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouse.PinCodeMappings
{
	public interface IPinCodeMappingService
	{
		public MessageEnum PinMappingCreate(PinCodeMappingDTO pinCodeMappingDTO);
		public PinCodeMapping GetPinMappingByPinCodeId(Int64 pinCodeMappingId);
		public List<PinCodeMapping> GetPinMappingList();
		public MessageEnum PinMappingUpdate(PinCodeMappingDTO pinCodeMappingDTO);
		public MessageEnum PinMappingDelete(Int64 pinCodeMappingId, Int64 DeletedBy);
	}
}
