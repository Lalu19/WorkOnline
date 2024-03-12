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
using Microsoft.EntityFrameworkCore;

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
					distributorRegistration.Country = distributorRegistrationDTO.Country;
					distributorRegistration.State = distributorRegistrationDTO.State;
					distributorRegistration.PrimaryPhone = distributorRegistrationDTO.PrimaryPhone;
					distributorRegistration.AlternatePhone = distributorRegistrationDTO.AlternatePhone;
					distributorRegistration.MailId = distributorRegistrationDTO.MailId;
					distributorRegistration.GSTNumber = distributorRegistrationDTO.GSTNumber;
					distributorRegistration.WareHuoseId = distributorRegistrationDTO.WareHuoseId;
					distributorRegistration.Password = distributorRegistrationDTO.Password;
					distributorRegistration.Image = distributorRegistrationDTO.Image;
					distributorRegistration.CreatedBy = distributorRegistrationDTO.CreatedBy;
					distributorRegistration.CreatedDate = DateTime.Now;

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

		public DistributorRegistration getdistibutorlistbyid(Int64 DistributorRegistrationId)
		{
			return _dbContext.DistributorRegistrations
				.Where(x => x.Deleted == false && x.DistributorRegistrationId == DistributorRegistrationId).SingleOrDefault();
		}
		public List<DistributorRegistration> getdistibutorlistbywarehouseId(Int64 WareHuoseId)
		{
			return _dbContext.DistributorRegistrations
				.Include(x=> x.WareHuose)
				.Where(x => x.Deleted == false && x.WareHuoseId == WareHuoseId).ToList();
		}

        public MessageEnum DistributorDelete(Int64 DistributorRegistrationId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.DistributorRegistrations.Where(x => x.DistributorRegistrationId == DistributorRegistrationId).FirstOrDefault();
                if (a != null)
                {
                    a.Deleted = true;
                    a.UpdatedBy = DeletedBy;
                    a.UpdatedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    return MessageEnum.Deleted;
                }
                else
                    return MessageEnum.Invalid;
            }
            catch
            {
                throw;
            }
        }

    }
}
