using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Data.DTO.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.Sales
{
    public interface ISalesExecutiveTargetService
    {
        public MessageEnum CreateTargetsBySalesExecutive(SalesExecutiveTargetDTO salesExecutiveTargetDTO);

        public SalesExecutiveTarget GetSalesExecutiveTargetBySalesExecutiveId(Int64 salesExecutiveId);
        public List<SalesExecutiveTarget> GetAllTargetsBySalesExecutive();

        //public List<SalesExecutiveTarget> GetTargetsBySectorIdBySalesAdmin(Int64 sectorId);
        //public List<SalesExecutiveTarget> GetTargetsByCategoryIdBySalesAdmin(Int64 categoryId);
        //public List<SalesExecutiveTarget> GetTargetsByMonthBySalesExecutive(Int64 monthId);

        public MessageEnum UpdateTargetsBySalesExecutive(SalesExecutiveTargetDTO salesExecutiveTargetDTO);

        public MessageEnum DeleteTargetsBySalesExecutive(Int64 targetId, Int64 DeletedBy);
        public string GetCategoryIdByName(string categoryName);
    }
}
