using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudVOffice.Data.DTO.WareHouses.GSTs
{
    public class GSTDTO
    {
        public Int64? GSTId { get; set; }
        public double GSTValue { get; set; }
        public Int64 CreatedBy { get; set; }
    }
}
