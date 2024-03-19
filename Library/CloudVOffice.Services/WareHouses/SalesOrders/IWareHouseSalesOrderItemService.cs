using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.WareHouses.SalesOrders;

namespace CloudVOffice.Services.WareHouses.SalesOrders
{
    public interface IWareHouseSalesOrderItemService
    {
        public MessageEnum CreateWareHouseSalesOrderItem(Int64 ParentId, Int64 createdBy, List<WareHouseSalesOrderItemDTO> wareHouseSalesOrderItemDTO);
    }
}
