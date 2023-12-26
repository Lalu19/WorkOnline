using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.WareHouses.Districts;
using CloudVOffice.Core.Domain.WareHouses.Months;
using CloudVOffice.Data.DTO.WareHouses.Districts;
using CloudVOffice.Data.DTO.WareHouses.Months;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Services.WareHouses.Months
{
    public interface IMonthService
    {
        public MessageEnum MonthCreate(MonthDTO monthDTO);
        public Month GetMonthById(Int64 MonthId);
        public List<Month> GetMonthList();
        public MessageEnum MonthUpdate(MonthDTO monthDTO);
        public MessageEnum MonthDelete(Int64 MonthId, Int64 DeletedBy);
    }
}
