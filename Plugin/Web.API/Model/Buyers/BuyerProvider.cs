using Web.API.Model.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.DTO;
using CloudVOffice.Services.Buyers;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.Buyers;

namespace Web.API.Model.Buyers
{
    public class BuyerProvider :IBuyerProvider
    {
        IHttpWebClients _objIHttpWebClients;
        IBuyerRegistrationService _buyerRegistrationService;
        public BuyerProvider(IHttpWebClients objIHttpWebClients,IBuyerRegistrationService buyerRegistrationService)
        {
            _objIHttpWebClients = objIHttpWebClients;
            _buyerRegistrationService = buyerRegistrationService;
        }
        public BuyerViewModel BuyerregCreate(BuyerNewDTO buyerNewDTO)
        {
   //         try
   //         {
			//	//BuyerViewModel objupdateResults = new BuyerViewModel();
			//	//objupdateResults = JsonConvert.DeserializeObject<BuyerViewModel>(_objIHttpWebClients.PostRequest("/api/BuyerRegistration/BuyerRegistrationCreate", JsonConvert.SerializeObject(buyerNewDTO), true));
			//	//return objupdateResults;
			//	BuyerViewModel objupdateResults = _buyerRegistrationService.CreateBuyerRegistration(buyerNewDTO);

			//	return objupdateResults;
			//}

			 try
			{
				var buyerRegistrationDTO = new BuyerRegistrationDTO
				{
					Name = buyerNewDTO.Name,
					//DateOfBirth = buyerNewDTO.DateOfBirth,
					//Address = buyerNewDTO.Address,
					//PinCodeId = buyerNewDTO.PinCodeId,
					//Country = buyerNewDTO.Country,
					//State = buyerNewDTO.State,
					//PrimaryPhone = buyerNewDTO.PrimaryPhone,
					//AlternatePhone = buyerNewDTO.AlternatePhone,
					//MailId = buyerNewDTO.MailId,
					//SalesRepresentativeId = buyerNewDTO.SalesRepresentativeId,
					//SalesRepresentativeContact = buyerNewDTO.SalesRepresentativeContact,
					//GSTNumber = buyerNewDTO.GSTNumber,
					//WareHuoseId = buyerNewDTO.WareHuoseId,
					//FirstLogin = buyerNewDTO.FirstLogin,
					//SectorId = buyerNewDTO.SectorId,
					//ShopImage = buyerNewDTO.ShopImage,
				};


				// Call the correct method from the service
				MessageEnum result = _buyerRegistrationService.CreateBuyerRegistration(buyerRegistrationDTO);

				BuyerViewModel objupdateResults = new BuyerViewModel();

				return objupdateResults;
			}
			catch (Exception)
            {
                throw;

            }
        }
    }
}
