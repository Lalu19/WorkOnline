using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.Sales;
using CloudVOffice.Core.Domain.WareHouses.GST;
using CloudVOffice.Data.DTO.Sales;
using CloudVOffice.Data.DTO.WareHouses.GSTs;

namespace CloudVOffice.Services.Sales
{
    public interface ISalesAdminService
    {
        public MessageEnum CreateTargetsBySalesAdmin(SalesAdminDTO salesAdminDTO);
        public List<SalesAdminTarget> GetTargetsBySectorIdBySalesAdmin(Int64 sectorId);
        public SalesAdminTarget GetSalesAdminTargetBySalesAdminId(Int64 salesAdminId);
        public List<SalesAdminTarget> GetAllTargetsBySalesAdmin();
        public List<SalesAdminTarget> GetTargetsByCategoryIdBySalesAdmin(Int64 categoryId);
        public List<SalesAdminTarget> GetTargetsByMonthBySalesAdmin(Int64 monthId);
        public MessageEnum UpdateTargetsBySalesAdmin(SalesAdminDTO salesAdminDTO);
        public MessageEnum DeleteTargetsBySalesAdmin(Int64 targetId, Int64 DeletedBy);
        public string GetCategoryIdByName(string categoryName);

	}
}
