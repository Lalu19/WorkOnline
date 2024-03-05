using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using LinqToDB;

namespace CloudVOffice.Services.Sales
{
    public class SalesExecutiveRegistrationService : ISalesExecutiveRegistrationService
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly ISqlRepository<SalesExecutiveRegistration> _salesExecutiveRegistration;

        public SalesExecutiveRegistrationService (ApplicationDBContext dbContext, ISqlRepository<SalesExecutiveRegistration> salesExecutiveRegistration
            )
        {
            _dbContext = dbContext;
            _salesExecutiveRegistration = salesExecutiveRegistration;
        }

        public MessageEnum CreateSalesExecutive(SalesExecutiveRegistrationDTO salesExecutiveRegistrationDTO)
        {
            try
            {
                var objcheck = _dbContext.SalesExecutiveRegistrations.FirstOrDefault(a => a.SalesExecutiveRegistrationId == salesExecutiveRegistrationDTO.SalesExecutiveRegistrationId);

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
                    salesExecutiveRegistration.Password = salesExecutiveRegistrationDTO.Password;
                    salesExecutiveRegistration.Image = salesExecutiveRegistrationDTO.Image;



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

        public List<SalesExecutiveRegistration> GetSalesExecutiveRegistrationByWarehouseId(int WarehouseId)
        {
            try
            {
                var salesExec = _dbContext.SalesExecutiveRegistrations.Where(a=> a.WareHuoseId == WarehouseId).ToList();
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
                var buyers = _dbContext.BuyerRegistrations.Where(a => a.SalesRepresentativeId == salesExecutiveRegistrationId.ToString()).ToList();
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
                var buyers = _dbContext.BuyerRegistrations.Where(a => a.SalesRepresentativeId == SalesExecutiveUniqueNumber.ToString()).ToList();
                return buyers;
            }
            catch
            {
                throw;
            }
        }
    }
}
