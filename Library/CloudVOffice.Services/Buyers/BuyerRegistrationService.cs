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
//using CloudVOffice.Data.Migrations;
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


        //public MessageEnum CreateBuyerRegistration(BuyerRegistrationDTO buyerRegistrationDTO)
        //{
        //	try
        //	{
        //		var buyerRegistration = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId == buyerRegistrationDTO.BuyerRegistrationId && x.PrimaryPhone == buyerRegistrationDTO.PrimaryPhone && x.Deleted == false).FirstOrDefault();

        //		if (buyerRegistration == null)
        //		{
        //			BuyerRegistration buy = new BuyerRegistration();

        //			buy.Name = buyerRegistrationDTO.Name;
        //			buy.DateOfBirth = buyerRegistrationDTO.DateOfBirth;
        //			buy.Address = buyerRegistrationDTO.Address;
        //			buy.PinCodeId = buyerRegistrationDTO.PinCodeId;
        //			buy.Country = buyerRegistrationDTO.Country;
        //			buy.State = buyerRegistrationDTO.State;
        //			buy.PrimaryPhone = buyerRegistrationDTO.PrimaryPhone;
        //			buy.AlternatePhone = buyerRegistrationDTO.AlternatePhone;
        //			buy.MailId = buyerRegistrationDTO.MailId;
        //			buy.SalesExecutiveUniqueNumber = buyerRegistrationDTO.SalesExecutiveUniqueNumber;
        //			buy.SalesExecutiveContact = buyerRegistrationDTO.SalesExecutiveContact;
        //			buy.GSTNumber = buyerRegistrationDTO.GSTNumber;
        //			buy.WareHuoseId = buyerRegistrationDTO.WareHuoseId;
        //			buy.RetailModelId = 1;

        //			buy.FirstLogin = false;
        //			buy.Password = GenerateRandomPassword(6);

        //			buy.SectorId = buyerRegistrationDTO.SectorId;
        //			buy.ShopImage = buyerRegistrationDTO.ShopImage;
        //			buy.CreatedBy = buyerRegistrationDTO.CreatedBy;

        //			var obj = _buyerRegistrationRepo.Insert(buy);
        //			_dbContext.SaveChanges();

        //			return MessageEnum.Success;
        //		}
        //		else
        //		{
        //			return MessageEnum.Duplicate;
        //		}
        //	}
        //	catch
        //	{
        //		throw;
        //	}
        //}


        public MessageEnum CreateBuyerRegistration(BuyerRegistrationDTO buyerRegistrationDTO)
        {
            try
            {
                var isPhoneNumberAlreadyRegistered = _dbContext.BuyerRegistrations
                    .Any(x => x.PrimaryPhone == buyerRegistrationDTO.PrimaryPhone && x.Deleted == false);

                if (isPhoneNumberAlreadyRegistered)
                {
                    return MessageEnum.Duplicate;
                }

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
                buy.SalesExecutiveUniqueNumber = buyerRegistrationDTO.SalesExecutiveUniqueNumber;
                buy.SalesExecutiveContact = buyerRegistrationDTO.SalesExecutiveContact;
                buy.GSTNumber = buyerRegistrationDTO.GSTNumber;
                buy.WareHuoseId = buyerRegistrationDTO.WareHuoseId;
                buy.RetailModelId = 1;

                buy.FirstLogin = false;
                buy.Password = GenerateRandomPassword(6);

                buy.SectorId = buyerRegistrationDTO.SectorId;
                buy.ShopImage = buyerRegistrationDTO.ShopImage;
                buy.CreatedBy = buyerRegistrationDTO.CreatedBy;

                var obj = _buyerRegistrationRepo.Insert(buy);
                _dbContext.SaveChanges();

                return MessageEnum.Success;
            }
            catch
            {
                throw;
            }
        }



        public string GenerateRandomPassword(int length)
		{
			Random random = new Random();

			int randomNumber = random.Next((int)Math.Pow(10, length - 1), (int)Math.Pow(10, length));

			return randomNumber.ToString();
		}

		//		throw;
		//	}
		//}

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
				var a = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId == buyerRegistrationId && x.Deleted == false).FirstOrDefault();
				return a;
			}
			catch
			{
				throw;
			}
		}

		public MessageEnum BuyerRegistrationDelete(Int64 buyerRegistrationId, Int64 DeletedBy)
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

		public MessageEnum UpdateBuyerRegistration(BuyerUpdateDTO buyerUpdateDTO)
		{
			try
			{
				var a = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId != buyerUpdateDTO.BuyerRegistrationId && x.Name == buyerUpdateDTO.Name && x.Deleted == false).FirstOrDefault();

				if (a == null)
				{
					var buy = _dbContext.BuyerRegistrations.Where(x => x.BuyerRegistrationId == buyerUpdateDTO.BuyerRegistrationId).FirstOrDefault();

					if (buy != null)
					{
						buy.Name = buyerUpdateDTO.Name;
						buy.DateOfBirth = buyerUpdateDTO.DateOfBirth;
						buy.Address = buyerUpdateDTO.Address;
						buy.PinCodeId = buyerUpdateDTO.PinCodeId;
						buy.Country = buyerUpdateDTO.Country;
						buy.State = buyerUpdateDTO.State;
						buy.PrimaryPhone = buyerUpdateDTO.PrimaryPhone;
						buy.AlternatePhone = buyerUpdateDTO.AlternatePhone;
						buy.MailId = buyerUpdateDTO.MailId;
						buy.SalesExecutiveUniqueNumber = buyerUpdateDTO.SalesExecutiveUniqueNumber;
						buy.SalesExecutiveContact = buyerUpdateDTO.SalesExecutiveContact;
						buy.GSTNumber = buyerUpdateDTO.GSTNumber;
						buy.WareHuoseId = buyerUpdateDTO.WareHuoseId;
						buy.Password = buyerUpdateDTO.Password;
						buy.FirstLogin = buyerUpdateDTO.FirstLogin;
						buy.SectorId = buyerUpdateDTO.SectorId;
						buy.ShopImage = buyerUpdateDTO.ShopImage;


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
