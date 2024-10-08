﻿using System;
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
        public string Sectors { get; set; }
        public List<double> Quantity { get; set; }
        public List<double> Amount { get; set; }
        public List<string> ShortName { get; set; }

        public StockManagementSectorWise()
        {
            Quantity = new List<double>();
            Amount = new List<double>();
            ShortName = new List<string>();
        }
    }
}
