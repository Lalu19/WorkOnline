﻿using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sellers;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.Sellers;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Sellers
{
    public class SellerRegistrationService : ISellerRegistrationService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SellerRegistration> _sellerRegistrationRepo;
        public SellerRegistrationService(ApplicationDBContext dbContext, ISqlRepository<SellerRegistration> sellerRegistrationRepo)
        {

            _dbContext = dbContext;
            _sellerRegistrationRepo = sellerRegistrationRepo;
        }
        public MessageEnum SellerRegistrationCreate(SellerRegistrationDTO sellerRegistrationDTO)
        {
            try
            {
                var sellerr = _dbContext.SellerRegistrations.Where(x => x.SellerRegistrationId == sellerRegistrationDTO.SellerRegistrationId && x.Deleted == false).FirstOrDefault();
                if (sellerr == null)
                {
                    SellerRegistration sr = new SellerRegistration();

                    sr.Name = sellerRegistrationDTO.Name;
                    sr.BusinessName = sellerRegistrationDTO.BusinessName;
                    sr.Address = sellerRegistrationDTO.Address;
                    sr.PinCodeId = sellerRegistrationDTO.PinCodeId;
                    sr.Country = sellerRegistrationDTO.Country;
                    sr.State = sellerRegistrationDTO.State;
                    sr.PrimaryPhone = sellerRegistrationDTO.PrimaryPhone;
                    sr.AlternatePhone = sellerRegistrationDTO.AlternatePhone;
                    sr.MailId = sellerRegistrationDTO.MailId;
                    sr.SalesRepresentativeId = sellerRegistrationDTO.SalesRepresentativeId;
                    sr.SalesRepresentativeContact = sellerRegistrationDTO.SalesRepresentativeContact;
                    sr.GSTNumber = sellerRegistrationDTO.GSTNumber;
                    sr.WareHuoseId = sellerRegistrationDTO.WareHuoseId;
                    sr.Password = GenerateRandomPassword(6);
                    sr.FirstLogin = false;
					sr.SectorId = sellerRegistrationDTO.SectorId;
                    sr.Image = sellerRegistrationDTO.Image;
                    sr.CreatedBy = sellerRegistrationDTO.CreatedBy;

                    var obj = _sellerRegistrationRepo.Insert(sr);
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

		public string GenerateRandomPassword(int length)
		{
			Random random = new Random();

			int randomNumber = random.Next((int)Math.Pow(10, length - 1), (int)Math.Pow(10, length));

			return randomNumber.ToString();
		}

		public List<SellerRegistration> GetSellerRegistrationList()
        {
            try
            {
                var a = _dbContext.SellerRegistrations.Where(x => x.Deleted == false).ToList();
                return a;
            }
            catch
            {
                throw;
            }
        }
        public SellerRegistration GetSellerRegistrationById(Int64 sellerRegistrationId)
        {
            try
            {
                var a = _dbContext.SellerRegistrations.Where(x => x.SellerRegistrationId == sellerRegistrationId && x.Deleted == false).SingleOrDefault();
                return a;
            }
            catch
            {
                throw;
            }
        }
        public MessageEnum SellerRegistrationUpdate(SellerUpdateDTO sellerUpdateDTO)
        {
            try
            {
                var sel = _dbContext.SellerRegistrations.Where(x => x.SellerRegistrationId != sellerUpdateDTO.SellerRegistrationId && x.Name == sellerUpdateDTO.Name && x.Deleted == false).FirstOrDefault();
                if (sel == null)
                {
                    var a = _dbContext.SellerRegistrations.Where(x => x.SellerRegistrationId == sellerUpdateDTO.SellerRegistrationId).FirstOrDefault();
                    if (a != null)
                    {
                        a.Name = sellerUpdateDTO.Name;
                        a.BusinessName = sellerUpdateDTO.BusinessName;
                        a.Address = sellerUpdateDTO.Address;
                        a.PinCodeId = sellerUpdateDTO.PinCodeId;
                        a.Country = sellerUpdateDTO.Country;
                        a.State = sellerUpdateDTO.State;
                        a.PrimaryPhone = sellerUpdateDTO.PrimaryPhone;
                        a.AlternatePhone = sellerUpdateDTO.AlternatePhone;
                        a.MailId = sellerUpdateDTO.MailId;
                        a.SalesRepresentativeId = sellerUpdateDTO.SalesRepresentativeId;
                        a.SalesRepresentativeContact = sellerUpdateDTO.SalesRepresentativeContact;
                        a.GSTNumber = sellerUpdateDTO.GSTNumber;
                        a.WareHuoseId = sellerUpdateDTO.WareHuoseId;
                        a.Password = sellerUpdateDTO.Password;
                        a.SectorId = sellerUpdateDTO.SectorId;
                        a.Image = sellerUpdateDTO.Image;
                        a.UpdatedDate = DateTime.Now;
                        _dbContext.SaveChanges();
                        return MessageEnum.Updated;
                    }
                    else
                        return MessageEnum.Invalid;
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
        public MessageEnum DeleteSellerRegistration(Int64 sellerRegistrationId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.SellerRegistrations.Where(x => x.SellerRegistrationId == sellerRegistrationId).FirstOrDefault();
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
