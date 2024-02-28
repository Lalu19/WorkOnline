using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Distributors;
using CloudVOffice.Core.Domain.Orders;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Data.DTO.Distributor;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Orders;
using CloudVOffice.Services.WareHouses.Itemss;

namespace CloudVOffice.Services.Distributors
{
	public class DistributorRegistrationService : IDistributorRegistrationService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<DistributorRegistration> _distributorRegistrationRepo;

		public DistributorRegistrationService(ApplicationDBContext dbContext,
			ISqlRepository<DistributorRegistration> distributorRegistrationRepo
			)
		{
			_dbContext = dbContext;
			_distributorRegistrationRepo = distributorRegistrationRepo;
		}
		
		public MessageEnum DistributorRegistrationCreate(DistributorRegistrationDTO distributorRegistrationDTO)
		{
			try
			{
				var objCheck = _dbContext.DistributorRegistrations.FirstOrDefault(a => a.DistributorRegistrationId == distributorRegistrationDTO.DistributorRegistrationId);

				if (objCheck == null)
				{
					DistributorRegistration distributorRegistration = new DistributorRegistration();

					distributorRegistration.Name = distributorRegistrationDTO.Name;
					distributorRegistration.BusinessName = distributorRegistrationDTO.BusinessName;
					distributorRegistration.Address = distributorRegistrationDTO.Address;
					distributorRegistration.PinCodeId = distributorRegistrationDTO.PinCodeId;
					distributorRegistration.Country = distributorRegistrationDTO.Country;
					distributorRegistration.State = distributorRegistrationDTO.State;
					distributorRegistration.PrimaryPhone = distributorRegistrationDTO.PrimaryPhone;
					distributorRegistration.AlternatePhone = distributorRegistrationDTO.AlternatePhone;
					distributorRegistration.MailId = distributorRegistrationDTO.MailId;
					distributorRegistration.GSTNumber = distributorRegistrationDTO.GSTNumber;
					distributorRegistration.WareHuoseId = distributorRegistrationDTO.WareHuoseId;
					distributorRegistration.Password = distributorRegistrationDTO.Password;
					distributorRegistration.SectorId = distributorRegistrationDTO.SectorId;
					distributorRegistration.Image = distributorRegistrationDTO.Image;

					_distributorRegistrationRepo.Insert(distributorRegistration);
				}

				return MessageEnum.Success;
			}
			catch
			{
				throw;
			}	
		}

		public async Task<DistributorRegistration> GetDistributorAsyncss(string UserMobileNumber)
		{
			var distributor = _dbContext.DistributorRegistrations

			   .Where(x => x.PrimaryPhone == UserMobileNumber).SingleOrDefault();

			return distributor;
		}


		public async Task<DistributorRegistration> GetDistributorLoginAsync(string UserMobileNumber, string Password)
		{
			//string hashedPassword = EncryptPassword(Password, UserMobileNumber);
			var distributor = _dbContext.DistributorRegistrations
				.Where(x => x.PrimaryPhone == UserMobileNumber && x.Password == Password).SingleOrDefault();

			return distributor;
		}


	}
}
