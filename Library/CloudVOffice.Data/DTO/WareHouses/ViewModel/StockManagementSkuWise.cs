using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace CloudVOffice.Data.DTO.WareHouses.ViewModel
{
    public class StockManagementSkuWise
    {
        public string ProductName { get; set; }
        public string ShortName { get; set; }
        public double? UnitPerCase { get; set; }
        public double? StockLeft { get; set; }
        public double? GST { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int DaysLeft { get; set; }

    }
}
