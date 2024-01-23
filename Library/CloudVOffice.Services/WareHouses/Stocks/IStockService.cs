using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.PinCodes;
using CloudVOffice.Core.Domain.WareHouses.Stocks;
using CloudVOffice.Data.DTO.WareHouses.PinCodes;
using CloudVOffice.Data.DTO.WareHouses.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Stocks
{
    public interface IStockService
    {
        public MessageEnum StockCreate(StockDTO stockDTO);
        public Stock GetStockByStockId(Int64 stockId);
        public List<Stock> GetStockList();
        public MessageEnum StockUpdate(StockDTO stockDTO);
        public MessageEnum StockDelete(Int64 stockId, Int64 DeletedBy);
    }
}
