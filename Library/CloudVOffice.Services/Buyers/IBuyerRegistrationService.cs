using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Buyers;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;

namespace CloudVOffice.Services.Buyers
{
	public interface IBuyerRegistrationService
	{
		public MessageEnum CreateBuyerRegistration(BuyerRegistrationDTO buyerRegistrationDTO);
		public BuyerRegistration GetRegistrationByBuyerRegistrationId(Int64 buyerRegistrationId);
		public List<BuyerRegistration> GetBuyerRegistrationList();
		public MessageEnum UpdateBuyerRegistration(BuyerRegistrationDTO buyerRegistrationDTO);
		public MessageEnum PinDelete(Int64 buyerRegistrationId, Int64 DeletedBy);
	}
}

