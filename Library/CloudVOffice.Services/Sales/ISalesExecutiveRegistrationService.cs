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
        public MessageEnum UpdateSalesExecutive(SalesExecutiveRegistrationDTO salesExecutiveRegistrationDTO);
        public List<SalesExecutiveRegistration> GetAllSalesExecutiveRegistrations();
        public SalesExecutiveRegistration GetSalesExecutiveRegistrationsById(int salesExecutiveRegistrationId);
        public MessageEnum SalesExecutiveRegistrationDelete(Int64 SalesExecutiveRegistrationId, Int64 DeletedBy);
        public List<SalesExecutiveRegistration> GetSalesExecutiveRegistrationByWarehouseId(int WarehouseId);
        public List<BuyerRegistration> GetBuyerRegistrationsBySalesExecutiveUniqueNumber(string SalesExecutiveUniqueNumber);
        public MessageEnum DeleteSalesExecutive(Int64 salesExecutiveRegistrationId, Int64 DeletedBy);
    }
}
