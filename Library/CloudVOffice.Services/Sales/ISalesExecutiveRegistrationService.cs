using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Buyers;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Data.DTO.Sales;

namespace CloudVOffice.Services.Sales
{
    public interface ISalesExecutiveRegistrationService
    {
        public MessageEnum CreateSalesExecutive(SalesExecutiveRegistrationDTO salesExecutiveRegistrationDTO);
        public List<SalesExecutiveRegistration> GetAllSalesExecutiveRegistrations();
        public SalesExecutiveRegistration GetSalesExecutiveRegistrationsById(int salesExecutiveRegistrationId);
        public List<SalesExecutiveRegistration> GetSalesExecutiveRegistrationByWarehouseId(int WarehouseId);
        public List<BuyerRegistration> GetBuyerRegistrationsBySalesExecutiveUniqueNumber(int SalesExecutiveUniqueNumber);
    }
}
