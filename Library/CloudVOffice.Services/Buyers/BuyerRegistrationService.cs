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
using CloudVOffice.Data.Migrations;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace CloudVOffice.Services.Buyers
{
	public class BuyerRegistrationService : IBuyerRegistrationService
	{
		private readonly ApplicationDBContext _dbContext;
		private readonly ISqlRepository<BuyerRegistration> _buyerRegistrationRepo;

		public BuyerRegistrationService(ApplicationDBContext dbContext, ISqlRepository<BuyerRegistration> buyerRegistrationRepo)
		{

			_dbContext = dbContext;
			_buyerRegistrationRepo = buyerRegistrationRepo;
		}


		public MessageEnum CreateBuyerRegistration(BuyerRegistrationDTO buyerRegistrationDTO)
		{
			try
			{
				var buyerRegistration = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId == buyerRegistrationDTO.BuyerRegistrationId && x.Deleted == false).FirstOrDefault();

				if (buyerRegistration == null)
				{
					BuyerRegistration buy = new BuyerRegistration();

					buy.Name = buyerRegistrationDTO.Name;
					buy.DateOfBirth = buyerRegistrationDTO.DateOfBirth;
					buy.Address = buyerRegistrationDTO.Address;
					buy.PinCodeId = buyerRegistrationDTO.PinCodeId;
					buy.Country = buyerRegistrationDTO.Country;
					buy.State = buyerRegistrationDTO.State;
					buy.PrimaryPhone = buyerRegistrationDTO.PrimaryPhone;
					buy.AlternatePhone = buyerRegistrationDTO.AlternatePhone;
					buy.MailId = buyerRegistrationDTO.MailId;
					buy.SalesRepresentativeId = buyerRegistrationDTO.SalesRepresentativeId;
					buy.SalesRepresentativeContact = buyerRegistrationDTO.SalesRepresentativeContact;
					buy.GSTNumber = buyerRegistrationDTO.GSTNumber;
					buy.WareHuoseId = buyerRegistrationDTO.WareHuoseId;
					buy.Password = buyerRegistrationDTO.Password;
					buy.SectorId = buyerRegistrationDTO.SectorId;
					buy.ShopImage = buyerRegistrationDTO.ShopImage;
					buy.CreatedBy = buyerRegistrationDTO.CreatedBy;

					var obj = _buyerRegistrationRepo.Insert(buy);
					_dbContext.SaveChanges();

					return MessageEnum.Success;
				}
				else
				{
					return MessageEnum.Duplicate;
				}
			}
			catch
			{
				throw;
			}
		}

		public List<BuyerRegistration> GetBuyerRegistrationList()
		{
			try
			{
				var a = _dbContext.BuyerRegistrations.Where(x => x.Deleted == false).ToList();
				return a;
			}
			catch
			{
				throw;
			}
		}

		//public List<BuyerRegistration> GetBuyerRegistrationList()
		//{
		//	var a = _dbContext.BuyerRegistrations
		//	.Include(s => s.Sector)
		//	.Include(s => s.WareHuose)
		//	.Include(s => s.PinCode)
		//	.Where(x => x.Deleted == false).ToList();

		//	return a;
		//}

		public BuyerRegistration GetRegistrationByBuyerRegistrationId(Int64 buyerRegistrationId)
		{
			try
			{
				var a = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId == buyerRegistrationId).FirstOrDefault();
				return a;
			}
			catch
			{
				throw;
			}
		}

		public MessageEnum PinDelete(Int64 buyerRegistrationId, Int64 DeletedBy)
		{
			try
			{
				var a = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId == buyerRegistrationId).FirstOrDefault();
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

		public MessageEnum UpdateBuyerRegistration(BuyerRegistrationDTO buyerRegistrationDTO)
		{
			try
			{
				var a = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId != buyerRegistrationDTO.BuyerRegistrationId && x.Name == buyerRegistrationDTO.Name && x.Deleted == false).FirstOrDefault();

				if (a == null)
				{
					var buy = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId == buyerRegistrationDTO.BuyerRegistrationId).FirstOrDefault();

					if (buy != null)
					{
						buy.Name = buyerRegistrationDTO.Name;
						buy.DateOfBirth = buyerRegistrationDTO.DateOfBirth;
						buy.Address = buyerRegistrationDTO.Address;
						buy.PinCodeId = buyerRegistrationDTO.PinCodeId;
						buy.Country = buyerRegistrationDTO.Country;
						buy.State = buyerRegistrationDTO.State;
						buy.PrimaryPhone = buyerRegistrationDTO.PrimaryPhone;
						buy.AlternatePhone = buyerRegistrationDTO.AlternatePhone;
						buy.MailId = buyerRegistrationDTO.MailId;
						buy.SalesRepresentativeId = buyerRegistrationDTO.SalesRepresentativeId;
						buy.SalesRepresentativeContact = buyerRegistrationDTO.SalesRepresentativeContact;
						buy.GSTNumber = buyerRegistrationDTO.GSTNumber;
						buy.WareHuoseId = buyerRegistrationDTO.WareHuoseId;
						buy.Password = buyerRegistrationDTO.Password;
						buy.SectorId = buyerRegistrationDTO.SectorId;
						buy.ShopImage = buyerRegistrationDTO.ShopImage;


						buy.UpdatedDate = DateTime.Now;
						_dbContext.SaveChanges();

						return MessageEnum.Success;

					}
					else
					{
						return MessageEnum.Invalid;
					}
				}
				else
				{
					return MessageEnum.Duplicate;
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
