using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.Brands
{
    public class BrandDTO
    {
        public Int64? BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandImage { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
