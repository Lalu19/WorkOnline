using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.ViewModel.StockManagement
{
    public class StockManagementBrandWise
    {
        public string Brands { get; set; }
        public List<double> Quantity { get; set; }
        public List<double> Amount { get; set; }
        public List<string> ShortName { get; set; }

        public StockManagementBrandWise()
        {
            Quantity = new List<double>();
            Amount = new List<double>();
            ShortName = new List<string>();
        }
    }
}
