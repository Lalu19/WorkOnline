using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.WareHouses.SalesOrders;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using CloudVOffice.Services.Sellers;
using CloudVOffice.Services.WareHouses.PurchaseOrders;
using CloudVOffice.Services.WareHouses.SalesOrders;
using CloudVOffice.Web.Framework;
using CloudVOffice.Web.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Warehouse.Management.Controllers
{
    [Area(AreaNames.WareHouse)]
    public class SalesOrderController : BasePluginController
    {
        private readonly ISalesOrderParentService _salesOrderParentService;
        private readonly ISalesOrderItemService _salesOrderItemService;


        public SalesOrderController(ISalesOrderParentService salesOrderParentService, ISalesOrderItemService salesOrderItemService
                                        )
        {
            _salesOrderParentService = salesOrderParentService;
            _salesOrderItemService = salesOrderItemService;
        }


    }
}
