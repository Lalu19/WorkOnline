using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.ProductCategories;
using Microsoft.CodeAnalysis;

namespace CloudVOffice.Data.DTO.WareHouses.ViewModel
{
    public class StockManagementSectorWise
    {
        public List<string> Sectors { get; set; }
        public List<double> Quantity { get; set; }
        public List<double> Amount { get; set; }
    }
}
