﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using LinqToDB;

namespace CloudVOffice.Services.Sales
{
    public class SalesExecutiveRegistrationService : ISalesExecutiveRegistrationService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SalesExecutiveRegistration> _salesExecutiveRegistration;

        public SalesExecutiveRegistrationService(ApplicationDBContext dbContext, ISqlRepository<SalesExecutiveRegistration> salesExecutiveRegistration
            )
        {
            _dbContext = dbContext;
            _salesExecutiveRegistration = salesExecutiveRegistration;
        }

        public MessageEnum CreateSalesExecutive(SalesExecutiveRegistrationDTO salesExecutiveRegistrationDTO)
        {
            try
            {
               // var objcheck = _dbContext.SalesExecutiveRegistrations.FirstOrDefault(a => a.SalesExecutiveRegistrationId == salesExecutiveRegistrationDTO.SalesExecutiveRegistrationId && a.PrimaryPhone == salesExecutiveRegistrationDTO.PrimaryPhone);

				var objcheck = _dbContext.SalesExecutiveRegistrations.Where(x => x.PrimaryPhone == salesExecutiveRegistrationDTO.PrimaryPhone && x.Deleted == false).FirstOrDefault();

				if (objcheck == null)
                {
                    SalesExecutiveRegistration salesExecutiveRegistration = new SalesExecutiveRegistration();

                    salesExecutiveRegistration.SalesExecutiveName = salesExecutiveRegistrationDTO.SalesExecutiveName;
                    salesExecutiveRegistration.AadharCardNumber = salesExecutiveRegistrationDTO.AadharCardNumber;
                    salesExecutiveRegistration.PANCardNumber = salesExecutiveRegistrationDTO.PANCardNumber;
                    salesExecutiveRegistration.PrimaryPhone = salesExecutiveRegistrationDTO.PrimaryPhone;
                    salesExecutiveRegistration.AlternatePhone = salesExecutiveRegistrationDTO.AlternatePhone;
                    salesExecutiveRegistration.Address = salesExecutiveRegistrationDTO.Address;
                    salesExecutiveRegistration.WareHuoseId = salesExecutiveRegistrationDTO.WareHuoseId;
                    salesExecutiveRegistration.MailId = salesExecutiveRegistrationDTO.MailId;
                    salesExecutiveRegistration.RetailModelId = 4;
                    salesExecutiveRegistration.Password = salesExecutiveRegistrationDTO.Password;
                    salesExecutiveRegistration.Image = salesExecutiveRegistrationDTO.Image;
                    salesExecutiveRegistration.CreatedBy = salesExecutiveRegistrationDTO.CreatedBy;


                    string warehouseName = _dbContext.WareHouses.Where(x => x.WareHuoseId == salesExecutiveRegistrationDTO.WareHuoseId).Select(x => x.WareHouseName).FirstOrDefault();
                    //salesExecutiveRegistration.SalesExecutiveUniqueNumber = Wname;

                    int lastNumber = _dbContext.SalesExecutiveRegistrations
    .Where(x => x.SalesExecutiveUniqueNumber.StartsWith(warehouseName))
    .AsEnumerable()  // Bring data into memory
    .Select(x => int.Parse(x.SalesExecutiveUniqueNumber.Substring(warehouseName.Length)))
    .OrderByDescending(x => x)
    .FirstOrDefault();


                    // Increment the last number to generate a new SalesExecutiveUniqueNumber
                    int newNumber = lastNumber + 1;

                    salesExecutiveRegistration.SalesExecutiveUniqueNumber = $"{warehouseName}{newNumber:D3}";

                    // Other property assignments...

                    _salesExecutiveRegistration.Insert(salesExecutiveRegistration);

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

        public MessageEnum UpdateSalesExecutive(SalesExecutiveRegistrationDTO salesExecutiveRegistrationDTO)
        {
            try
            {
                var updateSalesExecutive = _dbContext.SalesExecutiveRegistrations.Where(x => x.SalesExecutiveRegistrationId != salesExecutiveRegistrationDTO.SalesExecutiveRegistrationId && x.PrimaryPhone == salesExecutiveRegistrationDTO.PrimaryPhone && x.Deleted == false).FirstOrDefault();
                if (updateSalesExecutive == null)
                {
                    var a = _dbContext.SalesExecutiveRegistrations.Where(x => x.SalesExecutiveRegistrationId == salesExecutiveRegistrationDTO.SalesExecutiveRegistrationId).FirstOrDefault();
                    if (a != null)
                    {
                        a.SalesExecutiveName = salesExecutiveRegistrationDTO.SalesExecutiveName;
                        a.PANCardNumber = salesExecutiveRegistrationDTO.PANCardNumber;
                        a.AadharCardNumber = salesExecutiveRegistrationDTO.AadharCardNumber;
                        a.WareHuoseId = salesExecutiveRegistrationDTO.WareHuoseId;
                        a.PrimaryPhone = salesExecutiveRegistrationDTO.PrimaryPhone;
                        a.AlternatePhone = salesExecutiveRegistrationDTO.AlternatePhone;
                        a.MailId = salesExecutiveRegistrationDTO.MailId;
                        a.Password = salesExecutiveRegistrationDTO.Password;
                        a.Address = salesExecutiveRegistrationDTO.Address;
                        a.Image = salesExecutiveRegistrationDTO.Image;
                      
                        a.UpdatedBy = salesExecutiveRegistrationDTO.CreatedBy;
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



        public List<SalesExecutiveRegistration> GetAllSalesExecutiveRegistrations()
        {
            try
            {
                var a = _dbContext.SalesExecutiveRegistrations.Where(a => a.Deleted == false).ToList();
                return a;
            }
            catch
            {
                throw;
            }
        }


        public SalesExecutiveRegistration GetSalesExecutiveRegistrationsById(int salesExecutiveRegistrationId)
        {
            try
            {
                var a = _dbContext.SalesExecutiveRegistrations.Where(a => a.SalesExecutiveRegistrationId == salesExecutiveRegistrationId).FirstOrDefault();
                return a;
            }
            catch
            {
                throw;
            }
        }

        public MessageEnum SalesExecutiveRegistrationDelete(Int64 SalesExecutiveRegistrationId, Int64 DeletedBy)
        {
            try
            {
                var a = _dbContext.SalesExecutiveRegistrations.Where(x => x.SalesExecutiveRegistrationId == SalesExecutiveRegistrationId).FirstOrDefault();

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

        public List<SalesExecutiveRegistration> GetSalesExecutiveRegistrationByWarehouseId(int WarehouseId)
        {
            try
            {
                var salesExec = _dbContext.SalesExecutiveRegistrations.Where(a => a.WareHuoseId == WarehouseId).ToList();
                return salesExec;
            }
            catch
            {
                throw;
            }
        }

        public List<BuyerRegistration> GetBuyerRegistrationBySalesExecutiveId(int salesExecutiveRegistrationId)
        {
            try
            {
                var buyers = _dbContext.BuyerRegistrations.Where(a => a.SalesExecutiveUniqueNumber == salesExecutiveRegistrationId.ToString()).ToList();
                return buyers;
            }
            catch
            {
                throw;
            }
        }

        public List<BuyerRegistration> GetBuyerRegistrationsBySalesExecutiveUniqueNumber(int SalesExecutiveUniqueNumber)
        {
            try
            {
                var buyers = _dbContext.BuyerRegistrations.Where(a => a.SalesExecutiveUniqueNumber == SalesExecutiveUniqueNumber.ToString()).ToList();
                return buyers;
            }
            catch
            {
                throw;
            }
        }
    }
}
