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
    public interface ISalesManagerTargetService
    {
        public MessageEnum CreateSalesManagerTarget(SalesManagerrTargetDTO salesManagerTargetDTO);

        public List<SalesManagerTarget> GetTargetsBySectorIdBySalesManagerTarget(Int64 sectorId);
        public SalesManagerTarget GetSalesManagerTargetBySalesManagerTargetId(Int64 salesManagerTargetId);
        public List<SalesManagerTarget> GetAllTargetsBySalesManagerTarget();
        public List<SalesManagerTarget> GetTargetsByCategoryIdBySalesManagerTarget(Int64 categoryId);
        public List<SalesManagerTarget> GetTargetsByMonthBySalesManagerTarget(Int64 monthId);
        //public MessageEnum UpdateTargetsBySalesAdmin(SalesAdminDTO salesAdminDTO);
        public MessageEnum UpdateTargetsBySalesManagerTarget(SalesManagerrTargetDTO salesManagerTargetDTO);


        public MessageEnum DeleteTargetsBySalesManagerTarget(Int64 salesManagerTargetId, Int64 DeletedBy);
        public string GetCategoryIdByName(string categoryName);
        //MessageEnum CreateSalesManagerTarget(object target);
        //MessageEnum UpdateTargetsBySalesManagerTarget(object target);
    }
}
