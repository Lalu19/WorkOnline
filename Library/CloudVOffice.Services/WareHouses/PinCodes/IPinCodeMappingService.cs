using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.PinCodes
{
	public interface IPinCodeMappingService
	{
		public MessageEnum PinCodeMappingCreate(PinCodeMappingDTO pinCodeMappingDTO);
		public List<PinCodeMapping> GetPinCodeMappingList();
		public MessageEnum PinCodeMappingUpdate(PinCodeMappingDTO pinCodeMappingDTO);
		public PinCodeMapping GetPinCodeMappingById(int PinCodeMappingId);
		public MessageEnum PinCodeMappingDelete(Int64 PinCodeMappingId, Int64 DeletedBy);
	}
}
